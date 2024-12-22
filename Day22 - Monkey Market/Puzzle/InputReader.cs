namespace AdventOfCode.Year2024.Day22.Puzzle;

internal static class InputReader
{
    public static int[] Read(IEnumerable<string> inputLines)
    {
        return inputLines.Select(int.Parse).ToArray();
    }
}
