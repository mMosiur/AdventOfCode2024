using AdventOfCode.Common;
using AdventOfCode.Year2024.Day18.Puzzle;

namespace AdventOfCode.Year2024.Day18;

public sealed class Day18Solver : DaySolver<Day18SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 18;
    public override string Title => "RAM Run";

    private readonly IReadOnlyList<Point> _points;

    public Day18Solver(Day18SolverOptions options) : base(options)
    {
        _points = InputReader.Read(InputLines, options);
    }

    public Day18Solver(Action<Day18SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day18Solver() : this(new Day18SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var memorySpaceMap = new MemorySpaceMap(Options.MemorySpaceHeight, Options.MemorySpaceWidth);
        memorySpaceMap.FallBytes(_points.Take(Options.PartOneFallingByteCount));
        var pathFinder = new MapPathFinder(memorySpaceMap);
        var start = new Point(0, 0);
        var end = new Point(memorySpaceMap.Width - 1, memorySpaceMap.Height - 1);
        int minimumStepCount = pathFinder.FindShortestPath(start, end);
        return minimumStepCount.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
