using AdventOfCode.Common.Geometry;
using AdventOfCode.Year2024.Day06.Puzzle.Caches;

namespace AdventOfCode.Year2024.Day06.Puzzle;

internal sealed class LabMap
{
    private readonly GuardSeenObstaclesCache _guardSeenObstaclesCache;
    private readonly ObstaclePositionCache _obstaclePositions;
    private readonly Rectangle<int> _bounds;

    public IEnumerable<Point> ObstaclePositions => _obstaclePositions;
    public Rectangle<int> Bounds => _bounds;

    public LabMap(Rectangle<int> bounds, IEnumerable<Point> obstaclePositions)
    {
        _bounds = bounds;
        _obstaclePositions = new(bounds, obstaclePositions);
        _guardSeenObstaclesCache = new(bounds);
    }

    public void AddObstacle(Point obstaclePosition)
    {
        if (!_bounds.Contains(obstaclePosition))
        {
            throw new ArgumentException("Obstacle position is outside the bounds", nameof(obstaclePosition));
        }

        _obstaclePositions.Add(obstaclePosition);
    }

    public void RemoveObstacle(Point obstaclePosition)
    {
        if (!_bounds.Contains(obstaclePosition))
        {
            throw new ArgumentException("Obstacle position is outside the bounds", nameof(obstaclePosition));
        }

        _obstaclePositions.Remove(obstaclePosition);
    }

    public IEnumerable<Point> FollowGuardPath(Point guardStartingPosition, Direction guardStartingDirection)
    {
        if (!_bounds.Contains(guardStartingPosition))
        {
            throw new ArgumentException("Guard starting position is outside the bounds", nameof(guardStartingPosition));
        }

        var guard = new Guard(guardStartingPosition, guardStartingDirection);
        yield return guard.Position;
        while (_bounds.Contains(guard.NextPosition))
        {
            if (_obstaclePositions.Contains(guard.NextPosition))
            {
                guard.TurnRight();
            }
            else
            {
                guard.MoveAhead();
                yield return guard.Position;
            }
        }
    }

    public bool IsGuardInfiniteLoop(Point guardStartingPosition, Direction guardStartingDirection)
    {
        if (!_bounds.Contains(guardStartingPosition))
        {
            throw new ArgumentException("Guard starting position is outside the bounds", nameof(guardStartingPosition));
        }

        _guardSeenObstaclesCache.Clear();
        var guard = new Guard(guardStartingPosition, guardStartingDirection);
        while (_bounds.Contains(guard.NextPosition))
        {
            if (_obstaclePositions.Contains(guard.NextPosition))
            {
                if (!_guardSeenObstaclesCache.TryAdd(guard.Position, guard.Direction))
                {
                    // Try to add this obstacle position with direction of the guard to seen hashset.
                    // If it already exists, it means we have seen this position with this direction
                    // before, and we are in an infinite loop.
                    return true;
                }
                guard.TurnRight();
            }
            else
            {
                guard.MoveAhead();
            }
        }

        return false;
    }
}
