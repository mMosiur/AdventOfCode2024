using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day20.Puzzle;

internal sealed class TrackCheatEngine(TrackMap trackMap, DistanceMap distanceMap)
{
    private readonly TrackMap _trackMap = trackMap;
    private readonly DistanceMap _distanceMap = distanceMap;

    public IEnumerable<Cheat> FindCheats(int maxDistance)
    {
        var path = BuildPath();

        foreach (var point in path)
        {
            int distanceFromPoint = _distanceMap[point]!.Value;
            foreach (var cheatEndPoint in point.GetAllPointsUpToDistance(maxDistance))
            {
                if (!_trackMap.CheckSpotIs(cheatEndPoint, TrackSpot.Empty)) continue;

                int distanceAtCheatEnd = _distanceMap[cheatEndPoint]!.Value;
                int cheatDistanceFromPoint = distanceAtCheatEnd + MathG.ManhattanDistance(point, cheatEndPoint);
                int timeSaved = distanceFromPoint - cheatDistanceFromPoint;
                if (timeSaved > 0)
                {
                    yield return new(StartPoint: point, EndPoint: cheatEndPoint, TimeSaved: timeSaved);
                }
            }
        }
    }

    private List<Point> BuildPath()
    {
        int startDistance = _distanceMap[_trackMap.StartPoint]!.Value;
        var path = new List<Point>(startDistance + 1)
        {
            _trackMap.StartPoint
        };

        while (path.Count <= startDistance)
        {
            var currentPoint = path[^1];
            int currentDistance = _distanceMap[currentPoint]!.Value;

            foreach (var direction in Vectors.StraightDirections.AsSpan())
            {
                var adjacentPoint = currentPoint + direction;
                if (!_distanceMap.TryGetValue(adjacentPoint, out int adjacentDistance) || adjacentDistance != currentDistance - 1)
                {
                    continue;
                }

                path.Add(adjacentPoint);
                break;
            }
        }

        return path;
    }
}

internal readonly record struct Cheat(Point StartPoint, Point EndPoint, int TimeSaved);
