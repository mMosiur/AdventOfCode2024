using System.Collections;
using System.Diagnostics.CodeAnalysis;
using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day08.Puzzle;

internal sealed class AntennaMap(Rectangle<int> bounds, Dictionary<Antenna, List<GridPoint>> dictionary)
    : IEnumerable<KeyValuePair<Antenna, List<GridPoint>>>
{
    private readonly Dictionary<Antenna, List<GridPoint>> _dictionary = dictionary;
    public Rectangle<int> Bounds { get; } = bounds;

    public List<GridPoint> this[Antenna antenna] => _dictionary[antenna];

    public bool TryGetValue(Antenna antenna, [NotNullWhen(true)] out List<GridPoint>? points) => _dictionary.TryGetValue(antenna, out points);

    public IEnumerator<KeyValuePair<Antenna, List<GridPoint>>> GetEnumerator() => _dictionary.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
