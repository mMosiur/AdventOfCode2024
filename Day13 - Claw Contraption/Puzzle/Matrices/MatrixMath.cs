namespace AdventOfCode.Year2024.Day13.Puzzle.Matrices;

internal static class MatrixMath
{
    public static ColumnVector2 DotMultiply(Matrix2X2 m, ColumnVector2 v)
    {
        return new(
            m.A11 * v.X1 + m.A12 * v.X2,
            m.A21 * v.X1 + m.A22 * v.X2
        );
    }

    public static double Determinant(Matrix2X2 m)
    {
        return m.A11 * m.A22 - m.A12 * m.A21;
    }

    public static Matrix2X2 Inverse(Matrix2X2 m)
    {
        double invDet = 1.0 / Determinant(m);
        return new(
            m.A22 * invDet,
            -m.A12 * invDet,
            -m.A21 * invDet,
            m.A11 * invDet
        );
    }
}
