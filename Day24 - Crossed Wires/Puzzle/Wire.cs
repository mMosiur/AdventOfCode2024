namespace AdventOfCode.Year2024.Day24.Puzzle;

internal sealed class Wire(string name, bool? initialBit = null)
{
    private bool? _bit = initialBit;

    public string Name { get; } = name;

    public Gate? InputGate { get; private set; }

    public bool Bit
    {
        get
        {
            if (_bit.HasValue) return _bit.Value;
            if (InputGate is null) throw new InvalidDataException("Non-output wire value is not set");
            _bit = InputGate.Compute();
            return _bit.Value;
        }
    }

    public void AttachToInput(Gate gate)
    {
        InputGate = gate;
    }

    public static GateDescriptor operator &(Wire w1, Wire w2) => new(w1, GateType.And, w2);
    public static GateDescriptor operator |(Wire w1, Wire w2) => new(w1, GateType.Or, w2);
    public static GateDescriptor operator ^(Wire w1, Wire w2) => new(w1, GateType.Xor, w2);
}
