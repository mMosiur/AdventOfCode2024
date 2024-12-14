namespace AdventOfCode.Year2024.Day14.Puzzle;

internal sealed class Bathroom(Bounds bounds, IReadOnlyCollection<Robot> robots)
{
    public IReadOnlyCollection<Robot> Robots { get; } = robots;
    public Bounds Bounds { get; } = bounds;
    public int Width { get; } = bounds.XRange.Count;
    public int Height { get; } = bounds.YRange.Count;
    public int SecondsPassed { get; private set; }

    public void SimulateSeconds(int seconds)
    {
        for (int i = 1; i <= seconds; i++)
        {
            SimulateSecond();
        }
    }

    public void SimulateSecond()
    {
        foreach (Robot robot in Robots)
        {
            robot.Move(Bounds);
        }
        SecondsPassed++;
    }

    public int SafetyFactor()
    {
        Span<int> quadrants = stackalloc int[4];

        foreach (Robot robot in Robots)
        {
            var quadrant = GetQuadrant(robot.Position);
            if (quadrant is null) continue;
            quadrants[(int)quadrant.Value]++;
        }

        return quadrants[0] * quadrants[1] * quadrants[2] * quadrants[3];
    }

    private Quadrant? GetQuadrant(Point point)
    {
        int quadrant;
        if (point.X < Width / 2)
            quadrant = 0;
        else if (point.X > (Width - 1) / 2)
            quadrant = 1;
        else
            return null;

        if (point.Y < Height / 2)
            quadrant += 0;
        else if (point.Y > (Height - 1) / 2)
            quadrant += 2;
        else
            return null;

        return (Quadrant)quadrant;
    }

    private enum Quadrant
    {
        TopLeft = 0,
        TopRight = 1,
        BottomLeft = 2,
        BottomRight = 3,
    };
}
