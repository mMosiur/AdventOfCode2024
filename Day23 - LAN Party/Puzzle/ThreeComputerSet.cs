namespace AdventOfCode.Year2024.Day23.Puzzle;

internal readonly record struct ThreeComputerSet
{
    public Computer Computer1 { get; }
    public Computer Computer2 { get; }
    public Computer Computer3 { get; }

    public ThreeComputerSet(Computer computer1, Computer computer2, Computer computer3)
    {
        Span<Computer> computersSpan = [computer1, computer2, computer3];
        computersSpan.Sort();
        Computer1 = computersSpan[0];
        Computer2 = computersSpan[1];
        Computer3 = computersSpan[2];
    }
}
