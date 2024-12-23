namespace AdventOfCode.Year2024.Day23.Puzzle;

internal sealed class ComputerConnection(Computer computer1, Computer computer2)
{
    public Computer Computer1 { get; } = computer1;
    public Computer Computer2 { get; } = computer2;
}
