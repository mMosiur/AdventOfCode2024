namespace AdventOfCode.Year2024.Day24.Puzzle;

internal sealed class CircuitFixer(Circuit circuit)
{
    private readonly Circuit _circuit = circuit;

    public List<Wire> FixAdder()
    {
        GateDescriptor? carryGate = null;

        List<Wire> fixedWiresList = [];
        foreach (((Wire xWire, Wire yWire), int i) in _circuit.XRegister.Zip(_circuit.YRegister).Select((p, i) => (p, i)))
        {
            Wire zWire = _circuit.ZRegister.Wires[i];

            if (carryGate is null)
            {
                FixGate(zWire, xWire ^ yWire, fixedWiresList);
                carryGate = xWire & yWire;
            }
            else
            {
                FixGate(zWire, GetGateWireOut(xWire ^ yWire) ^ GetGateWireOut(carryGate.Value), fixedWiresList);
                var temp = GetGateWireOut(GetGateWireOut(xWire ^ yWire) & GetGateWireOut(carryGate.Value));
                carryGate = temp | GetGateWireOut(xWire & yWire);
            }
        }

        return fixedWiresList;
    }

    private Wire? FixGate(Wire wireOut, GateDescriptor expectedInputGate, List<Wire> fixedWiresList)
    {
        if (expectedInputGate.UnorderedEquals(wireOut.InputGate?.Descriptor))
        {
            return null;
        }

        Wire? actualWireOut = _circuit.GetGateByUnorderedDescriptor(expectedInputGate)?.WireOut;
        if (actualWireOut is null)
        {
            return FixGateInputs(wireOut, expectedInputGate, fixedWiresList);
        }

        SwapGateOutputs(wireOut, actualWireOut);
        fixedWiresList.Add(wireOut);
        fixedWiresList.Add(actualWireOut);
        return wireOut;
    }

    private Wire GetGateWireOut(GateDescriptor gateDescriptor)
    {
        return _circuit.GetGateByUnorderedDescriptor(gateDescriptor)!.WireOut;
    }

    private Wire? FixGateInputs(Wire wireOut, GateDescriptor gateDescriptor, List<Wire> fixedWiresList)
    {
        if (wireOut.InputGate?.WireIn1 == gateDescriptor.WireIn1)
            return FixGate(wireOut.InputGate.WireIn2, gateDescriptor.WireIn2.InputGate!.Descriptor, fixedWiresList);
        if (wireOut.InputGate?.WireIn1 == gateDescriptor.WireIn2)
            return FixGate(wireOut.InputGate.WireIn2, gateDescriptor.WireIn1.InputGate!.Descriptor, fixedWiresList);
        if (wireOut.InputGate?.WireIn2 == gateDescriptor.WireIn1)
            return FixGate(wireOut.InputGate.WireIn1, gateDescriptor.WireIn2.InputGate!.Descriptor, fixedWiresList);
        if (wireOut.InputGate?.WireIn2 == gateDescriptor.WireIn2)
            return FixGate(wireOut.InputGate.WireIn1, gateDescriptor.WireIn1.InputGate!.Descriptor, fixedWiresList);
        throw new InvalidOperationException("This should not happen");
    }

    private static void SwapGateOutputs(Wire wire1, Wire wire2)
    {
        var gate1 = wire1.InputGate;
        var gate2 = wire2.InputGate;
        wire1.AttachToInput(gate2!);
        wire2.AttachToInput(gate1!);
        gate1?.AttachOutput(wire2);
        gate2?.AttachOutput(wire1);
    }
}
