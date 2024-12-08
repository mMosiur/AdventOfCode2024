namespace AdventOfCode.Year2024.Day08.Puzzle.Extensions;

internal static class VectorExtensions
{
    public static bool IsOnGrid(this PreciseVector preciseVector)
    {
        return double.IsInteger(preciseVector.X) && double.IsInteger(preciseVector.Y);
    }

    public static GridVector AsGridVector(this PreciseVector preciseVector)
    {
        return new((int)preciseVector.X, (int)preciseVector.Y);
    }

    public static PreciseVector AsPreciseVector(this GridVector gridVector)
    {

        return new((double)gridVector.X, (double)gridVector.Y);
    }
}

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
