namespace AdventOfCode.Year2024.Day05.Puzzle;

internal sealed class ManualUpdate(List<int> pageNumbers)
{
    public IReadOnlyList<int> PageNumbers { get; } = pageNumbers;
}
