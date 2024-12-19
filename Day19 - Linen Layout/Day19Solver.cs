using AdventOfCode.Common;
using AdventOfCode.Year2024.Day19.Puzzle;

namespace AdventOfCode.Year2024.Day19;

public sealed class Day19Solver : DaySolver<Day19SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 19;
    public override string Title => "Linen Layout";

    private readonly List<TowelPattern> _availablePatterns;
    private readonly List<TowelPattern> _desiredDesigns;

    public Day19Solver(Day19SolverOptions options) : base(options)
    {
        (_availablePatterns, _desiredDesigns) = InputReader.Read(Input);
    }

    public Day19Solver(Action<Day19SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day19Solver() : this(new Day19SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var designChecker = new DesignChecker(_availablePatterns);
        int possibleDesignCount = _desiredDesigns
            .Count(d => designChecker.CanDesignBeMade(d));
        return possibleDesignCount.ToString();
    }

    public override string SolvePart2()
    {
        var designChecker = new DesignChecker(_availablePatterns);
        long uniqueDesignWaysCount = _desiredDesigns
            .Sum(d => designChecker.CountWaysToMakeDesign(d));
        return uniqueDesignWaysCount.ToString();
    }
}
