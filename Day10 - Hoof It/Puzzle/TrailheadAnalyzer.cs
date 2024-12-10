namespace AdventOfCode.Year2024.Day10.Puzzle;

internal sealed class TrailheadAnalyzer(TopographicMap map)
{
    private const int TrailheadElevation = 0;
    private const int HikeTrailEndElevation = 9;
    private readonly TopographicMap _map = map;

    public IEnumerable<Point> FindTrailheads()
    {
        for (int x = 0; x < _map.Height; x++)
        {
            for (int y = 0; y < _map.Width; y++)
            {
                if (_map[x, y] is TrailheadElevation)
                {
                    yield return new(x, y);
                }
            }
        }
    }

    public int CalculateTrailheadScore(Point trailheadLocation)
    {
        if (!_map.Bounds.Contains(trailheadLocation))
        {
            throw new ArgumentOutOfRangeException(nameof(trailheadLocation), trailheadLocation, "The specified location is outside the bounds of the map.");
        }

        if (_map[trailheadLocation] is not TrailheadElevation)
        {
            throw new ArgumentException("The specified location is not a trailhead.", nameof(trailheadLocation));
        }

        return CalculateTrailheadScoreInternal(trailheadLocation);
    }

    private int CalculateTrailheadScoreInternal(Point trailheadLocation)
    {
        Queue<Point> queue = new();
        HashSet<Point> reachedHikeTrailEnds = new();
        queue.Enqueue(trailheadLocation);
        while (queue.TryDequeue(out var point))
        {
            int elevation = _map[point];
            if (elevation is HikeTrailEndElevation)
            {
                reachedHikeTrailEnds.Add(point);
                continue;
            }

            int nextTrailElevation = elevation + 1;

            EnqueueIfIsNextTrailPoint(queue, point.Above(), nextTrailElevation);
            EnqueueIfIsNextTrailPoint(queue, point.Below(), nextTrailElevation);
            EnqueueIfIsNextTrailPoint(queue, point.Left(), nextTrailElevation);
            EnqueueIfIsNextTrailPoint(queue, point.Right(), nextTrailElevation);
        }

        return reachedHikeTrailEnds.Count;
    }

    private bool EnqueueIfIsNextTrailPoint(Queue<Point> queue, Point point, int nextTrailElevation)
    {
        if (!_map.Bounds.Contains(point)) return false;
        if (_map[point] != nextTrailElevation) return false;
        queue.Enqueue(point);
        return true;
    }
}
