using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day25;

public sealed class Day25Solver : DaySolver<Day25SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 25;
    public override string Title => "Code Chronicle";

    public Day25Solver(Day25SolverOptions options) : base(options)
    {
    }

    public Day25Solver(Action<Day25SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day25Solver() : this(new Day25SolverOptions())
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
