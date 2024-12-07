using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day07;

public sealed class Day07Solver : DaySolver<Day07SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 7;
    public override string Title => "Bridge Repair";

    public Day07Solver(Day07SolverOptions options) : base(options)
    {
    }

    public Day07Solver(Action<Day07SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day07Solver() : this(new Day07SolverOptions())
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
