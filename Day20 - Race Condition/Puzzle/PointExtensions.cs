namespace AdventOfCode.Year2024.Day20.Puzzle;

internal static class PointExtensions
{
    public static IEnumerable<Point> GetAllPointsUpToDistance(this Point point, int maxDistance)
    {
        for (int distance = 1; distance <= maxDistance; distance++)
        {
            var edgePoint = point + Vectors.Right * distance;

            while (edgePoint.X > point.X)
            {
                yield return edgePoint;
                edgePoint += Vectors.DownLeft;
            }

            while (edgePoint.Y > point.Y)
            {
                yield return edgePoint;
                edgePoint += Vectors.UpLeft;
            }

            while (edgePoint.X < point.X)
            {
                yield return edgePoint;
                edgePoint += Vectors.UpRight;
            }

            while (edgePoint.Y < point.Y)
            {
                yield return edgePoint;
                edgePoint += Vectors.DownRight;
            }
        }
    }
}
