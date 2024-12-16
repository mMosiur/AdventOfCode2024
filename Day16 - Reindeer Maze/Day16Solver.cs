using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day16;

public sealed class Day16Solver : DaySolver<Day16SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 16;
    public override string Title => "Reindeer Maze";

    public Day16Solver(Day16SolverOptions options) : base(options)
    {
    }

    public Day16Solver(Action<Day16SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day16Solver() : this(new Day16SolverOptions())
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
