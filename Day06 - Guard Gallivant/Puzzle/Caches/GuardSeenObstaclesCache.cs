using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day06.Puzzle.Caches;

internal sealed class GuardSeenObstaclesCache
{
    private readonly bool[,,] _cache;

    public GuardSeenObstaclesCache(Rectangle<int> bounds)
    {
        _cache = new bool[bounds.YRange.Count, bounds.XRange.Count, 4];
    }

    public bool TryAdd(Point obstaclePosition, Direction guardDirection)
    {
        if (_cache[obstaclePosition.Y, obstaclePosition.X, (int)guardDirection])
        {
            return false;
        }

        _cache[obstaclePosition.Y, obstaclePosition.X, (int)guardDirection] = true;
        return true;
    }

    public void Clear()
    {
        Array.Clear(_cache);
    }
}
