namespace AdventOfCode.Year2024.Day06.Puzzle;

internal sealed class Guard(Point position, Direction direction)
{
    public Point Position { get; set; } = position;
    public Direction Direction { get; set; } = direction;

    public Point NextPosition => Position + Direction.Vector;

    public void MoveAhead()
    {
        Position = NextPosition;
    }

    public void TurnRight()
    {
        Direction = Direction.TurnRight();
    }

    public void TurnLeft()
    {
        Direction = Direction.TurnLeft();
    }
}
