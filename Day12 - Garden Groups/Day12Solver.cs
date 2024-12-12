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
    private List<GardenRegion>? _gardenRegions;

    public Day12Solver(Day12SolverOptions options) : base(options)
    {
        _gardenPlotMap = InputReader.Read(InputLines);
    }

    public Day12Solver(Action<Day12SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day12Solver() : this(new Day12SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        if (_gardenRegions is null)
        {
            var gardenBuilder = GardenBuilder.CreateFrom(_gardenPlotMap);
            _gardenRegions = gardenBuilder.BuildRegions();
        }

        var fencePriceCalculator = new FencePriceCalculator(bulkDiscount: false);
        int totalFencePrice = _gardenRegions
            .Sum(region => fencePriceCalculator.CalculatePriceForRegion(region));

        return totalFencePrice.ToString();
    }

    public override string SolvePart2()
    {
        if (_gardenRegions is null)
        {
            var gardenBuilder = GardenBuilder.CreateFrom(_gardenPlotMap);
            _gardenRegions = gardenBuilder.BuildRegions();
        }

        var fencePriceCalculator = new FencePriceCalculator(bulkDiscount: true);
        int totalFencePrice = _gardenRegions
            .Sum(region => fencePriceCalculator.CalculatePriceForRegion(region));

        return totalFencePrice.ToString();
    }
}
