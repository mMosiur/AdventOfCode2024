namespace AdventOfCode.Year2024.Day20.Puzzle;

internal sealed class TrackCheatEngine(TrackMap trackMap, Dictionary<Point, int> distanceMap)
{
    private readonly TrackMap _trackMap = trackMap;
    private readonly Dictionary<Point, int> _distanceMap = distanceMap;

    public IEnumerable<Cheat> FindCheats()
    {
        int targetDistance = _distanceMap[_trackMap.EndPoint];
        var path = BuildPath();

        foreach (var point in path)
        {
            int distance = _distanceMap[point];
            foreach (var direction in Vectors.Directions)
            {
                var adjacentPoint = point + direction;
                var twoStepsPoint = adjacentPoint + direction;
                if (!_trackMap.CheckSpotIs(adjacentPoint, TrackSpot.Wall) ||
                    !_trackMap.CheckSpotIs(twoStepsPoint, TrackSpot.Empty)) continue;

                int twoStepsDistance = _distanceMap[twoStepsPoint];
                int cheatDistance = twoStepsDistance + 2;
                int timeSaved = distance - cheatDistance;
                if (timeSaved > 0)
                {
                    yield return new(StartPoint: point, EndPoint: twoStepsPoint, TimeSaved: timeSaved);
                }
            }
        }
    }

    private List<Point> BuildPath()
    {
        int startDistance = _distanceMap[_trackMap.StartPoint];
        var path = new List<Point>(startDistance + 1)
        {
            _trackMap.StartPoint
        };

        while (path.Count <= startDistance)
        {
            var currentPoint = path[^1];
            int currentDistance = _distanceMap[currentPoint];

            foreach (var direction in Vectors.Directions.AsSpan())
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
