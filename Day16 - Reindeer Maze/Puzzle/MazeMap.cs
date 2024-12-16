using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day16.Puzzle;

internal sealed class MazeMap
{
    private readonly TileType[,] _map;
    public Bounds Bounds { get; }

    public MazeMap(TileType[,] map)
    {
        Bounds = new(0, map.GetLength(0) - 1, 0, map.GetLength(1) - 1);
        // Check if outer sides are walls
        if (Bounds.XRange.Any(x =>
                map[x, Bounds.YRange.Start] is not TileType.Wall || map[x, Bounds.YRange.End] is not TileType.Wall)
         || Bounds.YRange.Any(y =>
                map[Bounds.XRange.Start, y] is not TileType.Wall || map[Bounds.XRange.End, y] is not TileType.Wall))
        {
            throw new DaySolverException("Outer sides must be walls");
        }

        _map = map;
    }

    public TileType this[int x, int y] => _map[x, y];
    public TileType this[Point point] => this[point.X, point.Y];
}

internal enum TileType
{
    Empty = 0,
    Wall = 1,
}
