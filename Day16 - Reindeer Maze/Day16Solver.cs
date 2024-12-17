using AdventOfCode.Common;
using AdventOfCode.Year2024.Day16.Puzzle;

namespace AdventOfCode.Year2024.Day16;

public sealed class Day16Solver : DaySolver<Day16SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 16;
    public override string Title => "Reindeer Maze";

    private readonly MazeMap _map;
    private readonly Point _startPosition;
    private readonly Vector _startDirection;
    private readonly Point _endPosition;

    public Day16Solver(Day16SolverOptions options) : base(options)
    {
        (_map, _startPosition, _endPosition) = InputReader.Read(InputLines);
        if (!Vectors.TryParse(options.StartingDirectionName, out _startDirection))
        {
            throw new DaySolverException($"Unknown direction '{options.StartingDirectionName}'");
        }
    }

    public Day16Solver(Action<Day16SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day16Solver() : this(new Day16SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var runScorer = new MazeMapRunScorer(_map, _endPosition, Options.ForwardMoveScore, Options.TurnMoveScore);
        int lowestScore = runScorer.FindBestPathScore(_startPosition, _startDirection);
        return lowestScore.ToString();
    }

    public override string SolvePart2()
    {
        var pathFinder = new MazeMapPathFinder(_map, _endPosition, Options.ForwardMoveScore, Options.TurnMoveScore);
        var uniqueBestPathPoints = pathFinder
            .FindAllBestPaths(_startPosition, _startDirection)
            .SelectMany(path => path)
            .ToHashSet();

        int bestPathPointCount = uniqueBestPathPoints.Count;
        return bestPathPointCount.ToString();
    }
}
