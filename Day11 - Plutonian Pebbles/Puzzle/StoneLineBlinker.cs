namespace AdventOfCode.Year2024.Day11.Puzzle;

internal sealed class StoneLineBlinker(int stoneEngravingMultiplier)
{
    private readonly int _stoneEngravingMultiplier = stoneEngravingMultiplier;
    private readonly Dictionary<(Stone Stone, int BlinksLeft), long> _stoneCountCache = new();

    public long CountStonesAfterBlinks(IEnumerable<Stone> initialStoneArrangement, int blinkCount)
    {
        return initialStoneArrangement
            .Sum(stone => CountStonesAfterBlinks(stone, blinkCount));
    }

    private long CountStonesAfterBlinks(Stone sourceStone, int blinkCountLeft)
    {
        if (blinkCountLeft == 0) return 1;

        if (_stoneCountCache.TryGetValue((sourceStone, blinkCountLeft), out long transformedStoneCount))
        {
            return transformedStoneCount;
        }

        var transformationResult = TransformStone(sourceStone);

        transformedStoneCount = CountStonesAfterBlinks(transformationResult.ReplacementStone, blinkCountLeft - 1);
        if (transformationResult.SecondReplacementStone.HasValue)
        {
            transformedStoneCount += CountStonesAfterBlinks(transformationResult.SecondReplacementStone.Value, blinkCountLeft - 1);
        }

        _stoneCountCache.Add((sourceStone, blinkCountLeft), transformedStoneCount);

        return transformedStoneCount;
    }

    private (Stone ReplacementStone, Stone? SecondReplacementStone) TransformStone(Stone stone)
    {
        if (stone.Engraving == 0)
        {
            return (
                ReplacementStone: new Stone(1),
                SecondReplacementStone: null
            );
        }

        int digitCount = MoreMath.DigitCount(stone.Engraving);
        if (digitCount % 2 == 0)
        {
            int halfDigitCount = digitCount / 2;
            int middleDigitCutoff = (int)Math.Pow(10, halfDigitCount);
            return (
                ReplacementStone: new Stone(stone.Engraving / middleDigitCutoff),
                SecondReplacementStone: new Stone(stone.Engraving % middleDigitCutoff)
            );
        }


        return (
            ReplacementStone: new Stone(stone.Engraving * _stoneEngravingMultiplier),
            SecondReplacementStone: null
        );
    }
}
