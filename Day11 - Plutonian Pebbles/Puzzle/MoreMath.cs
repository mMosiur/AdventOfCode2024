namespace AdventOfCode.Year2024.Day11.Puzzle;

internal static class MoreMath
{
    public static int DigitCount(long number)
    {
        return number == 0 ? 1 : (int)Math.Log10(Math.Abs((double)number)) + 1;
    }
}
