using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day04.Puzzle;

internal static class InputReader
{
    public static WordSearchPuzzle Read(IEnumerable<string> inputLines)
    {
        string[] lines = inputLines.ToArray();
        int width = lines[0].Length;

        if (lines.Any(l => l.Length != width))
        {
            throw new InputException("All lines must have the same length.");
        }

        int height = lines.Length;
        char[,] result = new char[height, width];
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                result[row, col] = lines[row][col];
            }
        }

        return new(result);
    }
}
