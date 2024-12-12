using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day12.Puzzle;

internal static class InputReader
{
    public static GardenPlotMap Read(IEnumerable<string> inputLines)
    {
        string[] inputLinesArray = inputLines.ToArray();
        if (inputLinesArray.Length == 0)
        {
            throw new InputException("Input is empty.");
        }

        int height = inputLinesArray.Length;
        int width = inputLinesArray[0].Length;

        if (inputLinesArray.Any(line => line.Length != width))
        {
            throw new InputException("Input lines have different lengths.");
        }

        var plotMap = new PlantType[height, width];

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                plotMap[row, col] = new(inputLinesArray[row][col]);
            }
        }

        return new(plotMap);
    }
}
