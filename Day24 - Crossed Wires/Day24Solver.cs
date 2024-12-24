using AdventOfCode.Common;
using AdventOfCode.Year2024.Day24.Puzzle;

namespace AdventOfCode.Year2024.Day24;

public sealed class Day24Solver : DaySolver<Day24SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 24;
    public override string Title => "Crossed Wires";

    private readonly IReadOnlyDictionary<string, Wire> _wires;
    private readonly IReadOnlyList<Gate> _gates;

    public Day24Solver(Day24SolverOptions options) : base(options)
    {
        (_wires, _gates) = InputReader.Read(InputLines);
    }

    public Day24Solver(Action<Day24SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day24Solver() : this(new Day24SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        bool changed = true;
        while (changed)
        {
            changed = false;
            foreach (var gate in _gates)
            {
                changed |= gate.Execute();
            }
        }

        long result = _wires.Values
            .Where(w => w.Name.StartsWith('z'))
            .OrderByDescending(w => w.Name)
            .Aggregate(0L, (current, wire) => (current << 1) + (wire.Value ? 1 : 0));

        return result.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
