using System.Diagnostics;
using AdventOfCode.Common;
using AdventOfCode.Year2024.Day24.Puzzle;

namespace AdventOfCode.Year2024.Day24;

public sealed class Day24Solver : DaySolver<Day24SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 24;
    public override string Title => "Crossed Wires";

    private readonly IReadOnlyDictionary<string, Wire> _wires;
    private readonly IReadOnlyList<Gate> _gates;

    private readonly List<Wire> _badWires = new();

    public Day24Solver(Day24SolverOptions options) : base(options)
    {
        (_wires, _gates) = InputReader.Read(InputLines);
    }

    public Day24Solver(Action<Day24SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day24Solver() : this(new Day24SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        bool changed = true;
        while (changed)
        {
            changed = false;
            foreach (var gate in _gates)
            {
                changed |= gate.Execute();
            }
        }

        long result = BuildNumberFromWires(_wires.Values.Where(w => w.Name.StartsWith('z')).OrderByDescending(w => w.Name));
        return result.ToString();
    }

    private static long BuildNumberFromWires(IEnumerable<Wire> wires)
    {
        return wires.Aggregate(0L, (current, wire) => (current << 1) + (wire.Value ? 1 : 0));
    }

    public override string SolvePart2()
    {
        var xWires = _wires.Values.Where(w => w.Name.StartsWith('x')).OrderByDescending(w => w.Name).ToArray();
        long xNumber = BuildNumberFromWires(xWires);
        Debug.WriteLine($"x: {xNumber} ({xNumber:B64})");
        var yWires = _wires.Values.Where(w => w.Name.StartsWith('y')).OrderByDescending(w => w.Name).ToArray();
        long yNumber = BuildNumberFromWires(yWires);
        Debug.WriteLine($"y: {yNumber} ({yNumber:B64})");
        long actualAddition = xNumber + yNumber;

        var zWires = _wires.Values.Where(w => w.Name.StartsWith('z')).OrderByDescending(w => w.Name).ToArray();

        // Credit for inspiration to rdb (https://gist.github.com/rdb/5ccdcf088e02fc9a6adcc58245aee8b1)
        GateInfo? carry = null;
        int outIndex = 0;
        foreach (((Wire xWire, Wire yWire), int index) in xWires.Zip(yWires).Select((p, i) => (p, i)))
        {
            outIndex = index;
            var zWire = zWires[index];

            if (carry is null)
            {
                FixGate(zWire, new(xWire, GateType.Xor, yWire));
                carry = new(xWire, GateType.And, yWire);
            }
            else
            {
                var wireOut1 = GetGateWireOutByInfo(new(xWire, GateType.Xor, yWire));
                var wireOut2 = GetGateWireOutByInfo(carry.Value);
                FixGate(zWire, new(wireOut1, GateType.Xor, wireOut2));

                //gates[in_a ^ in_b]
                var temp1 = GetGateWireOutByInfo(new(xWire, GateType.Xor, yWire));
                var temp2 = GetGateWireOutByInfo(carry.Value);
                var temp = GetGateWireOutByInfo(new(temp1, GateType.And, temp2));
                carry = new(temp, GateType.Or, GetGateWireOutByInfo(new(xWire, GateType.And, yWire)));
            }
        }

        if (outIndex + 1 < zWires.Length)
        {
            FixGate(zWires[outIndex + 1], carry!.Value);
        }

        return string.Join(",", _badWires.Select(w => w.Name));
    }

    private void FixGate(Wire outWire, GateInfo gateInfo)
    {
        var actualWireOut = GetGateWireOutByInfo(gateInfo);
        if (actualWireOut == outWire) return;

        var outGate = GetGateByWireOut(outWire);

        if (actualWireOut is null)
        {
            // Maybe the gate is fine but one of the inputs is wrong
            if (outGate.WireIn1 == gateInfo.WireIn1)
            {
                FixGate(outGate.WireIn2, GetGateByWireOut(outGate.WireIn2).GetInfo());
                return;
            }

            if (outGate.WireIn1 == gateInfo.WireIn2)
            {
                FixGate(outGate.WireIn2, GetGateByWireOut(outGate.WireIn1).GetInfo());
                return;
            }

            if (outGate.WireIn2 == gateInfo.WireIn1)
            {
                FixGate(outGate.WireIn1, GetGateByWireOut(outGate.WireIn2).GetInfo());
                return;
            }

            if (outGate.WireIn2 == gateInfo.WireIn2)
            {
                FixGate(outGate.WireIn1, GetGateByWireOut(outGate.WireIn1).GetInfo());
                return;
            }

            throw new InvalidOperationException("This should not happen");
        }
        var actualOutGate = GetGateByWireOut(actualWireOut!);

        (outGate.WireOut, actualOutGate.WireOut) = (actualOutGate.WireOut, outGate.WireOut);

        _badWires.Add(outWire);
        _badWires.Add(actualWireOut!);
    }

    private Wire? GetGateWireOutByInfo(Wire wireIn1, GateType gateType, Wire wireIn2)
    {
        return GetGateWireOutByInfo(new(wireIn1, gateType, wireIn2));
    }

    private Wire? GetGateWireOutByInfo(GateInfo gateInfo)
    {
        return _gates.FirstOrDefault(g => g.GetInfo() == gateInfo)?.WireOut;
    }

    private Gate GetGateByWireOut(Wire wireOut)
    {
        return _gates.First(g => g.WireOut == wireOut);
    }

    //                                             xx    xx  xxxx                xxx
    // +: 60754222956776 (0000000000000000001101110100000101110001111000001100000011101000)
    // z: 60614602965288 (0000000000000000001101110010000011101111111000001100000100101000)
}

internal static class Combinatorics
{
    public static IEnumerable<IEnumerable<T>> GetCombinations<T>(IReadOnlyCollection<T> list, int length)
    {
        if (length == 1)
        {
            return list.Select(t => new[] { t });
        }

        return GetCombinations(list, length - 1).SelectMany(t => list, (t1, t2) => t1.Concat([t2]));
    }
}
