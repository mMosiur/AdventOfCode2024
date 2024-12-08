using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day08;

public sealed class Day08Solver : DaySolver<Day08SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 8;
    public override string Title => "Resonant Collinearity";

    public Day08Solver(Day08SolverOptions options) : base(options)
    {
    }

    public Day08Solver(Action<Day08SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day08Solver() : this(new Day08SolverOptions())
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
