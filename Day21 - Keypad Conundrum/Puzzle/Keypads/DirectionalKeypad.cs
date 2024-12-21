namespace AdventOfCode.Year2024.Day21.Puzzle.Keypads;

internal sealed class DirectionalKeypad : IKeypad
{
    private static readonly Bounds KeypadBounds = new(0, 1, 0, 2);

    private static readonly KeypadButton[,] Buttons = new KeypadButton[2, 3]
    {
        { KeypadButton.Gap, KeypadButton.UpArrow, KeypadButton.Activate },
        { KeypadButton.LeftArrow, KeypadButton.DownArrow, KeypadButton.RightArrow },
    };

    private static readonly Point[] ButtonPositions = new Point[6]
    {
        new(0, 0), // 0 = DirectionalKeypadButton.Gap
        new(0, 2), // 11 = DirectionalKeypadButton.Activate
        new(0, 1), // 12 = DirectionalKeypadButton.UpArrow
        new(1, 0), // 13 = DirectionalKeypadButton.LeftArrow
        new(1, 1), // 14 = DirectionalKeypadButton.DownArrow
        new(1, 2), // 15 = DirectionalKeypadButton.RightArrow
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
        if (button == KeypadButton.Gap) return ButtonPositions[0];
        int buttonNumber = (int)button;
        if (buttonNumber is < 11 or > 15)
        {
            throw new ArgumentOutOfRangeException(nameof(button), button, "Invalid keypad button.");
        }

        return ButtonPositions[buttonNumber - 10];
    }
}
