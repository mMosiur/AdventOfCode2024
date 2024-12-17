namespace AdventOfCode.Year2024.Day16.Puzzle;

internal static class Vectors
{
    public static Vector North = new(-1, 0);
    public static Vector East = new(0, 1);
    public static Vector South = new(1, 0);
    public static Vector West = new(0, -1);


    public static bool TryParse(ReadOnlySpan<char> s, out Vector vector)
    {
        if (s.Equals("North", StringComparison.OrdinalIgnoreCase))
            vector = North;
        else if (s.Equals("East", StringComparison.OrdinalIgnoreCase))
            vector = East;
        else if (s.Equals("South", StringComparison.OrdinalIgnoreCase))
            vector = South;
        else if (s.Equals("West", StringComparison.OrdinalIgnoreCase))
            vector = West;
        else
            vector = default;

        return vector != default;
    }


    public static Vector RotateClockwise(this Vector vector)
    {
        return new(vector.Y, -vector.X);
    }

    public static Vector RotateCounterclockwise(this Vector vector)
    {
        return new(-vector.Y, vector.X);
    }
}
