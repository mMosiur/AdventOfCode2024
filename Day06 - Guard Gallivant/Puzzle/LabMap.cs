using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day06.Puzzle;

internal sealed class LabMap
{
    private readonly HashSet<Point> _obstaclePositions;
    private readonly Rectangle<int> _bounds;

    public LabMap(Rectangle<int> bounds, IEnumerable<Point> obstaclePositions)
    {
        _bounds = bounds;

        var obstaclePositionsSet = obstaclePositions.ToHashSet();
        if (obstaclePositionsSet.Any(p => !_bounds.Contains(p)))
        {
            throw new ArgumentException("Obstacle positions are outside the bounds", nameof(obstaclePositions));
        }

        _obstaclePositions = obstaclePositionsSet;
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
            if (!TryMoveGuardAhead(guard))
            {
                guard.TurnRight();
            }
        }
    }

    private bool TryMoveGuardAhead(Guard guard)
    {
        if (_obstaclePositions.Contains(guard.NextPosition))
        {
            return false;
        }

        guard.MoveAhead();
        return true;
    }
}
