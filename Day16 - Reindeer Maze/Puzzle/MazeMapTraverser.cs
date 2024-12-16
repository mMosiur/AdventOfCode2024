using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day16.Puzzle;

internal sealed class MazeMapTraverser(MazeMap map)
{
    private readonly MazeMap _map = map;
    private const int ForwardMoveScore = 1;
    private const int TurnMoveScore = 1000;

    public int FindLowestScorePath(Point reindeerStartPosition, Vector reindeerStartDirection, Point endPosition)
    {
        Dictionary<ReindeerState, int> bestScores = new();
        PriorityQueue<ReindeerState, int> queue = new();
        queue.Enqueue(new(reindeerStartPosition, reindeerStartDirection), 0);
        while (queue.TryDequeue(out ReindeerState reindeerState, out int score))
        {
            if (reindeerState.Position == endPosition)
                return score;

            if (bestScores.TryGetValue(reindeerState, out int bestScore) && bestScore <= score)
                continue;

            bestScores[reindeerState] = score;

            EnqueueRotationIfDirectionOpen(queue, reindeerState.Position, reindeerState.Direction.RotateClockwise(), score);
            EnqueueRotationIfDirectionOpen(queue, reindeerState.Position, reindeerState.Direction.RotateCounterclockwise(), score);
            TryEnqueueForward(queue, reindeerState.Position + reindeerState.Direction, reindeerState.Direction, score);
        }

        throw new DaySolverException("No path found");
    }

    private bool EnqueueRotationIfDirectionOpen(PriorityQueue<ReindeerState, int> queue, Point position, Vector newDirection, int currentScore)
    {
        if (_map[position + newDirection] is TileType.Wall) return false;
        queue.Enqueue(new(position, newDirection), currentScore + TurnMoveScore);
        return true;
    }

    private bool TryEnqueueForward(PriorityQueue<ReindeerState, int> queue, Point newPosition, Vector direction, int currentScore)
    {
        if (_map[newPosition] is not TileType.Empty) return false;
        queue.Enqueue(new(newPosition, direction), currentScore + ForwardMoveScore);
        return true;
    }

    private readonly record struct ReindeerState(Point Position, Vector Direction);
}
