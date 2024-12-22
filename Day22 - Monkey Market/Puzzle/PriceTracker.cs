namespace AdventOfCode.Year2024.Day22.Puzzle;

internal sealed class PriceTracker(SecretGenerator secretGenerator)
{
    private readonly SecretGenerator _secretGenerator = secretGenerator;

    public PriceChange[] CalculatePriceChanges(int priceChangeCount)
    {
        var priceChanges = new PriceChange[priceChangeCount];
        byte previousPrice = GetCurrentPrice();
        for (int i = 0; i < priceChangeCount; i++)
        {
            _secretGenerator.NextSecret();
            byte newPrice = GetCurrentPrice();
            sbyte changeValue = (sbyte)(newPrice - previousPrice);
            priceChanges[i] = new(changeValue, newPrice);
            previousPrice = newPrice;
        }

        return priceChanges;
    }

    private byte GetCurrentPrice()
    {
        return (byte)(_secretGenerator.CurrentSecret % 10);
    }

    public IEnumerable<(PriceChangeValueSequence Sequence, byte EndPrice)> EnumeratePriceChangeSequences(PriceChange[] priceChanges)
    {
        for (int i = 0; i < priceChanges.Length - PriceChangeValueSequence.Length + 1; i++)
        {
            var sequence = new PriceChangeValueSequence(priceChanges.AsSpan().Slice(i, PriceChangeValueSequence.Length));
            byte endPrice = priceChanges[i + PriceChangeValueSequence.Length - 1].PriceAfterChange;
            yield return (sequence, endPrice);
        }
    }
}

internal readonly record struct PriceChange(sbyte Change, byte PriceAfterChange);

internal readonly record struct PriceChangeValueSequence(sbyte PriceChange0, sbyte PriceChange1, sbyte PriceChange2, sbyte PriceChange3)
{
    public const int Length = 4;

    public PriceChangeValueSequence(ReadOnlySpan<PriceChange> priceChanges)
        : this(priceChanges[0].Change, priceChanges[1].Change, priceChanges[2].Change, priceChanges[3].Change)
    {
    }

    public override int GetHashCode()
    {
        int baseHash = 1;
        baseHash += PriceChange0 + 9;
        baseHash <<= 5;
        baseHash += PriceChange1 + 9;
        baseHash <<= 5;
        baseHash += PriceChange2 + 9;
        baseHash <<= 5;
        baseHash += PriceChange3 + 9;
        return baseHash;
    }
}
