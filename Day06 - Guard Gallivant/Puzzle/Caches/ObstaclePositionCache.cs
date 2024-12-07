using System.Collections;
using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day06.Puzzle.Caches;

internal sealed class ObstaclePositionCache : IEnumerable<Point>
{
    private readonly Rectangle<int> _bounds;
    private readonly bool[,] _cache;

    public ObstaclePositionCache(Rectangle<int> bounds, IEnumerable<Point> obstaclePositions)
    {
        _bounds = bounds;
        _cache = new bool[bounds.YRange.Count, bounds.XRange.Count];
        foreach (var obstaclePosition in obstaclePositions)
        {
            _cache[obstaclePosition.Y, obstaclePosition.X] = true;
        }
    }

    public bool Contains(Point position)
    {
        return _bounds.Contains(position)
            && _cache[position.Y - _bounds.YRange.Start, position.X - _bounds.XRange.Start];
    }

    public void Add(Point position)
    {
        if (!_bounds.Contains(position))
        {
            throw new ArgumentException("Obstacle position is outside the bounds", nameof(position));
        }

        _cache[position.Y - _bounds.YRange.Start, position.X - _bounds.XRange.Start] = true;
    }

    public void Remove(Point position)
    {
        if (!_bounds.Contains(position))
        {
            throw new ArgumentException("Obstacle position is outside the bounds", nameof(position));
        }

        _cache[position.Y - _bounds.YRange.Start, position.X - _bounds.XRange.Start] = false;
    }

    public IEnumerator<Point> GetEnumerator()
    {
        for (int y = _bounds.YRange.Start; y <= _bounds.YRange.End; y++)
        {
            for (int x = _bounds.XRange.Start; x <= _bounds.XRange.End; x++)
            {
                if (_cache[y - _bounds.YRange.Start, x - _bounds.XRange.Start])
                {
                    yield return new Point(y, x);
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
