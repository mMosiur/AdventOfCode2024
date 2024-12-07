namespace AdventOfCode.Year2024.Day07.Puzzle;

internal sealed class Equation(long result, IEnumerable<long> numbers)
{
    public long Result { get; } = result;
    public long[] Numbers { get; } = numbers.ToArray();

    public static Equation Parse(string line)
    {
        string[] parts = line.Split(":");
        long result = long.Parse(parts[0]);
        var numbers = parts[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse);
        return new(result, numbers);
    }
}
