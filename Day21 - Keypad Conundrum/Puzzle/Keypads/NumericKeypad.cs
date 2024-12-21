namespace AdventOfCode.Year2024.Day21.Puzzle.Keypads;

internal sealed class NumericKeypad : IKeypad
{
    private static readonly Bounds KeypadBounds = new(0, 3, 0, 2);

    private static readonly KeypadButton[,] Buttons = new KeypadButton[4, 3]
    {
        { KeypadButton.Seven, KeypadButton.Eight, KeypadButton.Nine },
        { KeypadButton.Four, KeypadButton.Five, KeypadButton.Six },
        { KeypadButton.One, KeypadButton.Two, KeypadButton.Three },
        { KeypadButton.Gap, KeypadButton.Zero, KeypadButton.Activate },
    };

    private static readonly Point[] ButtonPositions = new Point[12]
    {
        new(3, 0), //  0 = KeypadButton.Gap
        new(2, 0), //  1 = KeypadButton.One
        new(2, 1), //  2 = KeypadButton.Two
        new(2, 2), //  3 = KeypadButton.Three
        new(1, 0), //  4 = KeypadButton.Four
        new(1, 1), //  5 = KeypadButton.Five
        new(1, 2), //  6 = KeypadButton.Six
        new(0, 0), //  7 = KeypadButton.Seven
        new(0, 1), //  8 = KeypadButton.Eight
        new(0, 2), //  9 = KeypadButton.Nine
        new(3, 1), // 10 = KeypadButton.Zero
        new(3, 2), // 11 = KeypadButton.Activate
    };

    public KeypadButton GetButton(Point point)
    {
        if (!KeypadBounds.Contains(point))
        {
            throw new ArgumentOutOfRangeException(nameof(point), point, "Invalid keypad button position.");
        }

        return Buttons[point.X, point.Y];
    }

    public Point GetPositionOfButton(KeypadButton button)
    {
        int buttonNumber = (int)button;
        if (buttonNumber < 0 || buttonNumber >= ButtonPositions.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(button), button, "Invalid keypad button.");
        }

        return ButtonPositions[buttonNumber];
    }
}
