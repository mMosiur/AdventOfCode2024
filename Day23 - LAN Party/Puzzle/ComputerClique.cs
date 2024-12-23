using System.Collections;

namespace AdventOfCode.Year2024.Day23.Puzzle;

internal sealed class ComputerClique(params IEnumerable<Computer> computers)
    : IReadOnlyCollection<Computer>
{
    private readonly HashSet<Computer> _computers = [.. computers];

    public IReadOnlySet<Computer> Set => _computers; // For optimized set operations
    public int Count => _computers.Count;

    public bool Add(Computer computer)
    {
        return _computers.Add(computer);
    }

    public IEnumerator<Computer> GetEnumerator() => _computers.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
