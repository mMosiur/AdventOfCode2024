using AdventOfCode.Common;
using AdventOfCode.Year2024.Day02.Puzzle;

namespace AdventOfCode.Year2024.Day02;

public sealed class Day02Solver : DaySolver<Day02SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 2;
    public override string Title => "Red-Nosed Reports";

    private readonly IReadOnlyList<Report> _reports;

    public Day02Solver(Day02SolverOptions options) : base(options)
    {
        _reports = InputReader.Read(Input);
    }

    public Day02Solver(Action<Day02SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day02Solver() : this(new Day02SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var reportChecker = new ReportChecker(Options.MinAbsSafeDifference, Options.MaxAbsSafeDifference);
        int safeReportsCount = _reports.Count(reportChecker.IsSafe);
        return safeReportsCount.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
