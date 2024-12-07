using AdventOfCode.Common;
using AdventOfCode.Year2024.Day07.Puzzle;
using AdventOfCode.Year2024.Day07.Puzzle.Operations;

namespace AdventOfCode.Year2024.Day07;

public sealed class Day07Solver : DaySolver<Day07SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 7;
    public override string Title => "Bridge Repair";

    private readonly IReadOnlyCollection<Equation> _equations;

    public Day07Solver(Day07SolverOptions options) : base(options)
    {
        _equations = InputReader.Read(InputLines);
    }

    public Day07Solver(Action<Day07SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day07Solver() : this(new Day07SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var equationChecker = new EquationChecker(
            new AddOperation(),
            new MultiplyOperation());

        long result = _equations
            .Where(equation => equationChecker.IsEquationPossiblyTrue(equation))
            .Sum(equation => equation.Result);

        return result.ToString();
    }

    public override string SolvePart2()
    {
        var equationChecker = new EquationChecker(
            new AddOperation(),
            new MultiplyOperation(),
            new ConcatenateOperation());

        long result = _equations
            .Where(equation => equationChecker.IsEquationPossiblyTrue(equation))
            .Sum(equation => equation.Result);

        return result.ToString();
    }
}
