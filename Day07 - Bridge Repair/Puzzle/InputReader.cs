namespace AdventOfCode.Year2024.Day07.Puzzle;

internal static class InputReader
{
    public static List<Equation> Read(IEnumerable<string> inputLines)
    {
        return inputLines
            .Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(Equation.Parse)
            .ToList();
    }
}
