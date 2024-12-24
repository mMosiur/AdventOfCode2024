using System.Text.RegularExpressions;
using AdventOfCode.Common;
using AdventOfCode.Common.EnumeratorExtensions;

namespace AdventOfCode.Year2024.Day24.Puzzle;

internal static partial class InputReader
{
    public static (Dictionary<string, Wire> Wires, List<Gate> Gates) Read(IEnumerable<string> inputLines)
    {
        try
        {
            Dictionary<string, Wire> wires = new();
            List<Gate> gates = new();
            using var it = inputLines.GetEnumerator();

            it.EnsureMoveNext();
            while (!string.IsNullOrWhiteSpace(it.Current))
            {
                var wire = ParseWireLine(it.Current);
                wires.Add(wire.Name, wire);
                it.EnsureMoveNext();
            }

            it.EnsureMoveNext();
            while (!string.IsNullOrWhiteSpace(it.Current))
            {
                var gate = BuildGateFromLine(it.Current, wires);
                gates.Add(gate);
                if (!it.MoveNext()) break;
            }

            return (wires, gates);
        }
        catch (InvalidOperationException e)
        {
            throw new InputException("Invalid input", e);
        }
    }

    [GeneratedRegex(@"^\s*([a-z0-9]{3}): (0|1)\s*$")]
    private static partial Regex InputWireLineRegex();

    private static Wire ParseWireLine(string line)
    {
        var match = InputWireLineRegex().Match(line);
        if (!match.Success)
        {
            throw new InputException($"Invalid input wire line: '{line}'");
        }


        var wire = new Wire(match.Groups[1].Value, match.Groups[2].ValueSpan is "1");
        return wire;
    }

    [GeneratedRegex(@"^([a-z0-9]{3}) (AND|OR|XOR) ([a-z0-9]{3}) -> ([a-z0-9]{3})$")]
    private static partial Regex GateLineRegex();

    private static Gate BuildGateFromLine(string line, Dictionary<string, Wire> wires)
    {
        var match = GateLineRegex().Match(line);
        if (!match.Success)
        {
            throw new InputException($"Invalid input gate line: '{line}'");
        }

        if (!Enum.TryParse(match.Groups[2].ValueSpan, ignoreCase: true, out GateType gateType))
        {
            throw new InputException($"Invalid gate type: '{match.Groups[2].Value}'");
        }

        var wireIn1 = GetOrCreateWire(match.Groups[1].Value, wires);
        var wireIn2 = GetOrCreateWire(match.Groups[3].Value, wires);
        var wireOut = GetOrCreateWire(match.Groups[4].Value, wires);

        var gate = new Gate(gateType, wireIn1, wireIn2, wireOut);
        return gate;
    }

    private static Wire GetOrCreateWire(string wireName, Dictionary<string, Wire> wires)
    {
        if (wires.TryGetValue(wireName, out var wire))
        {
            return wire;
        }

        wire = new(wireName);
        wires.Add(wireName, wire);
        return wire;
    }
}
