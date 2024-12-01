using AdventOfCode.Common;
using AdventOfCode.Common.SpanExtensions;

namespace AdventOfCode.Year2024.Day01;

internal static class InputReader
{
    public static (List<int> LeftList, List<int> RightList) Read(string input)
    {
        List<int> list1 = [];
        List<int> list2 = [];
        foreach (var lineSpan in input.AsSpan().EnumerateLines())
        {
            if (lineSpan.IsWhiteSpace()) continue;

            if (!lineSpan.TrySplitInTwo(' ', out var linePart1, out var linePart2, allowMultipleSeparators: true))
            {
                throw new InputException("Invalid input");
            }

            list1.Add(int.Parse(linePart1.Trim()));
            list2.Add(int.Parse(linePart2.Trim()));
        }

        return (list1, list2);
    }
}
