namespace AdventOfCode.Year2024.Day20.Puzzle;

internal sealed class DistanceMap(int?[,] distances)
{
    public int? this[Point point] => distances[point.Y, point.X];

    public bool TryGetValue(Point point, out int distance)
    {
        int? maybeDistance = this[point];
        if (!maybeDistance.HasValue)
        {
            distance = default;
            return false;
        }

        distance = maybeDistance.Value;
        return true;
    }
}
