using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day15;

public sealed class Day15Solver : DaySolver<Day15SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 15;
    public override string Title => "Warehouse Woes";

    public Day15Solver(Day15SolverOptions options) : base(options)
    {
    }

    public Day15Solver(Action<Day15SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day15Solver() : this(new Day15SolverOptions())
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
