using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day10;

public sealed class Day10Solver : DaySolver<Day10SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 10;
    public override string Title => "Hoof It";

    public Day10Solver(Day10SolverOptions options) : base(options)
    {
    }

    public Day10Solver(Action<Day10SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day10Solver() : this(new Day10SolverOptions())
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
