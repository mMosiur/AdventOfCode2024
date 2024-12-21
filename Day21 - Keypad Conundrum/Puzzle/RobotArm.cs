using AdventOfCode.Year2024.Day21.Puzzle.Keypads;

namespace AdventOfCode.Year2024.Day21.Puzzle;

internal class RobotArm<TKeypad>(TKeypad keypad, DirectionalRobotArm? steeringRobotArm = null)
    where TKeypad : IKeypad
{
    private readonly TKeypad _keypad = keypad;
    private readonly KeypadPathFinder _pathFinder = new(keypad);
    private readonly DirectionalRobotArm? _steeringRobotArm = steeringRobotArm;

    public Point ArmPosition { get; private set; } = keypad.GetPositionOfButton(KeypadButton.Activate);

    public void ResetArmPosition()
    {
        ArmPosition = _keypad.GetPositionOfButton(KeypadButton.Activate);
    }

    public long PressButtonCountingHumanPresses(KeypadButton button)
    {
        if (button is KeypadButton.Gap) throw new("Cannot press a gap");
        var targetPosition = _keypad.GetPositionOfButton(button);

        // Find all shortest paths to the new position
        var pathsToKey = _pathFinder.FindShortestPathsWithPress(ArmPosition, targetPosition);

        if (pathsToKey.Count == 0) throw new InvalidOperationException("No path found to target position");

        ArmPosition = targetPosition;

        if (pathsToKey.Count == 1)
        {
            return CountHumanPresses(pathsToKey[0]);
        }

        long keyPressCount = pathsToKey
            .Select(CountHumanPresses)
            .Min();

        return keyPressCount;
    }

    private long CountHumanPresses(List<DirectionalKeypadButton> pathToKey)
    {
        return _steeringRobotArm is null
            ? pathToKey.Count
            : pathToKey.Sum(b => _steeringRobotArm.PressButtonWithCounting(b));
    }
}

internal sealed class NumericRobotArm(NumericKeypad keypad, DirectionalRobotArm? steeringRobotArm = null)
    : RobotArm<NumericKeypad>(keypad, steeringRobotArm);

internal sealed class DirectionalRobotArm(DirectionalKeypad keypad, DirectionalRobotArm? steeringRobotArm = null)
    : RobotArm<DirectionalKeypad>(keypad, steeringRobotArm)
{
    public long PressButtonWithCounting(DirectionalKeypadButton button)
        => PressButtonCountingHumanPresses((KeypadButton)button);
}
