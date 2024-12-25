namespace AdventOfCode.Year2024.Day25.Puzzle;

internal sealed class LockPins(int height, int[] pins)
{
    public int Height { get; } = height;
    public IReadOnlyList<int> Pins { get; } = pins;
}
