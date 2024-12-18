using AdventOfCode.Common;
using AdventOfCode.Year2024.Day17.Puzzle;

namespace AdventOfCode.Year2024.Day17;

public sealed class Day17Solver : DaySolver<Day17SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 17;
    public override string Title => "Chronospatial Computer";

    private readonly RegisterValues _initialRegisters;
    private readonly IReadOnlyList<byte> _program;
    private readonly Computer _computer;

    public Day17Solver(Day17SolverOptions options) : base(options)
    {
        (_initialRegisters, _program) = InputReader.Read(Input);
        _computer = new();
    }

    public Day17Solver(Action<Day17SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day17Solver() : this(new Day17SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        _computer.Reset(_initialRegisters);
        var outputEnumerable = _computer.RunProgram(_program);
        string finalOutput = string.Join(",", outputEnumerable);
        return finalOutput;
    }

    public override string SolvePart2()
    {
        var quineSearcher = new QuineSearcher(_computer);
        var possibleAValues = quineSearcher.QuineProducingRegisterA(_program);
        ulong lowestAValue = possibleAValues.Min();
        return lowestAValue.ToString();
    }
}
