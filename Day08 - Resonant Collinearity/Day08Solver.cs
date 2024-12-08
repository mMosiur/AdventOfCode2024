using AdventOfCode.Common;
using AdventOfCode.Year2024.Day08.Puzzle;
using AdventOfCode.Year2024.Day08.Puzzle.Extensions;

namespace AdventOfCode.Year2024.Day08;

public sealed class Day08Solver : DaySolver<Day08SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 8;
    public override string Title => "Resonant Collinearity";

    private readonly AntennaMap _antennaMap;

    public Day08Solver(Day08SolverOptions options) : base(options)
    {
        _antennaMap = InputReader.Read(InputLines);
    }

    public Day08Solver(Action<Day08SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day08Solver() : this(new Day08SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        HashSet<GridPoint> antinodePoints = new();

        foreach (var (antenna, points) in _antennaMap)
        {
            if (points.Count <= 1) continue;

            foreach (var (point1, point2) in points.UniquePairs())
            {
                var vector = new GridVector(point1, point2).AsPreciseVector();

                var potentialAntinode1 = point1.AsPrecisePoint() - vector;
                if (potentialAntinode1.IsOnGrid() && _antennaMap.Bounds.Contains(potentialAntinode1.AsGridPoint()))
                {
                    antinodePoints.Add(potentialAntinode1.AsGridPoint());
                }

                var potentialAntinode2 = point2.AsPrecisePoint() + vector;
                if (potentialAntinode2.IsOnGrid() && _antennaMap.Bounds.Contains(potentialAntinode2.AsGridPoint()))
                {
                    antinodePoints.Add(potentialAntinode2.AsGridPoint());
                }
            }
        }

        var testNodes = antinodePoints.OrderBy(p => (p.X, p.Y)).ToList();

        return antinodePoints.Count.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
