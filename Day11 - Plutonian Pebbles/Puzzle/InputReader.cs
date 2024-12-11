namespace AdventOfCode.Year2024.Day11.Puzzle;

internal static class InputReader
{
    public static IReadOnlyCollection<Stone> Read(ReadOnlySpan<char> input)
    {
        input = input.Trim();
        List<Stone> initialStoned = new(input.Count(' ') + 1);
        foreach (var linePartRange in input.Split(' '))
        {
            var linePart = input[linePartRange];
            initialStoned.Add(new(int.Parse(linePart)));
        }

        return initialStoned;
    }
}
