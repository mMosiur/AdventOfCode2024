using AdventOfCode.Common;
using AdventOfCode.Common.EnumeratorExtensions;

namespace AdventOfCode.Year2024.Day05.Puzzle;

internal static class InputReader
{
    public static (PageOrderingRules, IReadOnlyList<ManualUpdate>) Read(string input)
    {
        try
        {
            var enumerator = input.AsSpan().EnumerateLines();
            enumerator.EnsureMoveToNextNonEmptyLine(skipCurrent: false);

            List<PageOrderingRule> pageOrderingRuleList = [];
            while (!enumerator.Current.IsWhiteSpace())
            {
                var pageOrderingRule = ReadPageOrderingRule(enumerator.Current);
                pageOrderingRuleList.Add(pageOrderingRule);
                enumerator.EnsureMoveNext();
            }

            var pageOrderingRules = new PageOrderingRules(pageOrderingRuleList);
            enumerator.EnsureMoveToNextNonEmptyLine();

            List<ManualUpdate> manualUpdates = [];
            while (!enumerator.Current.IsWhiteSpace())
            {
                var manualUpdate = ReadManualUpdate(enumerator.Current);
                manualUpdates.Add(manualUpdate);
                if (!enumerator.MoveNext())
                {
                    break;
                }
            }

            return (pageOrderingRules, manualUpdates);
        }
        catch (Exception ex)
        {
            throw new InputException("Input was not in the expected format.", ex);
        }
    }

    private static PageOrderingRule ReadPageOrderingRule(ReadOnlySpan<char> inputLine)
    {
        int separatorIndex = inputLine.IndexOf('|');
        if (separatorIndex == -1)
        {
            throw new FormatException("Page ordering rule must consist of two numbers in format '##|##'.");
        }

        try
        {
            int precedingPageNumber = int.Parse(inputLine[..separatorIndex]);
            int followingPageNumber = int.Parse(inputLine[(separatorIndex + 1)..]);

            return new(precedingPageNumber, followingPageNumber);
        }
        catch (FormatException ex)
        {
            throw new FormatException("Page ordering rule must consist of two numbers in format '##|##'.", ex);
        }
    }

    private static ManualUpdate ReadManualUpdate(ReadOnlySpan<char> inputLine)
    {
        List<int> pageNumbers = new(inputLine.Count(',') + 1);
        foreach (var partRange in inputLine.Split(','))
        {
            var part = inputLine[partRange].Trim();
            pageNumbers.Add(int.Parse(part));
        }

        return new(pageNumbers);
    }
}
