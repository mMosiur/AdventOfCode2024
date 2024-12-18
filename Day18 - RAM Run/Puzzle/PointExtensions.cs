namespace AdventOfCode.Year2024.Day18.Puzzle;

internal static class PointExtensions
{
    public static IEnumerable<Point> EnumerateAdjacent(this Point point)
    {
        yield return new(point.X + 1, point.Y);
        yield return new(point.X, point.Y + 1);
        yield return new(point.X - 1, point.Y);
        yield return new(point.X, point.Y - 1);
    }
}
