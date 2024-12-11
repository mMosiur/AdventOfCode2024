using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day11;

public sealed class Day11Solver : DaySolver<Day11SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 11;
    public override string Title => "Plutonian Pebbles";

    public Day11Solver(Day11SolverOptions options) : base(options)
    {
    }

    public Day11Solver(Action<Day11SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day11Solver() : this(new Day11SolverOptions())
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
