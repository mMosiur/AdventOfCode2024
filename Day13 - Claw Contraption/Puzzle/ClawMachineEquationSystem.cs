using AdventOfCode.Year2024.Day13.Puzzle.Matrices;

namespace AdventOfCode.Year2024.Day13.Puzzle;

internal readonly record struct ClawMachineEquationSystem(
    Matrix2X2 Parameters,
    ColumnVector2 Solution
)
{
    public static ClawMachineEquationSystem Create(ClawMachine clawMachine)
    {
        return new(
            Parameters: new(
                clawMachine.ButtonAMovement.X,
                clawMachine.ButtonBMovement.X,
                clawMachine.ButtonAMovement.Y,
                clawMachine.ButtonBMovement.Y
            ),
            Solution: new(clawMachine.PrizeLocation.X, clawMachine.PrizeLocation.Y)
        );
    }

    public ColumnVector2 CalculateClickCountVector()
    {
        var inverse = MatrixMath.Inverse(Parameters);
        var result = MatrixMath.DotMultiply(inverse, Solution);
        return new(
            double.Round(result.X1, 10),
            double.Round(result.X2, 10)
        );
    }
}
