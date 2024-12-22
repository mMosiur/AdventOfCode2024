using System.Collections;

namespace AdventOfCode.Year2024.Day22.Puzzle;

internal sealed class PriceTracker(SecretGenerator secretGenerator)
{
    private readonly SecretGenerator _secretGenerator = secretGenerator;

    public PriceChange[] CalculatePriceChanges(int priceChangeCount)
    {
        var priceChanges = new PriceChange[priceChangeCount];
        byte currentPrice = GetCurrentPrice();
        for (int i = 0; i < priceChangeCount; i++)
        {
            _secretGenerator.NextSecret();
            byte newPrice = GetCurrentPrice();
            priceChanges[i] = new((sbyte)(newPrice - currentPrice));// PriceChange.FromPrices(currentPrice, newPrice);
            currentPrice = newPrice;
        }

        return priceChanges;
    }

    private byte GetCurrentPrice()
    {
        return (byte)(_secretGenerator.CurrentSecret % 10);
    }

    public static IEnumerable<PriceChangeSequence> EnumeratePriceChangeSequences(PriceChange[] priceChanges)
    {
        for (int i = 0; i < priceChanges.Length - 3; i++)
        {
            yield return new(priceChanges.AsSpan().Slice(i, 4));
        }
    }
}

// internal readonly record struct PriceChange(sbyte Change, byte PriceAfter)
// {
//     public static PriceChange FromPrices(byte priceBefore, byte priceAfter)
//         => new((sbyte)(priceAfter - priceBefore), priceAfter);
// }

internal readonly record struct PriceChange(sbyte Change)
{
}

internal readonly record struct PriceChangeSequence(PriceChange PriceChange0, PriceChange PriceChange1, PriceChange PriceChange2, PriceChange PriceChange3)
{
    public PriceChangeSequence(ReadOnlySpan<PriceChange> priceChanges)
        : this(priceChanges[0], priceChanges[1], priceChanges[2], priceChanges[3])
    {
    }

    public override int GetHashCode()
    {
        int baseHash = 1;
        baseHash += PriceChange0.Change + 9;
        baseHash <<= 5;
        baseHash += PriceChange1.Change + 9;
        baseHash <<= 5;
        baseHash += PriceChange2.Change + 9;
        baseHash <<= 5;
        baseHash += PriceChange3.Change + 9;
        return baseHash;
    }
}
