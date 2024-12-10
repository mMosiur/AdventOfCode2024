using System.Collections;

namespace AdventOfCode.Year2024.Day09.Puzzle;

internal sealed class DiskMap(int[] blockLayout) : IReadOnlyList<int>
{
    private readonly int[] _blockLayout = blockLayout;

    public IReadOnlyList<int> BlockLayout => _blockLayout;
    public int Count => _blockLayout.Length;

    public int this[int index] => _blockLayout[index];

    public IEnumerator<int> GetEnumerator() => BlockLayout.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
