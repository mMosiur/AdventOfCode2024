using System.Collections;
using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day08.Puzzle;

internal sealed class AntennaMap : IEnumerable<KeyValuePair<Antenna, List<GridPoint>>>
{
    private readonly Dictionary<Antenna, List<GridPoint>> _dictionary;
    public Rectangle<int> Bounds { get; }

    public AntennaMap(Rectangle<int> bounds, Dictionary<Antenna, List<GridPoint>> dictionary)
    {
        Bounds = bounds;
        _dictionary = dictionary;
    }

    public IEnumerator<KeyValuePair<Antenna, List<GridPoint>>> GetEnumerator() => _dictionary.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
