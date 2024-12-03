using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day03;

internal sealed partial class CorruptedMemoryDiagnoser
{
    [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
    private static partial Regex InstructionRegex();

    public IEnumerable<Instructions.Mul> RetrieveMulInstructions(string input)
    {
        foreach (Match match in InstructionRegex().Matches(input))
        {
            int num1 = int.Parse(match.Groups[1].ValueSpan);
            int num2 = int.Parse(match.Groups[2].ValueSpan);
            yield return new(num1, num2);
        }
    }
}
