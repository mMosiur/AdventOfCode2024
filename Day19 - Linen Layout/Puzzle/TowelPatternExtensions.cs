namespace AdventOfCode.Year2024.Day19.Puzzle;

internal static class TowelPatternExtensions
{
    public static bool Contains(this TowelPattern towelPattern, TowelPattern value)
    {
        var span = towelPattern.AsSpan();
        var valueSpan = value.AsSpan();
        if (valueSpan.Length == 0) return true;
        if (valueSpan.Length > span.Length) return false;

        for (int i = 0; i < span.Length - valueSpan.Length + 1; i++)
        {
            if (span.Slice(i, valueSpan.Length).SequenceEqual(valueSpan))
            {
                return true;
            }
        }

        return false;
    }
}
