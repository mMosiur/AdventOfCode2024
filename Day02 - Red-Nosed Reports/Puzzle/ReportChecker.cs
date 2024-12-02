namespace AdventOfCode.Year2024.Day02.Puzzle;

internal sealed class ReportChecker(int minAbsSafeDifference, int maxAbsSafeDifference)
{
    private readonly int _minAbsSafeDifference = minAbsSafeDifference;
    private readonly int _maxAbsSafeDifference = maxAbsSafeDifference;

    public bool IsSafe(Report report)
    {
        if (report.Levels.Count < 2) return true;

        int levelSequenceSign = Math.Sign(report.Levels[1] - report.Levels[0]);
        for (int i = 1; i < report.Levels.Count; i++)
        {
            int previousLevel = report.Levels[i - 1];
            int currentLevel = report.Levels[i];
            int difference = currentLevel - previousLevel;
            int absDifference = Math.Abs(difference);

            if (Math.Sign(difference) != levelSequenceSign) return false;
            if (absDifference < _minAbsSafeDifference || absDifference > _maxAbsSafeDifference) return false;
        }

        return true;
    }
}
