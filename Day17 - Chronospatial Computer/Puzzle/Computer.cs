using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day17.Puzzle;

internal sealed class Computer(int registerA, int registerB, int registerC)
{
    private int _registerA = registerA;
    private int _registerB = registerB;
    private int _registerC = registerC;

    private int _instructionPointer = 0;


    public IEnumerable<byte> RunProgram(IReadOnlyList<byte> program)
    {
        _instructionPointer = 0;
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

    private int Combo(byte operand)
        => operand switch
        {
            < 4 => operand,
            4 => _registerA,
            5 => _registerB,
            6 => _registerC,
            7 => throw new DaySolverException("Reserved combo operand 7"),
            _ => throw new ArgumentOutOfRangeException(nameof(operand), operand, null)
        };

    private bool ExecuteAdv(byte operand)
    {
        int numerator = _registerA;
        int denominator = 1 << Combo(operand); // 2^operand
        _registerA = numerator / denominator;
        return false;
    }

    private bool ExecuteBxl(byte operand)
    {
        _registerB = _registerB ^ Literal(operand);
        return false;
    }

    private bool ExecuteBst(byte operand)
    {
        _registerB = Combo(operand) % 8;
        return false;
    }

    private bool ExecuteJnz(byte operand)
    {
        if (_registerA == 0) return false;
        _instructionPointer = Literal(operand);
        return true;
    }

    private bool ExecuteBxc(byte operand)
    {
        _registerB = _registerB ^ _registerC;
        return false;
    }

    private bool ExecuteOut(byte operand, out byte? output)
    {
        output = (byte)(Combo(operand) % 8);
        return false;
    }

    private bool ExecuteBdv(byte operand)
    {
        int numerator = _registerA;
        int denominator = 1 << Combo(operand); // 2^operand
        _registerB = numerator / denominator;
        return false;
    }

    private bool ExecuteCdv(byte operand)
    {
        int numerator = _registerA;
        int denominator = 1 << Combo(operand); // 2^operand
        _registerC = numerator / denominator;
        return false;
    }
}
