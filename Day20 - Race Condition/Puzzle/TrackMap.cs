namespace AdventOfCode.Year2024.Day20.Puzzle;

internal sealed class TrackMap(TrackSpot[,] map, Point startPoint, Point endPoint)
{
    private readonly TrackSpot[,] _map = map;

    public Point StartPoint { get; } = startPoint;
    public Point EndPoint { get; } = endPoint;
    public Bounds Bounds { get; } = new(0, map.GetLength(1) - 1, 0, map.GetLength(0) - 1);

    public TrackSpot this[int y, int x] => _map[y, x];
    public TrackSpot this[Point point] => _map[point.Y, point.X];

    public bool CheckSpotIs(Point p, TrackSpot spot)
    {
        if (!Bounds.Contains(p)) return false;
        return _map[p.Y, p.X] == spot;
    }
}

internal enum TrackSpot
{
    Empty,
    Wall,
}
