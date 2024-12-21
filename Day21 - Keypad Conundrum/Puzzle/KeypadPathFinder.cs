using System.Diagnostics;
using AdventOfCode.Year2024.Day21.Puzzle.Keypads;

namespace AdventOfCode.Year2024.Day21.Puzzle;

internal sealed class KeypadPathFinder(IKeypad keypad)
{
    private readonly IKeypad _keypad = keypad;

    public List<List<DirectionalKeypadButton>> FindShortestPathsWithPress(Point startPosition, Point targetPosition)
    {
        var paths = new List<List<DirectionalKeypadButton>>(1);

        if (targetPosition == startPosition)
        {
            paths.Add([DirectionalKeypadButton.Activate]);
            return paths;
        }

        Vector xVector = new(targetPosition.X - startPosition.X, 0);
        Vector yVector = new(0, targetPosition.Y - startPosition.Y);

        if (xVector == Vector.Zero)
        {
            var path = GetStraightPath(startPosition, yVector, withFinalPress: true);
            paths.AddIfNotNull(path);
        }
        else if (yVector == Vector.Zero)
        {
            var path = GetStraightPath(startPosition, xVector, withFinalPress: true);
            paths.AddIfNotNull(path);
        }
        else
        {
            var path1 = GetPathOfTwoVectors(startPosition, xVector, yVector, withFinalPress: true);
            paths.AddIfNotNull(path1);

            var path2 = GetPathOfTwoVectors(startPosition, yVector, xVector, withFinalPress: true);
            paths.AddIfNotNull(path2);
        }

        return paths;
    }

    private List<DirectionalKeypadButton>? GetStraightPath(Point from, Vector vector, bool withFinalPress = false)
    {
        if (vector.X != 0 && vector.Y != 0)
        {
            throw new ArgumentException("Invalid vector.", nameof(vector));
        }

        var targetPoint = from + vector;
        if (_keypad.GetButton(targetPoint) is KeypadButton.Gap)
        {
            return null;
        }

        int distance = Math.Abs(vector.X + vector.Y);
        var unitVector = vector / distance;
        DirectionalKeypadButton direction = (unitVector.X, unitVector.Y) switch
        {
            (0, 1) => DirectionalKeypadButton.RightArrow,
            (0, -1) => DirectionalKeypadButton.LeftArrow,
            (1, 0) => DirectionalKeypadButton.DownArrow,
            (-1, 0) => DirectionalKeypadButton.UpArrow,
            _ => throw new UnreachableException()
        };

        List<DirectionalKeypadButton> path = new(distance + (withFinalPress ? 1 : 0));
        for (int i = 0; i < distance; i++)
        {
            path.Add(direction);
        }

        if (withFinalPress) path.Add(DirectionalKeypadButton.Activate);

        return path;
    }

    private List<DirectionalKeypadButton>? GetPathOfTwoVectors(Point start, Vector vector1, Vector vector2, bool withFinalPress = false)
    {
        var xPath2 = GetStraightPath(start, vector1, withFinalPress: false);
        if (xPath2 is null) return null;

        var midPoint2 = start + vector1;
        var yPath2 = GetStraightPath(midPoint2, vector2, withFinalPress);
        if (yPath2 is null) return null;

        xPath2.Capacity = xPath2.Count + yPath2.Count;
        xPath2.AddRange(yPath2);
        return xPath2;
    }
}
