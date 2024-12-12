namespace AdventOfCode.Year2024.Day12.Puzzle;

internal sealed class GardenRegion(GardenPlotMap gardenPlotMap, PlantType plantType, IReadOnlyCollection<Point> plotPositions)
{
    public GardenPlotMap GardenMap { get; } = gardenPlotMap;
    public PlantType PlantType { get; } = plantType;
    public IReadOnlyCollection<Point> PlotPositions { get; } = plotPositions;

    public int CalculateArea()
    {
        return PlotPositions.Count;
    }

    public int CalculatePerimeter()
    {
        return PlotPositions.Sum(CalculatePerimeterOwnedByPlot);
    }

    private int CalculatePerimeterOwnedByPlot(Point plotPosition)
    {
        return plotPosition
            .EnumerateAdjacent()
            .Count(adjacentPosition => !GardenMap.Bounds.Contains(adjacentPosition) || GardenMap[adjacentPosition] != PlantType);
    }
}
