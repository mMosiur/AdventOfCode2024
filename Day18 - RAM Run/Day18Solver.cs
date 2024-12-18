using AdventOfCode.Common;
using AdventOfCode.Year2024.Day18.Puzzle;

namespace AdventOfCode.Year2024.Day18;

public sealed class Day18Solver : DaySolver<Day18SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 18;
    public override string Title => "RAM Run";

    private readonly Point[] _points;
    private readonly MemorySpaceMap _memorySpaceMap;
    private readonly Point _start;
    private readonly Point _end;

    public Day18Solver(Day18SolverOptions options) : base(options)
    {
        _points = InputReader.Read(InputLines, options);
        _memorySpaceMap = new(options.MemorySpaceHeight, options.MemorySpaceWidth);

        _start = new(0, 0);
        _end = new(_memorySpaceMap.Width - 1, _memorySpaceMap.Height - 1);
    }

    public Day18Solver(Action<Day18SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day18Solver() : this(new Day18SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        _memorySpaceMap.Clear();
        _memorySpaceMap.FallBytes(_points.AsSpan()[..Options.PartOneFallingByteCount]);

        var pathFinder = new MapPathFinder(_memorySpaceMap);
        int minimumStepCount = pathFinder.FindShortestPath(_start, _end)
                            ?? throw new DaySolverException("No path found from start to end.");

        return minimumStepCount.ToString();
    }

    public override string SolvePart2()
    {
        var blockingPointFinder = new BlockingPointFinder(_memorySpaceMap, _start, _end);
        int blockingPointIndex = blockingPointFinder.FindBlockingPointIndex(_points);

        var blockingPoint = _points[blockingPointIndex];
        return $"{blockingPoint.X},{blockingPoint.Y}";
    }
}
