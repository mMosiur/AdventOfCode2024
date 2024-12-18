namespace AdventOfCode.Year2024.Day17.Puzzle;

internal sealed class QuineSearcher(Computer computer)
{
    private readonly Computer _computer = computer;

    public List<ulong> QuineProducingRegisterA(IReadOnlyList<byte> program)
    {
        List<ulong> possibleAValues = [0];

        for (int programIndex = program.Count - 1; programIndex >= 0; programIndex--)
        {
            byte expectedOutput = program[programIndex];
            possibleAValues = GetAValuesProducingOutput(program, possibleAValues, expectedOutput).ToList();
        }

        return possibleAValues;
    }

    private IEnumerable<ulong> GetAValuesProducingOutput(IReadOnlyList<byte> program, List<ulong> possibleAValues, byte expectedOutput)
    {
        foreach (ulong expectedAValue in possibleAValues)
        {
            for (int lowerA = 0; lowerA < 8; lowerA++)
            {
                ulong a = expectedAValue << 3 | (uint)lowerA;
                _computer.Reset(new(a, 0, 0));
                byte firstOutput = _computer.RunProgram(program).First();
                if (firstOutput == expectedOutput)
                {
                    yield return a;
                }
            }
        }
    }
}
