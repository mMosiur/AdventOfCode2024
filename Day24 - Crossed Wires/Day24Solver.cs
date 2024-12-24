using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day24;

public sealed class Day24Solver : DaySolver<Day24SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 24;
    public override string Title => "Crossed Wires";

    public Day24Solver(Day24SolverOptions options) : base(options)
    {
    }

    public Day24Solver(Action<Day24SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day24Solver() : this(new Day24SolverOptions())
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
