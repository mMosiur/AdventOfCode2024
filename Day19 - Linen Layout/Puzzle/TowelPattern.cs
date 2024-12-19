using System.Text;

namespace AdventOfCode.Year2024.Day19.Puzzle;

internal sealed class TowelPattern(TowelColor[] colors)
{
    private readonly TowelColor[] _colors = colors;

    public ReadOnlySpan<TowelColor> AsSpan() => _colors.AsSpan();

    public static string ColorsToString(ReadOnlySpan<TowelColor> colors)
    {
        var sb = new StringBuilder(colors.Length);
        foreach (var color in colors)
        {
            sb.Append((char)color);
        }

        return sb.ToString();
    }
}
