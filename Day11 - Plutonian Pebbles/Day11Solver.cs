using AdventOfCode.Common;
using AdventOfCode.Year2024.Day11.Puzzle;

namespace AdventOfCode.Year2024.Day11;

public sealed class Day11Solver : DaySolver<Day11SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 11;
    public override string Title => "Plutonian Pebbles";

    private readonly IReadOnlyCollection<Stone> _initialStones;
    private readonly StoneLineBlinker _stoneBlinker;

    public Day11Solver(Day11SolverOptions options) : base(options)
    {
        _initialStones = InputReader.Read(Input);
        _stoneBlinker = new(Options.StoneEngravingMultiplier);
    }

    public Day11Solver(Action<Day11SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day11Solver() : this(new Day11SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        long stoneCount = _stoneBlinker
            .CountStonesAfterBlinks(_initialStones, Options.PartOneBlinkCount);

        return stoneCount.ToString();
    }

    public override string SolvePart2()
    {
        long stoneCount = _stoneBlinker
            .CountStonesAfterBlinks(_initialStones, Options.PartTwoBlinkCount);

        return stoneCount.ToString();
    }
}
