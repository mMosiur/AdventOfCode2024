using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day05;

public sealed class Day05Solver : DaySolver<Day05SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 5;
    public override string Title => "Print Queue";

    public Day05Solver(Day05SolverOptions options) : base(options)
    {
    }

    public Day05Solver(Action<Day05SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day05Solver() : this(new Day05SolverOptions())
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
