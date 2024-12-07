using AdventOfCode.Common;
using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day06.Puzzle;

internal static class InputReader
{
    public static (LabMap Map, Point GuardPosition, Direction GuardDirection) Read(IEnumerable<string> inputLines)
    {
        string[] lines = inputLines.ToArray();
        if (lines.Length == 0)
        {
            throw new InputException("Input is empty");
        }

        int height = lines.Length;
        int width = lines[0].Length;

        if (lines.Any(l => l.Length != width))
        {
            throw new InputException("Input lines have different lengths");
        }

        var bounds = new Rectangle<int>(0, height - 1, 0, width - 1);
        var obstaclePositions = new HashSet<Point>();
        Point? guardStartingPosition = null;
        Direction? guardStartingDirection = null;
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                var point = new Point(row, col);
                char c = lines[row][col];

                ReadDataFromMapPoint(point, c, obstaclePositions, ref guardStartingPosition, ref guardStartingDirection);
            }
        }

        if (guardStartingPosition is null || guardStartingDirection is null)
        {
            throw new InputException("Guard was not found in input text");
        }

        var labMap = new LabMap(bounds, obstaclePositions);

        return (labMap, guardStartingPosition.Value, guardStartingDirection.Value);
    }

    private static void ReadDataFromMapPoint(Point point, char c, HashSet<Point> obstaclePositions, ref Point? guardStartingPosition, ref Direction? guardStartingDirection)
    {
        switch (c)
        {
            case '#':
                obstaclePositions.Add(point);
                return;
            case '.':
                // Empty space
                return;
        }

        guardStartingDirection = c switch
        {
            '^' => Direction.Up,
            '>' => Direction.Right,
            'v' => Direction.Down,
            '<' => Direction.Left,
            _ => throw new InputException($"Invalid character '{c}' in input")
        };

        if (guardStartingPosition is not null)
        {
            throw new InputException("Guard was found more than once in input text");
        }

        guardStartingPosition = point;
    }
}
