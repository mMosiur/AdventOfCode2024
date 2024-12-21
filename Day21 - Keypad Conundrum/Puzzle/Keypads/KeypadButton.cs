namespace AdventOfCode.Year2024.Day21.Puzzle.Keypads;

internal enum KeypadButton
{
    Gap = 0,

    One = 1, // '1'
    Two = 2, // '2'
    Three = 3, // '3'
    Four = 4, // '4'
    Five = 5, // '5'
    Six = 6, // '6'
    Seven = 7, // '7'
    Eight = 8, // '8'
    Nine = 9, // '9'
    Zero = 10, // '0'

    Activate = 11, // 'A'

    UpArrow = 12, // '^'
    LeftArrow = 13, // '<'
    DownArrow = 14, // 'v'
    RightArrow = 15, // '>'
}

internal enum NumericKeypadButton
{
    One = KeypadButton.One, // '1'
    Two = KeypadButton.Two, // '2'
    Three = KeypadButton.Three, // '3'
    Four = KeypadButton.Four, // '4'
    Five = KeypadButton.Five, // '5'
    Six = KeypadButton.Six, // '6'
    Seven = KeypadButton.Seven, // '7'
    Eight = KeypadButton.Eight, // '8'
    Nine = KeypadButton.Nine, // '9'
    Zero = KeypadButton.Zero, // '0'

    Activate = KeypadButton.Activate, // 'A'
}

internal enum DirectionalKeypadButton
{
    Activate = KeypadButton.Activate, // 'A'

    UpArrow = KeypadButton.UpArrow, // '^'
    LeftArrow = KeypadButton.LeftArrow, // '<'
    DownArrow = KeypadButton.DownArrow, // 'v'
    RightArrow = KeypadButton.RightArrow, // '>'
}

internal static class KeypadButtonHelpers
{
    public static KeypadButton Parse(char c)
        => c switch
        {
            '1' => KeypadButton.One,
            '2' => KeypadButton.Two,
            '3' => KeypadButton.Three,
            '4' => KeypadButton.Four,
            '5' => KeypadButton.Five,
            '6' => KeypadButton.Six,
            '7' => KeypadButton.Seven,
            '8' => KeypadButton.Eight,
            '9' => KeypadButton.Nine,
            '0' => KeypadButton.Zero,
            'A' => KeypadButton.Activate,
            '^' => KeypadButton.UpArrow,
            '<' => KeypadButton.LeftArrow,
            'v' => KeypadButton.DownArrow,
            '>' => KeypadButton.RightArrow,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, "Invalid keypad button.")
        };
}
