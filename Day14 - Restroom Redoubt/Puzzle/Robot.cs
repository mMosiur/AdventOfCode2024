namespace AdventOfCode.Year2024.Day14.Puzzle;

internal sealed class Robot(Point position, Vector velocity)
{
    public Point Position { get; private set; } = position;
    public Vector Velocity { get; private set; } = velocity;

    public void Move(Bounds bounds)
    {
        (int newPositionX, int newPositionY) = Position + Velocity;
        int width = bounds.XRange.Count;
        int height = bounds.YRange.Count;
        if (newPositionX < 0) newPositionX += width;
        if (newPositionY < 0) newPositionY += height;
        Position = new(
            (newPositionX + width) % width,
            (newPositionY + height) % height
        );
    }
}
