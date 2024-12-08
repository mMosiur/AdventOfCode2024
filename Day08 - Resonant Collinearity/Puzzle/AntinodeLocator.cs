using AdventOfCode.Common.Geometry;
using AdventOfCode.Year2024.Day08.Puzzle.Extensions;

namespace AdventOfCode.Year2024.Day08.Puzzle;

internal sealed class AntinodeLocator
{
    public HashSet<GridPoint> FindAntinodePoints(AntennaMap antennaMap)
    {
        HashSet<GridPoint> antinodePoints = new();

        foreach (var (antenna, points) in antennaMap)
        {
            AddAntinodesForAntennaPoints(antinodePoints, points, antennaMap.Bounds);
        }

        return antinodePoints;
    }

    private static void AddAntinodesForAntennaPoints(HashSet<GridPoint> antinodePoints, List<GridPoint> antennaPoints, Rectangle<int> bounds)
    {
        if (antennaPoints.Count <= 1) return;

        foreach (var (point1, point2) in antennaPoints.UniquePairs())
        {
            var vector = new GridVector(point1, point2).AsPreciseVector();

            var potentialAntinode1 = point1.AsPrecisePoint() - vector;
            if (potentialAntinode1.IsOnGrid() && bounds.Contains(potentialAntinode1.AsGridPoint()))
            {
                antinodePoints.Add(potentialAntinode1.AsGridPoint());
            }

            var potentialAntinode2 = point2.AsPrecisePoint() + vector;
            if (potentialAntinode2.IsOnGrid() && bounds.Contains(potentialAntinode2.AsGridPoint()))
            {
                antinodePoints.Add(potentialAntinode2.AsGridPoint());
            }
        }
    }
}
