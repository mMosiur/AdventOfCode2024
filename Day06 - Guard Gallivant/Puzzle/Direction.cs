namespace AdventOfCode.Year2024.Day06.Puzzle;

internal enum Direction
{
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3,
}

internal static class DirectionExtensions
{
    public static Direction TurnRight(this Direction direction)
        => (Direction)(((int)direction + 1) % 4);

    public static Direction TurnLeft(this Direction direction)
        => (Direction)(((int)direction + 3) % 4);

    public static Vector GetVector(this Direction direction)
        => direction switch
        {
            Direction.Up => new(-1, 0),
            Direction.Right => new(0, 1),
            Direction.Down => new(1, 0),
            Direction.Left => new(0, -1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction)),
        };
}
