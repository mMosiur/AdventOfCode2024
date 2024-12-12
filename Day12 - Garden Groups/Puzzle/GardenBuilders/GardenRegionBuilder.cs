namespace AdventOfCode.Year2024.Day12.Puzzle.GardenBuilders;

internal sealed class GardenRegionBuilder(PlantType plantType)
{
    private readonly List<Point> _regionPlotPositions = [];
    public PlantType PlantType { get; } = plantType;

    public void AddPlot(GardenPlotBuilder plotBuilder, Point plotPosition)
    {
        plotBuilder.RegionBuilder = this;
        _regionPlotPositions.Add(plotPosition);
    }

    public GardenRegion Build(GardenPlotMap gardenPlotMap)
    {
        return new(gardenPlotMap, PlantType, _regionPlotPositions);
    }
}
