using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day10.Puzzle;

internal sealed class TopographicMap
{
    private readonly int[,] _elevations;

    public TopographicMap(int[,] elevations)
    {
        _elevations = elevations;
        Height = _elevations.GetLength(0);
        Width = _elevations.GetLength(1);
        Bounds = new(0, Height - 1, 0, Width - 1);
    }

    public Rectangle<int> Bounds { get; }
    public int Height { get; }
    public int Width { get; }

    public int this[int x, int y] => _elevations[x, y];
    public int this[Point point] => _elevations[point.X, point.Y];
}
