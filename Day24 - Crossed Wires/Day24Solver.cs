using AdventOfCode.Common;
using AdventOfCode.Year2024.Day24.Puzzle;

namespace AdventOfCode.Year2024.Day24;

public sealed class Day24Solver : DaySolver<Day24SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 24;
    public override string Title => "Crossed Wires";

    private readonly Circuit _circuit;

    public Day24Solver(Day24SolverOptions options) : base(options)
    {
        _circuit = InputReader.Read(InputLines);
    }

    public Day24Solver(Action<Day24SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day24Solver() : this(new Day24SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        long result = _circuit.ZRegister.ComputeValue();
        return result.ToString();
    }

    public override string SolvePart2()
    {
        if (Options.DontFixAdder)
        {
            return "Adder fixing turned off";
        }

        var circuitFixer = new CircuitFixer(_circuit);
        var fixedWires = circuitFixer.FixAdder();
        return string.Join(",", fixedWires.Select(w => w.Name).Order()).ToString();
    }
}
