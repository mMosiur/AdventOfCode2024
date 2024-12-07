namespace AdventOfCode.Year2024.Day07.Puzzle.Operations;

internal sealed class ConcatenateOperation : IOperation
{
    public long Execute(long a, long b)
    {
        int pow = 10;
        while (b >= pow)
        {
            pow *= 10;
        }

        return a * pow + b;
    }
}
