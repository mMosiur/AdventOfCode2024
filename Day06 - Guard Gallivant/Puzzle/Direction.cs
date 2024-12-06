namespace AdventOfCode.Year2024.Day06.Puzzle;

internal readonly struct Direction
{
    private Direction(Vector directionVector)
    {
        Vector = directionVector;
    }

    public Vector Vector { get; }

    public static Direction Up => new(new(-1, 0));
    public static Direction Right => new(new(0, 1));
    public static Direction Down => new(new(1, 0));
    public static Direction Left => new(new(0, -1));

    public Direction TurnRight() => new(new(Vector.Y, -Vector.X));
    public Direction TurnLeft() => new(new(-Vector.Y, Vector.X));
}
