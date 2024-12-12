using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day12;

public sealed class Day12Solver : DaySolver<Day12SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 12;
    public override string Title => "Garden Groups";

    public Day12Solver(Day12SolverOptions options) : base(options)
    {
    }

    public Day12Solver(Action<Day12SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day12Solver() : this(new Day12SolverOptions())
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
