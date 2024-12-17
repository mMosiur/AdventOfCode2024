using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day17;

public sealed class Day17Solver : DaySolver<Day17SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 17;
    public override string Title => "Chronospatial Computer";

    public Day17Solver(Day17SolverOptions options) : base(options)
    {
    }

    public Day17Solver(Action<Day17SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day17Solver() : this(new Day17SolverOptions())
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
