using AdventOfCode.Common;
using AdventOfCode.Year2024.Day20.Puzzle;

namespace AdventOfCode.Year2024.Day20;

public sealed class Day20Solver : DaySolver<Day20SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 20;
    public override string Title => "Race Condition";

    private readonly TrackMap _map;
    private TrackCheatEngine? _cheatEngine;

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

    private TrackCheatEngine CreateCheatEngine()
    {
        var traverser = new TrackMapTraverser(_map);
        var distances = traverser.BuildDistanceMap();
        return new(_map, distances);
    }

    public override string SolvePart1()
    {
        _cheatEngine ??= CreateCheatEngine();
        int cheatCount = _cheatEngine
            .FindCheats(Options.PartOneMaxCheatDistance)
            .Count(c => c.TimeSaved >= Options.PartOneMinPicosecondsSaved);
        return cheatCount.ToString();
    }

    public override string SolvePart2()
    {
        _cheatEngine ??= CreateCheatEngine();
        int cheatCount = _cheatEngine
            .FindCheats(Options.PartTwoMaxCheatDistance)
            .Count(c => c.TimeSaved >= Options.PartTwoMinPicosecondsSaved);
        return cheatCount.ToString();
    }
}
