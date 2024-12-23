using AdventOfCode.Common;
using AdventOfCode.Year2024.Day23.Puzzle;

namespace AdventOfCode.Year2024.Day23;

public sealed class Day23Solver : DaySolver<Day23SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 23;
    public override string Title => "LAN Party";

    private readonly ConnectionAnalyzer _connectionAnalyzer;
    private HashSet<ThreeComputerSet>? _interconnectedTrios;

    public Day23Solver(Day23SolverOptions options) : base(options)
    {
        var computerConnections = InputReader.Read(InputLines);
        var connectionMap = ConnectionMap.Create(computerConnections);
        _connectionAnalyzer = new(connectionMap);
    }

    public Day23Solver(Action<Day23SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day23Solver() : this(new Day23SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        _interconnectedTrios ??= _connectionAnalyzer.FindInterconnectedTrios();

        int triosWithPrefixedComputerCount = _interconnectedTrios
            .Count(t => t.Any(c => c.Name.StartsWith(Options.PartOneComputerPrefix)));

        return triosWithPrefixedComputerCount.ToString();
    }

    public override string SolvePart2()
    {
        _interconnectedTrios ??= _connectionAnalyzer.FindInterconnectedTrios();

        var biggestClique = _interconnectedTrios
            .Select(trio => _connectionAnalyzer.ExpandTrioIntoClique(trio))
            .MaxBy(clique => clique.Count)!;

        string password = string.Join(",", biggestClique.Set.Select(c => c.Name).Order());

        return password;
    }
}
