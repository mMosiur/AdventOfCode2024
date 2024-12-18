using System.Text.RegularExpressions;
using AdventOfCode.Common;
using AdventOfCode.Common.EnumeratorExtensions;
using AdventOfCode.Common.StringExtensions;

namespace AdventOfCode.Year2024.Day17.Puzzle;

internal static partial class InputReader
{
    [GeneratedRegex(@"^Register (A|B|C): (\d+)$")]
    private static partial Regex RegisterLineRegex();

    [GeneratedRegex(@"^Program: ((?:\d|,)+)$")]
    private static partial Regex ProgramLineRegex();

    public static (RegisterValues Registers, List<byte> Program) Read(string input)
    {
        using var it = input.EnumerateLines().GetEnumerator();
        it.EnsureMoveNext();
        if (string.IsNullOrWhiteSpace(it.Current))
        {
            throw new InputException("Input is empty");
        }

        ulong a = ReadRegister('A', it.Current);
        it.EnsureMoveNext();
        ulong b = ReadRegister('B', it.Current);
        it.EnsureMoveNext();
        ulong c = ReadRegister('C', it.Current);
        it.EnsureMoveToNextNonEmptyLine();
        var program = ReadProgram(it.Current);

        return (new(a, b, c), program);
    }

    private static ulong ReadRegister(char registerSymbol, string line)
    {
        var match = RegisterLineRegex().Match(line);
        if (!match.Success)
        {
            throw new InputException($"Invalid register line: '{line}'");
        }

        if (match.Groups[1].ValueSpan[0] != registerSymbol)
        {
            throw new InputException($"Invalid register symbol: '{match.Groups[1].Value}' (expected '{registerSymbol}')");
        }

        if (!ulong.TryParse(match.Groups[2].ValueSpan, out ulong value))
        {
            throw new InputException($"Invalid register value: '{match.Groups[2].Value}'");
        }

        return value;
    }

    private static List<byte> ReadProgram(string line)
    {
        var match = ProgramLineRegex().Match(line);
        if (!match.Success)
        {
            throw new InputException($"Invalid program line: '{line}'");
        }

        var program = new List<byte>();

        var programNumbers = match.Groups[1].ValueSpan;
        foreach (Range splitRange in programNumbers.Split(','))
        {
            var numberSpan = programNumbers[splitRange];
            if (!byte.TryParse(numberSpan, out byte numericValue))
            {
                throw new InputException($"Invalid program value: '{numberSpan}'");
            }

            if (numericValue > 7)
            {
                throw new InputException($"Invalid program value: '{numericValue}' (expected 0-7)");
            }

            program.Add(numericValue);
        }

        return program;
    }
}
