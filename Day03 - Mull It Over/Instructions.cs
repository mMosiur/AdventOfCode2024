namespace AdventOfCode.Year2024.Day03;

internal static class Instructions
{
    internal readonly record struct Mul(int Num1, int Num2)
    {
        public int Result => Num1 * Num2;
    }
}
