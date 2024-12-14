using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day14;

public sealed class Day14Solver : DaySolver<Day14SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 14;
    public override string Title => "Restroom Redoubt";

    public Day14Solver(Day14SolverOptions options) : base(options)
    {
    }

    public Day14Solver(Action<Day14SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day14Solver() : this(new Day14SolverOptions())
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
