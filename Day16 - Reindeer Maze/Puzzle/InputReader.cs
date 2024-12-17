using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day16.Puzzle;

internal static class InputReader
{
    public static (MazeMap Map, Point StartPosition, Point EndPosition) Read(IEnumerable<string> inputLines)
    {
        string[] inputArray = inputLines.ToArray();
        if (inputArray.Length == 0)
        {
            throw new InputException("Input is empty");
        }

        int height = inputArray.Length;
        int width = inputArray[0].Length;
        if (inputArray.Any(l => l.Length != width))
        {
            throw new InputException("Input is not a rectangle");
        }

        var map = new TileType[height, width];
        Point? startPosition = null;
        Point? endPosition = null;

        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                char c = inputArray[x][y];
                switch (c)
                {
                    case '.':
                        map[x, y] = TileType.Empty;
                        break;
                    case '#':
                        map[x, y] = TileType.Wall;
                        break;
                    case 'S':
                        map[x, y] = TileType.Empty;
                        if (startPosition is not null) throw new InputException("Multiple start positions");
                        startPosition = new Point(x, y);
                        break;
                    case 'E':
                        map[x, y] = TileType.Empty;
                        if (endPosition is not null) throw new InputException("Multiple end positions");
                        endPosition = new Point(x, y);
                        break;
                    default:
                        throw new InputException($"Unknown character '{c}' at ({x}, {y})");
                }
            }
        }

        if (startPosition is null) throw new InputException("No start position");
        if (endPosition is null) throw new InputException("No end position");

        return (new MazeMap(map), startPosition.Value, endPosition.Value);
    }
}
