using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day18;

public sealed class Day18Solver : DaySolver<Day18SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 18;
    public override string Title => "RAM Run";

    public Day18Solver(Day18SolverOptions options) : base(options)
    {
    }

    public Day18Solver(Action<Day18SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day18Solver() : this(new Day18SolverOptions())
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
