using AdventOfCode.Common;
using AdventOfCode.Year2024.Day22.Puzzle;

namespace AdventOfCode.Year2024.Day22;

public sealed class Day22Solver : DaySolver<Day22SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 22;
    public override string Title => "Monkey Market";

    private readonly int[] _initialSecretNumbers;

    public Day22Solver(Day22SolverOptions options) : base(options)
    {
        _initialSecretNumbers = InputReader.Read(InputLines);
    }

    public Day22Solver(Action<Day22SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day22Solver() : this(new Day22SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        long secretNumberSum = _initialSecretNumbers
            .Select(sn => new SecretGenerator(sn))
            .Select(sg => (long)sg.CycleSecret(2000))
            .Sum();

        return secretNumberSum.ToString();
    }

    public override string SolvePart2()
    {
        var monkeyMarketOptimizer = new MonkeyMarketOptimizer(_initialSecretNumbers);

        int maxBananas = monkeyMarketOptimizer.CalculateMaximumBananas(priceChangeTrackCount: 2000);

        return maxBananas.ToString();
    }
}
