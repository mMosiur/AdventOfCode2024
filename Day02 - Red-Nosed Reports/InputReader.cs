using AdventOfCode.Common;
using AdventOfCode.Year2024.Day02.Puzzle;

namespace AdventOfCode.Year2024.Day02;

internal static class InputReader
{
    public static List<Report> Read(string input)
    {
        List<Report> reports = new(input.Count(c => c == '\n'));
        foreach (var lineSpan in input.AsSpan().EnumerateLines())
        {
            if (lineSpan.IsWhiteSpace()) continue;
            reports.Add(ParseReport(lineSpan));
        }

        return reports;
    }

    private static Report ParseReport(ReadOnlySpan<char> lineSpan)
    {
        List<int> levels = [];
        foreach (var linePartRange in lineSpan.Split(' '))
        {
            var linePart = lineSpan[linePartRange];
            if (!int.TryParse(linePart, out int level))
            {
                throw new InputException($"Invalid report: '{lineSpan}'");
            }

            levels.Add(level);
        }

        return new(levels);
    }
}
