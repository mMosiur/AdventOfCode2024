using AdventOfCode.Common;
using AdventOfCode.Year2024.Day10.Puzzle;

namespace AdventOfCode.Year2024.Day10;

public sealed class Day10Solver : DaySolver<Day10SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 10;
    public override string Title => "Hoof It";

    private readonly TopographicMap _map;

    public Day10Solver(Day10SolverOptions options) : base(options)
    {
        _map = InputReader.Read(InputLines);
    }

    public Day10Solver(Action<Day10SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day10Solver() : this(new Day10SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var analyzer = new TrailheadAnalyzer(_map);
        int trailheadScoreSum = analyzer
            .FindTrailheads()
            .Sum(trailhead => analyzer.CalculateTrailheadScore(trailhead));
        return trailheadScoreSum.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
