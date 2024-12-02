namespace AdventOfCode.Year2024.Day02.Puzzle;

internal sealed class ReportChecker(int minAbsSafeDifference, int maxAbsSafeDifference)
{
    private readonly int _minAbsSafeDifference = minAbsSafeDifference;
    private readonly int _maxAbsSafeDifference = maxAbsSafeDifference;

    public bool IsSafe(Report report, bool allowSingleUnsafeLevel = false)
    {
        Span<int> reportLevels = stackalloc int[report.Levels.Count];
        report.Levels.CopyTo(reportLevels);

        if (FindUnsafeLevelIndex(reportLevels) is not { } unsafeLevelIndex)
        {
            return true;
        }

        if (!allowSingleUnsafeLevel) return false;

        return IsSafeWithoutLevelOnIndex(reportLevels, unsafeLevelIndex)
            || IsSafeWithoutLevelOnIndex(reportLevels, unsafeLevelIndex - 1)
            || IsSafeWithoutLevelOnIndex(reportLevels, 0);
    }

    private int? FindUnsafeLevelIndex(ReadOnlySpan<int> reportLevels)
    {
        if (reportLevels.Length < 2) return null;

        int levelSequenceSign = Math.Sign(reportLevels[1] - reportLevels[0]);

        for (int i = 1; i < reportLevels.Length; i++)
        {
            int previousLevel = reportLevels[i - 1];
            int currentLevel = reportLevels[i];
            int difference = currentLevel - previousLevel;

            int differenceSign = Math.Sign(difference);
            if (differenceSign != levelSequenceSign) return i;

            int absDifference = Math.Abs(difference);
            if (absDifference < _minAbsSafeDifference || absDifference > _maxAbsSafeDifference) return i;
        }

        return null;
    }

    private bool IsSafeWithoutLevelOnIndex(ReadOnlySpan<int> reportLevels, int index)
    {
        Span<int> reportLevelsWithoutLevel = stackalloc int[reportLevels.Length - 1];
        reportLevels[..index].CopyTo(reportLevelsWithoutLevel);
        reportLevels[(index + 1)..].CopyTo(reportLevelsWithoutLevel[index..]);
        return FindUnsafeLevelIndex(reportLevelsWithoutLevel) is null;
    }
}
