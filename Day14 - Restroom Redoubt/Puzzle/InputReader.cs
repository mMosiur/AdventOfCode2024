using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day14.Puzzle;

internal static partial class InputReader
{
    [GeneratedRegex(@"^p=(-?\d+,-?\d+) v=(-?\d+,-?\d+)\s*$", RegexOptions.Multiline)]
    private static partial Regex LineRegex();

    public static List<Robot> Read(string input)
    {
        List<Robot> robots = [];
        foreach (Match match in LineRegex().Matches(input))
        {
            var position = Point.Parse(match.Groups[1].ValueSpan);
            var velocity = Vector.Parse(match.Groups[2].ValueSpan);
            robots.Add(new(position, velocity));
        }

        return robots;
    }
}
