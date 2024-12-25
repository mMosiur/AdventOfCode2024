namespace AdventOfCode.Year2024.Day25.Puzzle;

internal sealed class Key(int[] heights)
{
    public IReadOnlyList<int> Heights { get; } = heights;

    public bool DoesFit(LockPins lockPins)
    {
        if (Heights.Count != lockPins.Pins.Count) return false;
        for (int i = 0; i < Heights.Count; i++)
        {
            int totalHeight = Heights[i] + lockPins.Pins[i];
            if (totalHeight > lockPins.Height) return false;
        }

        return true;
    }
}
