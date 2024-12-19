namespace AdventOfCode.Year2024.Day19.Puzzle;

internal sealed class TowelPattern(TowelColor[] colors)
{
    private readonly TowelColor[] _colors = colors;

    public ReadOnlySpan<TowelColor> AsSpan() => _colors.AsSpan();
}
