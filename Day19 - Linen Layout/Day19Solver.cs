using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day19;

public sealed class Day19Solver : DaySolver<Day19SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 19;
    public override string Title => "Linen Layout";

    public Day19Solver(Day19SolverOptions options) : base(options)
    {
    }

    public Day19Solver(Action<Day19SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day19Solver() : this(new Day19SolverOptions())
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
