using AdventOfCode.Common;
using AdventOfCode.Year2024.Day13.Puzzle;

namespace AdventOfCode.Year2024.Day13;

public sealed class Day13Solver : DaySolver<Day13SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 13;
    public override string Title => "Claw Contraption";

    private readonly IReadOnlyList<ClawMachine> _clawMachines;

    public Day13Solver(Day13SolverOptions options) : base(options)
    {
        _clawMachines = InputReader.Read(Input);
    }

    public Day13Solver(Action<Day13SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day13Solver() : this(new Day13SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var solver = new ClawMachineEquationSolver(Options.ButtonATokenCost, Options.ButtonBTokenCost);
        long totalTokenCost = _clawMachines
            .Select(clawMachine => solver.CalculateTotalCost(clawMachine))
            .Sum(x => x?.TokenCost ?? 0);

        return totalTokenCost.ToString();
    }

    public override string SolvePart2()
    {
        var solver = new ClawMachineEquationSolver(Options.ButtonATokenCost, Options.ButtonBTokenCost);
        var prizeErrorCorrectionVector = new Vector(Options.PricePositionError, Options.PricePositionError);
        long totalTokenCost = _clawMachines
            .Select(cm => CorrectBy(cm, prizeErrorCorrectionVector))
            .Select(cm => solver.CalculateTotalCost(cm))
            .Sum(tc => tc?.TokenCost ?? 0);

        return totalTokenCost.ToString();
    }

    private static ClawMachine CorrectBy(ClawMachine clawMachine, Vector errorCorrection)
        => clawMachine with
        {
            PrizeLocation = clawMachine.PrizeLocation + errorCorrection
        };
}
