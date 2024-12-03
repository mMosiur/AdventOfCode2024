using System.Text.RegularExpressions;

namespace AdventOfCode.Year2024.Day03;

internal sealed partial class CorruptedMemoryDiagnoser(bool ignoreConditionals)
{
    private readonly bool _ignoreConditionals = ignoreConditionals;

    [GeneratedRegex(@"mul\((\d+),(\d+)\)")]
    private static partial Regex MulInstructionRegex();

    [GeneratedRegex(@"mul\((\d+),(\d+)\)|do\(\)|don't\(\)")]
    private static partial Regex InstructionsRegex();

    public IEnumerable<Instructions.Mul> RetrieveMulInstructions(string input)
    {
        return _ignoreConditionals
            ? RetrieveMulInstructionsWithoutConditionals(input)
            : RetrieveMulInstructionsWithConditionals(input);
    }

    private static IEnumerable<Instructions.Mul> RetrieveMulInstructionsWithoutConditionals(string input)
    {
        foreach (Match match in MulInstructionRegex().Matches(input))
        {
            int num1 = int.Parse(match.Groups[1].ValueSpan);
            int num2 = int.Parse(match.Groups[2].ValueSpan);
            yield return new(num1, num2);
        }
    }

    private static IEnumerable<Instructions.Mul> RetrieveMulInstructionsWithConditionals(string input)
    {
        bool ignoreMulInstructions = false;
        foreach (Match match in InstructionsRegex().Matches(input))
        {
            switch (match.ValueSpan)
            {
                case "do()":
                    ignoreMulInstructions = false;
                    continue;
                case "don't()":
                    ignoreMulInstructions = true;
                    continue;
            }

            if (ignoreMulInstructions)
            {
                continue;
            }

            int num1 = int.Parse(match.Groups[1].ValueSpan);
            int num2 = int.Parse(match.Groups[2].ValueSpan);
            yield return new(num1, num2);
        }
    }
}
