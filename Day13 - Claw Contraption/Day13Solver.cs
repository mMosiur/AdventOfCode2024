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
        var optimizer = new ClawMachineButtonOptimizer(Options.ButtonATokenCost, Options.ButtonBTokenCost);
        int totalTokenCost = 0;
        foreach (var clawMachine in _clawMachines)
        {
            if (optimizer.TryOptimizeClicks(clawMachine, out var bestClicks))
            {
                totalTokenCost += bestClicks.TokenCost;
            }
        }

        return totalTokenCost.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
