namespace AdventOfCode.Year2024.Day23.Puzzle;

internal static class InputReader
{
    public static ComputerConnection[] Read(IEnumerable<string> inputLines)
    {
        return inputLines.Select(ParseConnection).ToArray();
    }

    private static ComputerConnection ParseConnection(string line)
    {
        string[] lineParts = line.Split('-', 2, StringSplitOptions.TrimEntries);
        if (lineParts.Length != 2)
        {
            throw new FormatException($"Invalid connection format: '{line}'");
        }

        if (lineParts.Any(s => s.Any(c => !char.IsAsciiLetter(c))))
        {
            throw new FormatException($"Invalid computer name: '{line}'");
        }

        return new(new(lineParts[0]), new(lineParts[1]));
    }
}
