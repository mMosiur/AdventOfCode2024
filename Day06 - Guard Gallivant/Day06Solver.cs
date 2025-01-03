using AdventOfCode.Common;
using AdventOfCode.Year2024.Day06.Puzzle;

namespace AdventOfCode.Year2024.Day06;

public sealed class Day06Solver : DaySolver<Day06SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 6;
    public override string Title => "Guard Gallivant";

    private readonly LabMap _labMap;
    private readonly Point _guardPosition;
    private readonly Direction _guardDirection;

    private HashSet<Point>? _guardPathPositions;

    public Day06Solver(Day06SolverOptions options) : base(options)
    {
        (_labMap, _guardPosition, _guardDirection) = InputReader.Read(InputLines);
    }

    public Day06Solver(Action<Day06SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day06Solver() : this(new Day06SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        _guardPathPositions ??= _labMap
            .FollowGuardPath(_guardPosition, _guardDirection)
            .ToHashSet();

        int guardPathDistinctPositionsCount = _guardPathPositions.Count;

        return guardPathDistinctPositionsCount.ToString();
    }

    public override string SolvePart2()
    {
        _guardPathPositions ??= _labMap
            .FollowGuardPath(_guardPosition, _guardDirection)
            .ToHashSet();

        // "The new obstruction can't be placed at the guard's starting position"
        _guardPathPositions.Remove(_guardPosition);

        int infiniteLoopsCount = 0;
        foreach (var guardPathPosition in _guardPathPositions)
        {
            _labMap.AddObstacle(guardPathPosition);

            if (_labMap.IsGuardInfiniteLoop(_guardPosition, _guardDirection))
            {
                infiniteLoopsCount++;
            }

            _labMap.RemoveObstacle(guardPathPosition);
        }

        return infiniteLoopsCount.ToString();
    }
}
