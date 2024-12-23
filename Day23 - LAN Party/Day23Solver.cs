using AdventOfCode.Common;
using AdventOfCode.Year2024.Day23.Puzzle;

namespace AdventOfCode.Year2024.Day23;

public sealed class Day23Solver : DaySolver<Day23SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 23;
    public override string Title => "LAN Party";

    private readonly ConnectionMap _connectionMap;

    public Day23Solver(Day23SolverOptions options) : base(options)
    {
        var computerConnections = InputReader.Read(InputLines);
        _connectionMap = ConnectionMap.Create(computerConnections);
    }

    public Day23Solver(Action<Day23SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day23Solver() : this(new Day23SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var connectionAnalyzer = new ConnectionAnalyzer(_connectionMap);
        var triosWithPrefixedComputer = connectionAnalyzer.FindTriosWithPrefixedComputer(Options.PartOneComputerPrefix);

        return triosWithPrefixedComputer.Count.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
