namespace AdventOfCode.Year2024.Day13.Puzzle.Matrices;

internal readonly record struct ColumnVector2(double X1, double X2)
{
    public bool IsInteger => double.IsInteger(X1) && double.IsInteger(X2);
}
