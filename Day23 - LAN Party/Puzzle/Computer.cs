namespace AdventOfCode.Year2024.Day23.Puzzle;

internal readonly record struct Computer(string Name) : IComparable<Computer>
{
    public int CompareTo(Computer other)
    {
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}
