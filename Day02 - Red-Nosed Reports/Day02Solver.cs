using AdventOfCode.Common;
using AdventOfCode.Year2024.Day02.Puzzle;

namespace AdventOfCode.Year2024.Day02;

public sealed class Day02Solver : DaySolver<Day02SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 2;
    public override string Title => "Red-Nosed Reports";

    private readonly IReadOnlyList<Report> _reports;
    private readonly ReportChecker _reportChecker;

    public Day02Solver(Day02SolverOptions options) : base(options)
    {
        _reports = InputReader.Read(Input);
        _reportChecker = new(options.MinAbsSafeDifference, options.MaxAbsSafeDifference);
    }

    public Day02Solver(Action<Day02SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day02Solver() : this(new Day02SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        int safeReportsCount = _reports.Count(r => _reportChecker.IsSafe(r));
        return safeReportsCount.ToString();
    }

    public override string SolvePart2()
    {
        int safeReportsCount = _reports.Count(r => _reportChecker.IsSafe(r, allowSingleUnsafeLevel: true));
        return safeReportsCount.ToString();
    }
}
