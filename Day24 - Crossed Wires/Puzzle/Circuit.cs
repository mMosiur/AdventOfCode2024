namespace AdventOfCode.Year2024.Day24.Puzzle;

internal sealed class Circuit
{
    private readonly List<Wire> _wires;
    private readonly List<Gate> _gates;

    public Register XRegister { get; }
    public Register YRegister { get; }
    public Register ZRegister { get; }


    private Circuit(Register xRegister, Register yRegister, Register zRegister, IReadOnlyCollection<Wire> wires, IReadOnlyCollection<Gate> gates)
    {
        XRegister = xRegister;
        YRegister = yRegister;
        ZRegister = zRegister;
        _wires = wires.ToList();
        _gates = gates.ToList();
    }

    public Gate? GetGateByUnorderedDescriptor(GateDescriptor descriptor)
    {
        return _gates.FirstOrDefault(g => g.Descriptor.UnorderedEquals(descriptor));
    }

    public static Circuit Build(IReadOnlyCollection<Wire> wires, IReadOnlyCollection<Gate> gates)
    {
        var xRegister = new Register("X", wires.Where(w => w.Name.StartsWith('x')).OrderBy(w => w.Name));
        var yRegister = new Register("Y", wires.Where(w => w.Name.StartsWith('y')).OrderBy(w => w.Name));
        var zRegister = new Register("Z", wires.Where(w => w.Name.StartsWith('z')).OrderBy(w => w.Name));
        return new(xRegister, yRegister, zRegister, wires, gates);
    }
}
