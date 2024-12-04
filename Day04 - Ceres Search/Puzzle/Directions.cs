using System.Collections.Immutable;

namespace AdventOfCode.Year2024.Day04.Puzzle;

internal static class Directions
{
    public static Vector Up => new(-1, 0);
    public static Vector UpRight => new(-1, 1);
    public static Vector Right => new(0, 1);
    public static Vector DownRight => new(1, 1);
    public static Vector Down => new(1, 0);
    public static Vector DownLeft => new(1, -1);
    public static Vector Left => new(0, -1);
    public static Vector UpLeft => new(-1, -1);

    public static ImmutableArray<Vector> All { get; } =
    [
        Up,
        UpRight,
        Right,
        DownRight,
        Down,
        DownLeft,
        Left,
        UpLeft,
    ];

    public static ImmutableArray<Vector> Corners { get; } =
    [
        UpRight,
        DownRight,
        DownLeft,
        UpLeft,
    ];
}
