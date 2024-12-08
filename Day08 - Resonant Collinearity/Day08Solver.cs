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
        var antinodeLocator = new AntinodeLocator();

        var antinodePoints = antinodeLocator.FindAntinodePoints(_antennaMap);
        int result = antinodePoints.Count;

        return result.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
