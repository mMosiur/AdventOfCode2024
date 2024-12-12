namespace AdventOfCode.Year2024.Day12.Puzzle;

internal sealed class GardenRegion(GardenPlotMap gardenPlotMap, PlantType plantType, IEnumerable<Point> plotPositions)
{
    private readonly GardenPlotMap _gardenMap = gardenPlotMap;
    public PlantType PlantType { get; } = plantType;
    public IReadOnlySet<Point> PlotPositions { get; } = plotPositions.ToHashSet();

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
            .Count(adjacentPosition => !_gardenMap.Bounds.Contains(adjacentPosition) || _gardenMap[adjacentPosition] != PlantType);
    }

    public int CalculateSidesCount()
    {
        // Each side can be counted only once regardless of the number of plots it consists of.
        // Let's choose the highest placed plot (lowest X coordinate) for vertical sides and
        // leftmost plot (lowest Y coordinate) for horizontal sides as the origin point that "owns" whole side.
        int upSideCount = 0;
        int rightSideCount = 0;
        int downSideCount = 0;
        int leftSideCount = 0;

        foreach (var point in PlotPositions)
        {
            if (IsUpSideOrigin(point)) upSideCount++;
            if (IsRightSideOrigin(point)) rightSideCount++;
            if (IsDownSideOrigin(point)) downSideCount++;
            if (IsLeftSideOrigin(point)) leftSideCount++;
        }

        return upSideCount + rightSideCount + downSideCount + leftSideCount;
    }

    private bool IsUpSideOrigin(Point point)
    {
        // Is not up-side origin if plot above is within the region.
        if (PlotPositions.Contains(point.Above()))
            return false;

        // If left plot is not within the region, this is the up-side origin as per "most top-left origin" approach.
        if (!PlotPositions.Contains(point.Left()))
            return true;

        // If the plot above and left to this one is within region, then the left plot cannot be up-side origin
        // as it's upper edge is blocked by the plot above it being part of this region.
        if (PlotPositions.Contains(point.Above().Left()))
            return true;

        // If the plot to the left is within the region, and the plot above it is not, then that plot is either
        // the up-side origin or up-side continuation, either way this point is surely not the origin.
        return false;
    }

    private bool IsRightSideOrigin(Point point)
    {
        // Is not right-side origin if plot to the right is within the region.
        if (PlotPositions.Contains(point.Right()))
            return false;

        // If above plot is not within the region, this is the right-side origin as per "most top-left origin" approach.
        if (!PlotPositions.Contains(point.Above()))
            return true;

        // If the plot above and right to this one is within region, then the above plot cannot be right-side origin
        // as it's right edge is blocked by the plot to the right of it being part of this region.
        if (PlotPositions.Contains(point.Above().Right()))
            return true;

        // If the plot above is within the region, and the plot to the right of it is not, then that plot is either
        // the right-side origin or right-side continuation, either way this point is surely not the origin.
        return false;
    }

    private bool IsDownSideOrigin(Point point)
    {
        // Is not down-side origin if plot below is within the region.
        if (PlotPositions.Contains(point.Below()))
            return false;

        // If left plot is not within the region, this is the down-side origin as per "most top-left origin" approach.
        if (!PlotPositions.Contains(point.Left()))
            return true;

        // If the plot below and left to this one is within region, then the left plot cannot be down-side origin
        // as it's lower edge is blocked by the plot below it being part of this region.
        if (PlotPositions.Contains(point.Below().Left()))
            return true;

        // If the plot to the left is within the region, and the plot below it is not, then that plot is either
        // the down-side origin or down-side continuation, either way this point is surely not the origin.
        return false;
    }

    private bool IsLeftSideOrigin(Point point)
    {
        // Is not left-side origin if plot to the left is within the region.
        if (PlotPositions.Contains(point.Left()))
            return false;

        // If above plot is not within the region, this is the left-side origin as per "most top-left origin" approach.
        if (!PlotPositions.Contains(point.Above()))
            return true;

        // If the plot above and left to this one is within region, then the above plot cannot be left-side origin
        // as it's left edge is blocked by the plot to the left of it being part of this region.
        if (PlotPositions.Contains(point.Above().Left()))
            return true;

        // If the plot above is within the region, and the plot to the left of it is not, then that plot is either
        // the left-side origin or left-side continuation, either way this point is surely not the origin.
        return false;
    }
}
