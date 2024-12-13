namespace AdventOfCode.Year2024.Day13.Puzzle;

internal sealed class ClawMachineButtonOptimizer(int buttonATokenCost, int buttonBTokenCost)
{
    private readonly int _buttonATokenCost = buttonATokenCost;
    private readonly int _buttonBTokenCost = buttonBTokenCost;

    public bool TryOptimizeClicks(ClawMachine clawMachine, out ClawMachineButtonClicks bestClicks)
    {
        var equationSystem = ClawMachineEquationSystem.Create(clawMachine);
        var clickCountVector = equationSystem.CalculateClickCountVector();
        if (!clickCountVector.IsInteger)
        {
            bestClicks = default;
            return false;
        }

        int buttonAClicks = (int)clickCountVector.X1;
        int buttonBClicks = (int)clickCountVector.X2;
        int tokenCost = buttonAClicks * _buttonATokenCost + buttonBClicks * _buttonBTokenCost;

        bestClicks = new(
            ButtonAClicks: buttonAClicks,
            ButtonBClicks: buttonBClicks,
            TokenCost: tokenCost
        );
        return true;
    }
}

internal readonly record struct ClawMachineButtonClicks(int ButtonAClicks, int ButtonBClicks, int TokenCost);
