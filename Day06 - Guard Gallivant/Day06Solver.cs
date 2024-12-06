using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day06;

public sealed class Day06Solver : DaySolver<Day06SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 6;
    public override string Title => "Guard Gallivant";

    public Day06Solver(Day06SolverOptions options) : base(options)
    {
    }

    public Day06Solver(Action<Day06SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day06Solver() : this(new Day06SolverOptions())
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
