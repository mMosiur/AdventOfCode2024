using AdventOfCode.Common;
using AdventOfCode.Year2024.Day17.Puzzle;

namespace AdventOfCode.Year2024.Day17;

public sealed class Day17Solver : DaySolver<Day17SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 17;
    public override string Title => "Chronospatial Computer";

    private readonly InitialRegisterValues _registers;
    private readonly IReadOnlyList<byte> _program;

    public Day17Solver(Day17SolverOptions options) : base(options)
    {
        (_registers, _program) = InputReader.Read(Input);
    }

    public Day17Solver(Action<Day17SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day17Solver() : this(new Day17SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var computer = new Computer(_registers.A, _registers.B, _registers.C);
        var outputEnumerable = computer.RunProgram(_program);
        string finalOutput = string.Join(",", outputEnumerable);
        return finalOutput;
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
