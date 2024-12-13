namespace AdventOfCode.Year2024.Day13.Puzzle;

internal sealed class ClawMachineEquationSolver(int buttonATokenCost, int buttonBTokenCost)
{
    private readonly int _buttonATokenCost = buttonATokenCost;
    private readonly int _buttonBTokenCost = buttonBTokenCost;

    // / A*ax + B*bx = px      * bx
    // \ A*ay + B*by = py      * by
    //
    // / A*ax*by + B*bx*by = px*by      +
    // \ A*ay*bx + B*by*bx = py*bx      -
    //
    // A*ax*by - A*ay*bx = px*by - py*bx
    // A*(ax*by - ay*bx) = px*by - py*bx
    // A = (px*by - py*bx) / (ax*by - ay*bx)
    //
    // A*ax + B*bx = px
    // B*bx = px - A*ax
    // B = (px - A*ax) / bx
    public ClawMachineSolution? CalculateTotalCost(ClawMachine clawMachine)
    {
        ((long ax, long ay), (long bx, long by), (long px, long py)) = clawMachine;

        long aDiv1 = px * by - py * bx;
        long aDiv2 = ax * by - ay * bx;

        long a = Math.DivRem(aDiv1, aDiv2, out long reminder);

        if (reminder != 0)
        {
            // No integer solution
            return null;
        }

        long b = Math.DivRem(px - ax * a, bx, out reminder);

        if (reminder != 0)
        {
            // No integer solution
            return null;
        }

        long tokenCost = a * _buttonATokenCost + b * _buttonBTokenCost;

        return new(a, b, tokenCost);
    }
}

internal readonly record struct ClawMachineSolution(long ButtonAClicks, long ButtonBClicks, long TokenCost);
