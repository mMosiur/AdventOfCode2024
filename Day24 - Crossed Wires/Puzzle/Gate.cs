namespace AdventOfCode.Year2024.Day24.Puzzle;

internal abstract class Gate(GateType type, Wire wireIn1, Wire wireIn2, Wire wireOut)
{
    public GateType Type { get; } = type;
    public Wire WireIn1 { get; } = wireIn1;
    public Wire WireIn2 { get; } = wireIn2;
    public Wire WireOut { get; private set; } = wireOut;

    public GateDescriptor Descriptor => new(WireIn1, Type, WireIn2);

    public void AttachOutput(Wire wire)
    {
        WireOut = wire;
    }

    public abstract bool Compute();

    public static Gate Create(GateType type, Wire wireIn1, Wire wireIn2, Wire wireOut)
    {
        return type switch
        {
            GateType.And => new AndGate(wireIn1, wireIn2, wireOut),
            GateType.Or => new OrGate(wireIn1, wireIn2, wireOut),
            GateType.Xor => new XorGate(wireIn1, wireIn2, wireOut),
            _ => throw new InvalidOperationException("Invalid gate type")
        };
    }
}

internal sealed class AndGate(Wire wireIn1, Wire wireIn2, Wire wireOut)
    : Gate(GateType.And, wireIn1, wireIn2, wireOut)
{
    public override bool Compute() => WireIn1.Bit & WireIn2.Bit;
}

internal sealed class OrGate(Wire wireIn1, Wire wireIn2, Wire wireOut)
    : Gate(GateType.Or, wireIn1, wireIn2, wireOut)
{
    public override bool Compute() => WireIn1.Bit | WireIn2.Bit;
}

internal sealed class XorGate(Wire wireIn1, Wire wireIn2, Wire wireOut)
    : Gate(GateType.Xor, wireIn1, wireIn2, wireOut)
{
    public override bool Compute() => WireIn1.Bit ^ WireIn2.Bit;
}

internal readonly record struct GateDescriptor(Wire WireIn1, GateType GateType, Wire WireIn2)
{
    public bool UnorderedEquals(GateDescriptor? other)
    {
        if (other is null) return false;
        if (GateType != other.Value.GateType) return false;
        return (WireIn1 == other.Value.WireIn1 && WireIn2 == other.Value.WireIn2) ||
               (WireIn1 == other.Value.WireIn2 && WireIn2 == other.Value.WireIn1);
    }
}

internal enum GateType
{
    And = 1,
    Or = 2,
    Xor = 3,
}
