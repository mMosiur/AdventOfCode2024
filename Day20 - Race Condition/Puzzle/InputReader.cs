using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day20.Puzzle;

internal static class InputReader
{
    public static TrackMap Read(IEnumerable<string> inputLines)
    {
        string[] inputArray = inputLines.ToArray();
        if (inputArray.Length == 0)
        {
            throw new InputException("Input is empty");
        }

        int height = inputArray.Length;
        int width = inputArray[0].Length;
        if (inputArray.Any(line => line.Length != width))
        {
            throw new InputException("All lines must have the same length");
        }

        var track = new TrackSpot[height, width];
        Point? startPoint = null;
        Point? endPoint = null;
        for (int y = 0; y < height; y++)
        {
            string line = inputArray[y];
            for (int x = 0; x < width; x++)
            {
                char c = line[x];
                track[y, x] = ReadMapSpot(y, x, c, ref startPoint, ref endPoint);
            }
        }

        if (!startPoint.HasValue) throw new InputException("No start point found");
        if (!endPoint.HasValue) throw new InputException("No end point found");

        return new(track, startPoint.Value, endPoint.Value);
    }

    private static TrackSpot ReadMapSpot(int y, int x, char c, ref Point? startPoint, ref Point? endPoint)
    {
        TrackSpot spot;
        switch (c)
        {
            case '.':
                spot = TrackSpot.Empty;
                break;
            case '#':
                spot = TrackSpot.Wall;
                break;
            case 'S':
                spot = TrackSpot.Empty;
                if (startPoint.HasValue) throw new InputException("Multiple start points");
                startPoint = new Point(x, y);
                break;
            case 'E':
                spot = TrackSpot.Empty;
                if (endPoint.HasValue) throw new InputException("Multiple end points");
                endPoint = new Point(x, y);
                break;
            default:
                throw new InputException($"Invalid character '{c}' at ({x}, {y})");
        }

        return spot;
    }
}
