namespace AdventOfCode.Year2024.Day08.Puzzle.Extensions;

internal static class PointExtensions
{
    public static bool IsOnGrid(this PrecisePoint precisePoint)
    {
        return double.IsInteger(precisePoint.X) && double.IsInteger(precisePoint.Y);
    }

    public static GridPoint AsGridPoint(this PrecisePoint precisePoint)
    {
        return new((int)precisePoint.X, (int)precisePoint.Y);
    }

    public static PrecisePoint AsPrecisePoint(this GridPoint gridPoint)
    {
        return new((double)gridPoint.X, (double)gridPoint.Y);
    }
}
