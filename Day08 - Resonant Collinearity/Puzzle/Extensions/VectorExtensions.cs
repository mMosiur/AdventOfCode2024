namespace AdventOfCode.Year2024.Day08.Puzzle.Extensions;

internal static class VectorExtensions
{
    public static GridVector AsGridVector(this PreciseVector preciseVector)
    {
        return new((int)preciseVector.X, (int)preciseVector.Y);
    }

    public static PreciseVector AsPreciseVector(this GridVector gridVector)
    {

        return new((double)gridVector.X, (double)gridVector.Y);
    }
}
