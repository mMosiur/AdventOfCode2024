using AdventOfCode.Common;
using AdventOfCode.Year2024.Day05.Puzzle;

namespace AdventOfCode.Year2024.Day05;

public sealed class Day05Solver : DaySolver<Day05SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 5;
    public override string Title => "Print Queue";

    private readonly IReadOnlyList<ManualUpdate> _manualUpdates;
    private readonly ManualUpdateOrderValidator _validator;
    private readonly ManualUpdateSorter _sorter;

    private List<ManualUpdate>? _correctlyOrderedUpdates;
    private List<ManualUpdate>? _incorrectlyOrderedUpdates;

    public Day05Solver(Day05SolverOptions options) : base(options)
    {
        (var pageOrderingRules, _manualUpdates) = InputReader.Read(Input);
        _validator = new(pageOrderingRules);
        _sorter = new(pageOrderingRules);
    }

    public Day05Solver(Action<Day05SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day05Solver() : this(new Day05SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        if (_correctlyOrderedUpdates is null)
        {
            (_correctlyOrderedUpdates, _incorrectlyOrderedUpdates) = _validator.SplitIntoOrderedAndUnordered(_manualUpdates);
        }

        int correctlyOrderedMiddlePageNumbersSum = _correctlyOrderedUpdates.Sum(mu => mu.MiddlePageNumer);

        return correctlyOrderedMiddlePageNumbersSum.ToString();
    }

    public override string SolvePart2()
    {
        if (_incorrectlyOrderedUpdates is null)
        {
            (_correctlyOrderedUpdates, _incorrectlyOrderedUpdates) = _validator.SplitIntoOrderedAndUnordered(_manualUpdates);
        }

        int reorderedMiddlePageNumbersSum = _incorrectlyOrderedUpdates
            .Select<ManualUpdate, ManualUpdate>(iou => _sorter.Reordered(iou))
            .Sum(mu => mu.MiddlePageNumer);

        return reorderedMiddlePageNumbersSum.ToString();
    }
}
