namespace AdventOfCode.Year2024.Day21.Puzzle.Keypads;

internal interface IKeypad
{
    public KeypadButton GetButton(Point point);
    public Point GetPositionOfButton(KeypadButton button);
}
