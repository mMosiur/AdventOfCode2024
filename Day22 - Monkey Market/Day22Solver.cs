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
        var uniqueSequences = new HashSet<PriceChangeValueSequence>();
        var sequencePrices = new Dictionary<PriceChangeValueSequence, byte>[_initialSecretNumbers.Length];
        for (int i = 0; i < _initialSecretNumbers.Length; i++)
        {
            int secretNumber = _initialSecretNumbers[i];
            sequencePrices[i] = new();
            var secretGenerator = new SecretGenerator(secretNumber);
            var priceTracker = new PriceTracker(secretGenerator);
            var priceChanges = priceTracker.CalculatePriceChanges(2000);
            foreach (var (sequence, endPrice) in priceTracker.EnumeratePriceChangeSequences(priceChanges))
            {
                if (sequencePrices[i].TryAdd(sequence, endPrice))
                {
                    uniqueSequences.Add(sequence);
                }
            }
        }

        long result = uniqueSequences
            .Select(seq => sequencePrices.Sum(sp => sp.GetValueOrDefault(seq, (byte)0)))
            .Max();

        return result.ToString();
    }
}
