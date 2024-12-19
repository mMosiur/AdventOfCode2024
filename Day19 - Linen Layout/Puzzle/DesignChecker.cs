namespace AdventOfCode.Year2024.Day19.Puzzle;

internal sealed class DesignChecker(List<TowelPattern> availablePatterns)
{
    private readonly List<TowelPattern> _availablePatterns = availablePatterns;

    public bool CanDesignBeMade(TowelPattern desiredDesign)
    {
        return CanDesignBeMade(desiredDesign.AsSpan());
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
}
