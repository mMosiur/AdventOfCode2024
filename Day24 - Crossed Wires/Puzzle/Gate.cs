namespace AdventOfCode.Year2024.Day24.Puzzle;

internal sealed class Gate(GateType type, Wire wireIn1, Wire wireIn2, Wire wireOut)
{
    public GateType Type { get; set; } = type;
    public Wire WireIn1 { get; set; } = wireIn1;
    public Wire WireIn2 { get; set; } = wireIn2;
    public Wire WireOut { get; set; } = wireOut;

    public GateInfo GetInfo() => new(WireIn1, Type, WireIn2);

    public bool Execute()
    {
        bool newValue = Type switch
        {
            GateType.And => WireIn1.Value & WireIn2.Value,
            GateType.Or => WireIn1.Value | WireIn2.Value,
            GateType.Xor => WireIn1.Value ^ WireIn2.Value,
            _ => throw new InvalidOperationException($"Invalid gate type: {Type}")
        };

        if (newValue == WireOut.Value) return false;
        WireOut.Value = newValue;
        return true;
    }
}

internal readonly record struct GateInfo(Wire WireIn1, GateType GateType, Wire WireIn2);

internal enum GateType
{
    And = 1,
    Or = 2,
    Xor = 3,
}
