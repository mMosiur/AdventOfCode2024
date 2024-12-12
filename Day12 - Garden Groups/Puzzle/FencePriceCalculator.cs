namespace AdventOfCode.Year2024.Day12.Puzzle;

internal sealed class FencePriceCalculator
{
    public int CalculatePriceForRegion(GardenRegion region)
    {
        int area = region.CalculateArea();
        int perimeter = region.CalculatePerimeter();
        return area * perimeter;
    }
}
