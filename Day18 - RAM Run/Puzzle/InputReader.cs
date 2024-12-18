using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day18.Puzzle;

internal static class InputReader
{
    public static List<Point> Read(IEnumerable<string> inputLines, Day18SolverOptions options)
    {
        List<Point> points;

        try
        {
            points = inputLines
                .Select(l => Point.Parse(l))
                .ToList();
        }
        catch (FormatException ex)
        {
            throw new InputException("Input is not in the correct format.", ex);
        }

        if (points.Any(p => p.X < 0 || p.Y >= options.MemorySpaceWidth || p.Y < 0 || p.Y >= options.MemorySpaceHeight))
        {
            throw new InputException("Some points are out of the memory space.");
        }

        return points;
    }
}
