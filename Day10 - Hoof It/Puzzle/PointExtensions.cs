namespace AdventOfCode.Year2024.Day10.Puzzle;

internal static class PointExtensions
{
    public static Point Above(this Point point) => new(point.X - 1, point.Y);
    public static Point Below(this Point point) => new(point.X + 1, point.Y);
    public static Point Left(this Point point) => new(point.X, point.Y - 1);
    public static Point Right(this Point point) => new(point.X, point.Y + 1);
}
