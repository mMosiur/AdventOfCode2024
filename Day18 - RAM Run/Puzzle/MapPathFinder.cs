using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day18.Puzzle;

internal sealed class MapPathFinder(MemorySpaceMap map)
{
    private readonly MemorySpaceMap _map = map;

    public int? FindShortestPath(Point start, Point end)
    {
        if (!_map.Bounds.Contains(start)) throw new ArgumentException("Start point is out of the map bounds.", nameof(start));
        if (!_map.Bounds.Contains(end)) throw new ArgumentException("End point is out of the map bounds.", nameof(end));

        var visitedPoints = new Dictionary<Point, int>();
        PriorityQueue<SearchState, int> queue = new();
        queue.Enqueue(new(start, 0), 0);

        while (queue.TryDequeue(out var searchState, out int heuristicScore))
        {
            if (searchState.Position == end)
            {
                return searchState.Steps;
            }

            if (visitedPoints.TryGetValue(searchState.Position, out int bestStepCount) && bestStepCount <= searchState.Steps) continue;
            visitedPoints[searchState.Position] = searchState.Steps;

            EnqueueAdjacentPoints(queue, searchState, end);
        }

        return null;
    }

    private int EnqueueAdjacentPoints(PriorityQueue<SearchState, int> queue, SearchState searchState, Point end)
    {
        int enqueuedCount = 0;
        foreach (var adjacentPoint in searchState.Position.EnumerateAdjacent())
        {
            if (!_map.Bounds.Contains(adjacentPoint)) continue;
            if (_map[adjacentPoint] is MemorySpaceByte.Corrupted) continue;
            int newSteps = searchState.Steps + 1;
            int newHeuristicScore = newSteps + HeuristicDistance(adjacentPoint, end);
            queue.Enqueue(new(adjacentPoint, newSteps), newHeuristicScore);
            enqueuedCount++;
        }

        return enqueuedCount;
    }

    private static int HeuristicDistance(Point a, Point b)
    {
        return MathG.ManhattanDistance(a, b);
    }

    private readonly record struct SearchState(Point Position, int Steps);
}
