using AdventOfCode.Common;
using AdventOfCode.Year2024.Day20.Puzzle;

namespace AdventOfCode.Year2024.Day20;

public sealed class Day20Solver : DaySolver<Day20SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 20;
    public override string Title => "Race Condition";

    private readonly TrackMap _map;

    public Day20Solver(Day20SolverOptions options) : base(options)
    {
        _map = InputReader.Read(InputLines);
    }

    public Day20Solver(Action<Day20SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day20Solver() : this(new Day20SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var traverser = new TrackMapTraverser(_map);
        var distances = traverser.BuildDistanceMap();
        var cheatEngine = new TrackCheatEngine(_map, distances);
        int cheatCount = cheatEngine
            .FindCheats()
            .Count(c => c.TimeSaved >= Options.MinPicosecondsSaved);
        return cheatCount.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
