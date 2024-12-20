namespace AdventOfCode.Year2024.Day20.Puzzle;

internal sealed class TrackMapTraverser(TrackMap map)
{
    private readonly TrackMap _map = map;

    public Dictionary<Point, int> BuildDistanceMap()
    {
        var distances = new Dictionary<Point, int>();

        var queue = new Queue<TraverseState>();
        queue.Enqueue(new(_map.EndPoint, 0));

        while (queue.TryDequeue(out var state))
        {
            if (distances.TryGetValue(state.Point, out int existingDistance) && existingDistance <= state.Distance)
            {
                continue;
            }

            distances[state.Point] = state.Distance;

            foreach (var direction in Vectors.Directions.AsSpan())
            {
                var adjacentPoint = state.Point + direction;
                EnqueueIfProperPath(queue, adjacentPoint, state.Distance + 1);
            }
        }

        return distances;
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
