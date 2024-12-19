namespace AdventOfCode.Year2024.Day19.Puzzle;

internal sealed class DesignChecker(List<TowelPattern> availablePatterns)
{
    private readonly List<TowelPattern> _availablePatterns = availablePatterns;
    private readonly Dictionary<string, long> _designWaysCountCache = new();

    public bool CanDesignBeMade(TowelPattern desiredDesign)
    {
        return CanDesignBeMade(desiredDesign.AsSpan());
    }

    public long CountWaysToMakeDesign(TowelPattern desiredDesign)
    {
        var usablePatterns = _availablePatterns.Where(desiredDesign.Contains).ToArray();
        return CountWaysToMakeDesign(desiredDesign.AsSpan(), usablePatterns);
    }

    private bool CanDesignBeMade(ReadOnlySpan<TowelColor> desiredDesign)
    {
        if (desiredDesign.Length == 0)
        {
            return true;
        }

        foreach (var pattern in _availablePatterns)
        {
            var patternSpan = pattern.AsSpan();
            if (desiredDesign.Length < patternSpan.Length) continue;
            if (!desiredDesign[..patternSpan.Length].SequenceEqual(patternSpan)) continue;

            if (CanDesignBeMade(desiredDesign[patternSpan.Length..]))
            {
                return true;
            }
        }

        return false;
    }

    private long CountWaysToMakeDesign(ReadOnlySpan<TowelColor> desiredDesign, TowelPattern[] usablePatterns)
    {
        if (desiredDesign.Length == 0)
        {
            return 1;
        }

        string designKey = TowelPattern.ColorsToString(desiredDesign);
        if (_designWaysCountCache.TryGetValue(designKey, out long cachedCount))
        {
            return cachedCount;
        }

        long count = 0;
        foreach (var pattern in usablePatterns)
        {
            var patternSpan = pattern.AsSpan();
            if (desiredDesign.Length < patternSpan.Length) continue;
            if (!desiredDesign[..patternSpan.Length].SequenceEqual(patternSpan)) continue;

            count += CountWaysToMakeDesign(desiredDesign[patternSpan.Length..], usablePatterns);
        }

        _designWaysCountCache[designKey] = count;

        return count;
    }
}
