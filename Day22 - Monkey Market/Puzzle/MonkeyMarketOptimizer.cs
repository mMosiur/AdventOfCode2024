namespace AdventOfCode.Year2024.Day22.Puzzle;

internal sealed class MonkeyMarketOptimizer(int[] buyersInitialSecretNumbers)
{
    private readonly int[] _buyersInitialSecretNumbers = buyersInitialSecretNumbers;

    public int CalculateMaximumBananas(int priceChangeTrackCount)
    {
        var totalBananasForSequence = new Dictionary<PriceChangeValueSequence, int>();
        var seenSequences = new HashSet<PriceChangeValueSequence>(priceChangeTrackCount);

        foreach (int secretNumber in _buyersInitialSecretNumbers)
        {
            var secretGenerator = new SecretGenerator(secretNumber);
            var priceTracker = new PriceTracker(secretGenerator);
            seenSequences.Clear();

            var priceChangeSequences = priceTracker.CalculatePriceChangeSequences(priceChangeTrackCount);
            foreach ((PriceChangeValueSequence sequence, byte endPrice) in priceChangeSequences)
            {
                if (!seenSequences.Add(sequence)) continue; // Skip as monkey would already have bought bananas for this sequence
                int bananas = totalBananasForSequence.GetValueOrDefault(sequence, 0);
                bananas += endPrice;
                totalBananasForSequence[sequence] = bananas;
            }
        }

        return totalBananasForSequence.Max(x => x.Value);
    }
}
