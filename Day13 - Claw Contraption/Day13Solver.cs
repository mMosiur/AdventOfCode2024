using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day13;

public sealed class Day13Solver : DaySolver<Day13SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 13;
    public override string Title => "Claw Contraption";

    public Day13Solver(Day13SolverOptions options) : base(options)
    {
    }

    public Day13Solver(Action<Day13SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day13Solver() : this(new Day13SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        return "UNSOLVED";
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
