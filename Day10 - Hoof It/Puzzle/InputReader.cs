namespace AdventOfCode.Year2024.Day10.Puzzle;

internal static class InputReader
{
    public static TopographicMap Read(IEnumerable<string> inputLines)
    {
        string[] lines = inputLines.ToArray();
        int[,] elevations = new int[lines.Length, lines[0].Length];

        for (int x = 0; x < lines.Length; x++)
        {
            for (int y = 0; y < lines[x].Length; y++)
            {
                elevations[x, y] = (int)char.GetNumericValue(lines[x][y]);
            }
        }

        return new(elevations);
    }
}
