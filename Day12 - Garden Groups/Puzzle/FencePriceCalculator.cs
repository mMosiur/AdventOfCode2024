namespace AdventOfCode.Year2024.Day12.Puzzle;

internal sealed class FencePriceCalculator(bool bulkDiscount)
{
    private readonly bool _bulkDiscount = bulkDiscount;

    public int CalculatePriceForRegion(GardenRegion region)
    {
        return _bulkDiscount
            ? CalculatePriceWithDiscount(region)
            : CalculatePriceWithoutDiscount(region);
    }

    private int CalculatePriceWithoutDiscount(GardenRegion region)
    {
        int area = region.CalculateArea();
        int perimeter = region.CalculatePerimeter();
        return area * perimeter;
    }

    private int CalculatePriceWithDiscount(GardenRegion region)
    {
        int area = region.CalculateArea();
        int sidesCount = region.CalculateSidesCount();
        return area * sidesCount;
    }
}
