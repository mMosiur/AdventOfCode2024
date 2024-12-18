namespace AdventOfCode.Year2024.Day18.Puzzle;

internal sealed class BlockingPointFinder(MemorySpaceMap memorySpaceMap, Point start, Point end)
{
    private readonly MemorySpaceMap _memorySpaceMap = memorySpaceMap;
    private readonly Point _start = start;
    private readonly Point _end = end;
    private readonly MapPathFinder _pathFinder = new(memorySpaceMap);

    public int FindBlockingPointIndex(Point[] byteFallPositions)
    {
        // Binary search for position where the path is becomes blocked.
        int left = 1;
        int right = byteFallPositions.Length;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (MiniumStepCount(byteFallPositions.AsSpan()[..mid]) is null)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        int pointIndex = left - 1;
        return pointIndex;
    }

    private int? MiniumStepCount(ReadOnlySpan<Point> fallingBytePositions)
    {
        _memorySpaceMap.Clear();
        _memorySpaceMap.FallBytes(fallingBytePositions);
        return _pathFinder.FindShortestPath(_start, _end);
    }
}
