using AdventOfCode.Common;
using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day16.Puzzle;

internal sealed class MazeMapRunScorer(MazeMap map, Point endPosition, int forwardMoveScore, int turnMoveScore)
{
    private readonly MazeMap _map = map;
    private readonly Point _endPosition = endPosition;
    private readonly int _forwardMoveScore = forwardMoveScore;
    private readonly int _turnMoveScore = turnMoveScore;

    public int FindBestPathScore(Point reindeerStartPosition, Vector reindeerStartDirection)
    {
        Dictionary<ReindeerOrientation, int> bestScores = new();
        PriorityQueue<ReindeerRunState, int> queue = new();
        queue.Enqueue(new(reindeerStartPosition, reindeerStartDirection, 0), 0);

        while (queue.TryDequeue(out ReindeerRunState state, out int heuristicScore))
        {
            if (state.Position == _endPosition)
                return state.Score;

            if (bestScores.TryGetValue(state.Orientation, out int bestScore) && bestScore <= state.Score)
                continue;

            bestScores[state.Orientation] = state.Score;

            EnqueueRotationIfDirectionOpen(queue, state, state.Direction.RotateClockwise());
            EnqueueRotationIfDirectionOpen(queue, state, state.Direction.RotateCounterclockwise());
            TryEnqueueForward(queue, state);
        }

        throw new DaySolverException("No path found");
    }

    private bool EnqueueRotationIfDirectionOpen(PriorityQueue<ReindeerRunState, int> queue, ReindeerRunState state, Vector newDirection)
    {
        if (_map[state.Position + newDirection] is TileType.Wall) return false;
        int newScore = state.Score + _turnMoveScore;
        int newHeuristicScore = newScore + MathG.ManhattanDistance(state.Position, _endPosition);
        queue.Enqueue(new(state.Position, newDirection, newScore), newHeuristicScore);
        return true;
    }

    private bool TryEnqueueForward(PriorityQueue<ReindeerRunState, int> queue, ReindeerRunState state)
    {
        var newPosition = state.Position + state.Direction;
        if (_map[newPosition] is not TileType.Empty) return false;
        int newScore = state.Score + _forwardMoveScore;
        int newHeuristicScore = newScore + MathG.ManhattanDistance(newPosition, _endPosition);
        queue.Enqueue(new(newPosition, state.Direction, newScore), newHeuristicScore);
        return true;
    }

    private readonly record struct ReindeerOrientation(Point Position, Vector Direction);

    private readonly record struct ReindeerRunState(Point Position, Vector Direction, int Score)
    {
        public ReindeerOrientation Orientation => new(Position, Direction);
    }
}
