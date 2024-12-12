using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day12.Puzzle.GardenBuilders;

internal sealed class GardenBuilder
{
    private readonly GardenPlotMap _gardenPlotMap;
    private readonly GardenPlotBuilder[,] _gardenPlotBuilders;
    private readonly Rectangle<int> _bounds;

    private GardenBuilder(GardenPlotMap gardenPlotMap, GardenPlotBuilder[,] gardenPlotBuilders)
    {
        _gardenPlotMap = gardenPlotMap;
        _gardenPlotBuilders = gardenPlotBuilders;
        _bounds = new(0, gardenPlotMap.Height - 1, 0, gardenPlotMap.Width - 1);
    }

    public List<GardenRegion> BuildRegions()
    {
        List<GardenRegionBuilder> regionBuilders = [];
        foreach (var point in _bounds.Points)
        {
            var plotBuilder = _gardenPlotBuilders[point.X, point.Y];
            if (plotBuilder.RegionBuilder is not null) continue;

            var newRegionBuilder = new GardenRegionBuilder(plotBuilder.PlotPlantType);
            FlushFillFrom(point, newRegionBuilder);
            regionBuilders.Add(newRegionBuilder);
        }

        return regionBuilders
            .Select(rb => rb.Build(_gardenPlotMap))
            .ToList();
    }

    private void FlushFillFrom(Point sourcePlotPoint, GardenRegionBuilder regionBuilder)
    {
        var fillPositions = new Queue<Point>();
        fillPositions.Enqueue(sourcePlotPoint);

        while (fillPositions.TryDequeue(out var point))
        {
            var plotBuilder = _gardenPlotBuilders[point.X, point.Y];
            if (plotBuilder.PlotPlantType != regionBuilder.PlantType) continue;
            if (plotBuilder.RegionBuilder == regionBuilder) continue;

            regionBuilder.AddPlot(plotBuilder, point);
            foreach (var adjacentPoint in point.EnumerateAdjacent().Where(p => _bounds.Contains(p)))
            {
                fillPositions.Enqueue(adjacentPoint);
            }
        }
    }

    public static GardenBuilder CreateFrom(GardenPlotMap gardenPlotMap)
    {
        var plotBuilders = new GardenPlotBuilder[gardenPlotMap.Height, gardenPlotMap.Width];
        for (int row = 0; row < gardenPlotMap.Height; row++)
        {
            for (int col = 0; col < gardenPlotMap.Width; col++)
            {
                var plotPlantType = gardenPlotMap[row, col];
                plotBuilders[row, col] = new(plotPlantType);
            }
        }

        return new(gardenPlotMap, plotBuilders);
    }
}
