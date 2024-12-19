using AdventOfCode.Common;
using AdventOfCode.Common.EnumeratorExtensions;

namespace AdventOfCode.Year2024.Day19.Puzzle;

internal static class InputReader
{
    public static (List<TowelPattern> AvailablePatterns, List<TowelPattern> DesiredDesigns) Read(string input)
    {
        var it = input.AsSpan().EnumerateLines();

        it.EnsureMoveNext();
        var availablePatterns = ReadAvailableTowelPatterns(it.Current);

        it.EnsureMoveToNextNonEmptyLine();
        List<TowelPattern> desiredDesigns = [];
        while (!it.Current.IsWhiteSpace())
        {
            desiredDesigns.Add(ReadDesiredTowelDesign(it.Current));
            if (!it.MoveNext()) break;
        }

        if (it.MoveToNextNonEmptyLine())
        {
            throw new InputException("Input contains unrecognized lines of data");
        }

        return (availablePatterns, desiredDesigns);
    }

    private static List<TowelPattern> ReadAvailableTowelPatterns(ReadOnlySpan<char> line)
    {
        List<TowelPattern> availablePatterns = [];
        foreach (Range splitRange in line.Split(','))
        {
            var patternSpan = line[splitRange].Trim();
            var pattern = ReadTowelPattern(patternSpan);
            availablePatterns.Add(pattern);
        }

        return availablePatterns;
    }

    private static TowelPattern ReadDesiredTowelDesign(ReadOnlySpan<char> line)
    {
        return ReadTowelPattern(line);
    }

    private static TowelPattern ReadTowelPattern(ReadOnlySpan<char> span)
    {
        var pattern = new TowelColor[span.Length];
        for (int i = 0; i < pattern.Length; i++)
        {
            TowelColor towelColor = (TowelColor)span[i];
            if (!Enum.IsDefined(towelColor)) throw new InputException($"Unrecognized towel color '{span[i]}'");
            pattern[i] = towelColor;
        }

        return new(pattern);
    }
}
