namespace AdventOfCode.Year2024.Day20.Puzzle;

internal static class Vectors
{
    public static Vector Right { get; } = new(1, 0);
    public static Vector DownRight { get; } = new(1, 1);
    public static Vector Down { get; } = new(0, 1);
    public static Vector DownLeft { get; } = new(-1, 1);
    public static Vector Left { get; } = new(-1, 0);
    public static Vector UpLeft { get; } = new(-1, -1);
    public static Vector Up { get; } = new(0, -1);
    public static Vector UpRight { get; } = new(1, -1);

    public static Vector[] StraightDirections { get; } = [Right, Down, Left, Up];
}
