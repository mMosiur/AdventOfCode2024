using AdventOfCode.Common;
using AdventOfCode.Year2024.Day12.Puzzle;
using AdventOfCode.Year2024.Day12.Puzzle.GardenBuilders;

namespace AdventOfCode.Year2024.Day12;

public sealed class Day12Solver : DaySolver<Day12SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 12;
    public override string Title => "Garden Groups";

    private readonly GardenPlotMap _gardenPlotMap;
    private readonly FencePriceCalculator _fencePriceCalculator;

    public Day12Solver(Day12SolverOptions options) : base(options)
    {
        _gardenPlotMap = InputReader.Read(InputLines);
        _fencePriceCalculator = new();
    }

    public Day12Solver(Action<Day12SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day12Solver() : this(new Day12SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var gardenBuilder = GardenBuilder.CreateFrom(_gardenPlotMap);
        var gardenRegions = gardenBuilder.BuildRegions();

        int totalFencePrice = gardenRegions
            .Sum(region => _fencePriceCalculator.CalculatePriceForRegion(region));

        return totalFencePrice.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
