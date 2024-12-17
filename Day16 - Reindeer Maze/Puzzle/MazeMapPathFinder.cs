using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day16.Puzzle;

internal sealed class MazeMapPathFinder(MazeMap map, Point endPosition, int forwardMoveScore, int turnMoveScore)
{
    private readonly MazeMap _map = map;
    private readonly Point _endPosition = endPosition;
    private readonly int _forwardMoveScore = forwardMoveScore;
    private readonly int _turnMoveScore = turnMoveScore;

    public IEnumerable<List<Point>> FindAllBestPaths(Point reindeerStartPosition, Vector reindeerStartDirection)
    {
        Dictionary<ReindeerOrientation, int> bestScores = new();
        PriorityQueue<ReindeerRunState, int> queue = new();
        queue.Enqueue(new(reindeerStartPosition, reindeerStartDirection, [], 0), 0);
        int bestPathScore = int.MaxValue;

        while (queue.TryDequeue(out ReindeerRunState state, out int heuristicScore))
        {
            if (state.Position == _endPosition)
            {
                if (state.Score > bestPathScore)
                    break; // Since we are using a priority queue then all next paths will have a higher score

                // We will not find a better path since we are using a priority queue and so there will not be a lower score.
                // But we can still find paths with the same score.
                bestPathScore = state.Score;
                state.Path.Add(state.Position);
                yield return state.Path;
            }

            if (bestScores.TryGetValue(state.Orientation, out int bestScore) && bestScore < state.Score)
                continue;

            bestScores[state.Orientation] = state.Score;

            EnqueueRotationIfDirectionOpen(queue, state, state.Direction.RotateClockwise());
            EnqueueRotationIfDirectionOpen(queue, state, state.Direction.RotateCounterclockwise());
            TryEnqueueForward(queue, state);
        }
    }

    private bool EnqueueRotationIfDirectionOpen(PriorityQueue<ReindeerRunState, int> queue, ReindeerRunState state, Vector newDirection)
    {
        if (_map[state.Position + newDirection] is TileType.Wall) return false;
        int newScore = state.Score + _turnMoveScore;
        int newHeuristicScore = newScore + MathG.ManhattanDistance(state.Position, _endPosition);
        var newPath = new List<Point>(state.Path); // Clone the path
        queue.Enqueue(new(state.Position, newDirection, [.. state.Path], newScore), newHeuristicScore);
        return true;
    }

    private bool TryEnqueueForward(PriorityQueue<ReindeerRunState, int> queue, ReindeerRunState state)
    {
        var newPosition = state.Position + state.Direction;
        if (_map[newPosition] is not TileType.Empty) return false;
        int newScore = state.Score + _forwardMoveScore;
        int newHeuristicScore = newScore + MathG.ManhattanDistance(newPosition, _endPosition);
        state.Path.Add(state.Position); // Add current position and reuse the list
        queue.Enqueue(new(newPosition, state.Direction, state.Path, newScore), newHeuristicScore);
        return true;
    }

    private readonly record struct ReindeerOrientation(Point Position, Vector Direction);

    private readonly record struct ReindeerRunState(Point Position, Vector Direction, List<Point> Path, int Score)
    {
        public ReindeerOrientation Orientation => new(Position, Direction);
    }
}
