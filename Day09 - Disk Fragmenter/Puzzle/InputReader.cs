namespace AdventOfCode.Year2024.Day09.Puzzle;

internal static class InputReader
{
    public static DiskMap ReadDiskMap(ReadOnlySpan<char> input)
    {
        var diskMapString = input.Trim();
        int[] blockLayout = new int[diskMapString.Length];
        for (int i = 0; i < diskMapString.Length; i++)
        {
            blockLayout[i] = (int)char.GetNumericValue(diskMapString[i]);
        }

        return new(blockLayout);
    }
}
