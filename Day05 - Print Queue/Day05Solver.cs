using AdventOfCode.Common;
using AdventOfCode.Year2024.Day05.Puzzle;

namespace AdventOfCode.Year2024.Day05;

public sealed class Day05Solver : DaySolver<Day05SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 5;
    public override string Title => "Print Queue";

    private readonly PageOrderingRules _pageOrderingRules;
    private readonly IReadOnlyList<ManualUpdate> _manualUpdates;

    public Day05Solver(Day05SolverOptions options) : base(options)
    {
        (_pageOrderingRules, _manualUpdates) = InputReader.Read(Input);
    }

    public Day05Solver(Action<Day05SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day05Solver() : this(new Day05SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var validator = new UpdateOrderValidator(_pageOrderingRules);
        int result = validator.FilterCorrectlyOrderedUpdates(_manualUpdates)
            .Select(mu => mu.PageNumbers[mu.PageNumbers.Count / 2])
            .Sum();
        return result.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
