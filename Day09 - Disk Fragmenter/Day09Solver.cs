using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day09;

public sealed class Day09Solver : DaySolver<Day09SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 9;
    public override string Title => "Disk Fragmenter";

    public Day09Solver(Day09SolverOptions options) : base(options)
    {
    }

    public Day09Solver(Action<Day09SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day09Solver() : this(new Day09SolverOptions())
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
