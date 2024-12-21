using AdventOfCode.Common;
using AdventOfCode.Year2024.Day21.Puzzle;

namespace AdventOfCode.Year2024.Day21;

public sealed class Day21Solver : DaySolver<Day21SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 21;
    public override string Title => "Keypad Conundrum";

    private readonly DoorCode[] _doorCodes;

    public Day21Solver(Day21SolverOptions options) : base(options)
    {
        _doorCodes = InputReader.Read(InputLines);
    }

    public Day21Solver(Action<Day21SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day21Solver() : this(new Day21SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var robotArmChain = new RobotArmChain();

        long codeComplexitySum = _doorCodes
            .Sum(doorCode => robotArmChain.CalculateComplexity(doorCode));

        return codeComplexitySum.ToString();
    }

    public override string SolvePart2()
    {
        return "UNSOLVED";
    }
}
