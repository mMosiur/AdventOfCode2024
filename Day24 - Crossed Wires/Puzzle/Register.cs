using System.Collections;

namespace AdventOfCode.Year2024.Day24.Puzzle;

internal sealed class Register(string name, IEnumerable<Wire> wires) : IEnumerable<Wire>
{
    private readonly Wire[] _wires = wires.ToArray();
    public string Name { get; } = name;

    public IReadOnlyList<Wire> Wires => _wires;

    public long ComputeValue()
    {
        long value = 0;
        for (int i = _wires.Length - 1; i >= 0; i--)
        {
            value = (value << 1) + (_wires[i].Bit ? 1 : 0);
        }

        return value;
    }

    public IEnumerator<Wire> GetEnumerator() => _wires.AsEnumerable().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => _wires.GetEnumerator();
}
