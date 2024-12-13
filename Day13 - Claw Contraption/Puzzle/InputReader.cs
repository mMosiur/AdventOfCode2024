using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day13.Puzzle;

internal static partial class InputReader
{
    [GeneratedRegex(@"Button A: X\+(\d+), Y\+(\d+)\r?\nButton B: X\+(\d+), Y\+(\d+)\r?\nPrize: X=(\d+), Y=(\d+)")]
    private static partial Regex ClawMachineRegex();

    public static List<ClawMachine> Read(string input)
    {
        List<ClawMachine> clawMachines = [];
        foreach (Match match in ClawMachineRegex().Matches(input))
        {
            clawMachines.Add(new(
                new(int.Parse(match.Groups[1].ValueSpan), int.Parse(match.Groups[2].ValueSpan)),
                new(int.Parse(match.Groups[3].ValueSpan), int.Parse(match.Groups[4].ValueSpan)),
                new(int.Parse(match.Groups[5].ValueSpan), int.Parse(match.Groups[6].ValueSpan))
            ));
        }

        return clawMachines;
    }
}
