using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day04;

public sealed class Day04Solver : DaySolver<Day04SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 4;
    public override string Title => "Ceres Search";

    public Day04Solver(Day04SolverOptions options) : base(options)
    {
    }

    public Day04Solver(Action<Day04SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day04Solver() : this(new Day04SolverOptions())
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