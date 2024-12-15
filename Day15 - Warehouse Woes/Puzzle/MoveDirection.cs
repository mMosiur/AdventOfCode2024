namespace AdventOfCode.Year2024.Day15.Puzzle;

[Flags]
internal enum MoveDirection
{
    Up = 0b0001,
    Down = 0b0010,
    Left = 0b0100,
    Right = 0b1000,
}

internal static class MoveDirections
{
    public static MoveDirection Parse(char c)
    {
        return c switch
        {
            '^' => MoveDirection.Up,
            'v' => MoveDirection.Down,
            '<' => MoveDirection.Left,
            '>' => MoveDirection.Right,
            _ => throw new InvalidOperationException($"Unknown movement character '{c}'")
        };
    }

    public static Vector ToVector(this MoveDirection moveDirection)
    {
        var vector = Vector.Zero;
        if (((int)moveDirection & (int)MoveDirection.Up) != 0) vector += new Vector(-1, 0);
        if (((int)moveDirection & (int)MoveDirection.Down) != 0) vector += new Vector(1, 0);
        if (((int)moveDirection & (int)MoveDirection.Left) != 0) vector += new Vector(0, -1);
        if (((int)moveDirection & (int)MoveDirection.Right) != 0) vector += new Vector(0, 1);
        return vector;
    }
}
