namespace AdventOfCode.Year2024.Day07.Puzzle.Operations;

internal sealed class AddOperation : IOperation
{
    public long Execute(long a, long b) => a + b;
}
