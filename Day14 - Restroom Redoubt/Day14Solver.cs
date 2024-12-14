using AdventOfCode.Common;
using AdventOfCode.Year2024.Day14.Puzzle;

namespace AdventOfCode.Year2024.Day14;

public sealed class Day14Solver : DaySolver<Day14SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 14;
    public override string Title => "Restroom Redoubt";

    private readonly Bounds _bounds;
    private readonly IReadOnlyList<Robot> _robots;

    public Day14Solver(Day14SolverOptions options) : base(options)
    {
        _bounds = new(0, options.BathroomWidth - 1, 0, options.BathroomHeight - 1);
        _robots = InputReader.Read(Input);
    }

    public Day14Solver(Action<Day14SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day14Solver() : this(new Day14SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var bathroom = new Bathroom(_bounds, _robots);
        bathroom.SimulateSeconds(100);
        int safetyFactor = bathroom.SafetyFactor();
        return safetyFactor.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
