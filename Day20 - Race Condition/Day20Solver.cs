using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day20;

public sealed class Day20Solver : DaySolver<Day20SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 20;
    public override string Title => "Race Condition";

    public Day20Solver(Day20SolverOptions options) : base(options)
    {
    }

    public Day20Solver(Action<Day20SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day20Solver() : this(new Day20SolverOptions())
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
