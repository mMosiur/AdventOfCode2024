using AdventOfCode.Year2024.Day21.Puzzle.Keypads;

namespace AdventOfCode.Year2024.Day21.Puzzle;

internal static class InputReader
{
    public static DoorCode[] Read(IEnumerable<string> inputLines)
    {
        return inputLines
            .Select(l => new DoorCode(l.Select(KeypadButtonHelpers.Parse)))
            .ToArray();
    }
}
