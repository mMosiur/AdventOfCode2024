using AdventOfCode.Year2024.Day21.Puzzle.Keypads;

namespace AdventOfCode.Year2024.Day21.Puzzle;

internal sealed class DoorCode(IEnumerable<KeypadButton> code)
{
    private readonly KeypadButton[] _code = code.ToArray();

    public IReadOnlyList<KeypadButton> KeyPresses => _code;

    public int GetNumericPart()
    {
        int numericPart = 0;
        foreach (var button in _code)
        {
            if (button is KeypadButton.Activate) break;
            int buttonDigit = (int)button;
            if (buttonDigit is < 1 or > 10)
                throw new InvalidOperationException("Invalid numeric keypad button.");
            numericPart = numericPart * 10 + (int)button % 10; // Modulo 10 as 0 is represented by 10
        }

        return numericPart;
    }
}
