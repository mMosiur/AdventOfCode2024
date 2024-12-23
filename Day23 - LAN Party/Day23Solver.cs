using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day23;

public sealed class Day23Solver : DaySolver<Day23SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 23;
    public override string Title => "LAN Party";

    public Day23Solver(Day23SolverOptions options) : base(options)
    {
    }

    public Day23Solver(Action<Day23SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day23Solver() : this(new Day23SolverOptions())
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
