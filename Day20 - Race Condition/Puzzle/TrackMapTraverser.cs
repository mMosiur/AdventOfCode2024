namespace AdventOfCode.Year2024.Day20.Puzzle;

internal sealed class TrackMapTraverser(TrackMap map)
{
    private readonly TrackMap _map = map;

    public DistanceMap BuildDistanceMap()
    {
        int?[,] distances = new int?[_map.Bounds.YRange.Count, _map.Bounds.XRange.Count];

        var queue = new Queue<TraverseState>();
        queue.Enqueue(new(_map.EndPoint, 0));

        while (queue.TryDequeue(out var state))
        {
            int? existingDistance = distances[state.Point.Y, state.Point.X];
            if (existingDistance.HasValue && existingDistance <= state.Distance)
            {
                continue;
            }

            distances[state.Point.Y, state.Point.X] = state.Distance;

            foreach (var direction in Vectors.StraightDirections.AsSpan())
            {
                var adjacentPoint = state.Point + direction;
                EnqueueIfProperPath(queue, adjacentPoint, state.Distance + 1);
            }
        }

        return new(distances);
    }

    private bool EnqueueIfProperPath(Queue<TraverseState> queue, Point point, int distance)
    {
        if (!_map.Bounds.Contains(point))
            return false;
        if (_map[point] == TrackSpot.Wall)
            return false;
        queue.Enqueue(new(point, distance));
        return true;
    }

    private readonly record struct TraverseState(Point Point, int Distance);
}
