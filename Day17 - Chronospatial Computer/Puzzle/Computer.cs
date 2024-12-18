using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day17.Puzzle;

internal sealed class Computer
{
    public ulong RegisterA { get; private set; }
    public ulong RegisterB { get; private set; }
    public ulong RegisterC { get; private set; }

    private int _instructionPointer;

    public void Reset(RegisterValues registerValues)
    {
        RegisterA = registerValues.A;
        RegisterB = registerValues.B;
        RegisterC = registerValues.C;
        _instructionPointer = 0;
    }

    public IEnumerable<byte> RunProgram(IReadOnlyList<byte> program)
    {
        while (_instructionPointer < program.Count)
        {
            (Instruction instruction, byte operand) = GetCurrentInstruction(program);
            bool jumped = Execute(instruction, operand, out byte? output);
            if (output.HasValue) yield return output.Value;
            if (!jumped) _instructionPointer += 2;
        }
    }

    private (Instruction Instruction, byte Operand) GetCurrentInstruction(IReadOnlyList<byte> program)
    {
        try
        {
            byte opcode = program[_instructionPointer];
            Instruction instruction = (Instruction)opcode;
            byte operand = program[_instructionPointer + 1];
            return (instruction, operand);
        }
        catch (IndexOutOfRangeException)
        {
            throw new DaySolverException("Program ended unexpectedly");
        }
    }

    private bool Execute(Instruction instruction, byte operand, out byte? output)
    {
        output = null;
        return instruction switch
        {
            Instruction.Adv => ExecuteAdv(operand),
            Instruction.Bxl => ExecuteBxl(operand),
            Instruction.Bst => ExecuteBst(operand),
            Instruction.Jnz => ExecuteJnz(operand),
            Instruction.Bxc => ExecuteBxc(operand),
            Instruction.Out => ExecuteOut(operand, out output),
            Instruction.Bdv => ExecuteBdv(operand),
            Instruction.Cdv => ExecuteCdv(operand),
            _ => throw new ArgumentOutOfRangeException(nameof(instruction), instruction, null),
        };
    }

    private static byte Literal(byte operand) => operand;

    private ulong Combo(byte operand)
        => operand switch
        {
            < 4 => operand,
            4 => RegisterA,
            5 => RegisterB,
            6 => RegisterC,
            7 => throw new DaySolverException("Reserved combo operand 7"),
            _ => throw new ArgumentOutOfRangeException(nameof(operand), operand, null)
        };

    private bool ExecuteAdv(byte operand)
    {
        ulong numerator = RegisterA;
        int denominator = 1 << (int)Combo(operand); // 2^operand
        RegisterA = numerator / (ulong)denominator;
        return false;
    }

    private bool ExecuteBxl(byte operand)
    {
        RegisterB = RegisterB ^ Literal(operand);
        return false;
    }

    private bool ExecuteBst(byte operand)
    {
        RegisterB = Combo(operand) % 8;
        return false;
    }

    private bool ExecuteJnz(byte operand)
    {
        if (RegisterA == 0) return false;
        _instructionPointer = Literal(operand);
        return true;
    }

    private bool ExecuteBxc(byte operand)
    {
        RegisterB = RegisterB ^ RegisterC;
        return false;
    }

    private bool ExecuteOut(byte operand, out byte? output)
    {
        output = (byte)(Combo(operand) % 8);
        return false;
    }

    private bool ExecuteBdv(byte operand)
    {
        ulong numerator = RegisterA;
        int denominator = 1 << (int)Combo(operand); // 2^operand
        RegisterB = numerator / (ulong)denominator;
        return false;
    }

    private bool ExecuteCdv(byte operand)
    {
        ulong numerator = RegisterA;
        int denominator = 1 << (int)Combo(operand); // 2^operand
        RegisterC = numerator / (ulong)denominator;
        return false;
    }
}

internal readonly record struct RegisterValues(ulong A, ulong B, ulong C);
