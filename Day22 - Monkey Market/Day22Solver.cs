using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day22;

public sealed class Day22Solver : DaySolver<Day22SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 22;
    public override string Title => "Monkey Market";

    public Day22Solver(Day22SolverOptions options) : base(options)
    {
    }

    public Day22Solver(Action<Day22SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day22Solver() : this(new Day22SolverOptions())
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
