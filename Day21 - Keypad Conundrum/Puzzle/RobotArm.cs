using AdventOfCode.Year2024.Day21.Puzzle.Keypads;

namespace AdventOfCode.Year2024.Day21.Puzzle;

internal class RobotArm<TKeypad>(TKeypad keypad, DirectionalRobotArm? steeringRobotArm = null)
    where TKeypad : IKeypad
{
    private readonly TKeypad _keypad = keypad;
    private readonly KeypadPathFinder _pathFinder = new(keypad);
    private readonly DirectionalRobotArm? _steeringRobotArm = steeringRobotArm;
    private readonly Dictionary<(Point, KeypadButton), RobotArmKeyPressesCachedState> _pressCountCache = new();

    public Point ArmPosition { get; private set; } = keypad.GetPositionOfButton(KeypadButton.Activate);

    public void ResetArmPosition()
    {
        ArmPosition = _keypad.GetPositionOfButton(KeypadButton.Activate);
    }

    public long PressButtonCountingHumanPresses(KeypadButton button)
    {
        var cacheKey = (ArmPosition, button);

        if (_pressCountCache.TryGetValue(cacheKey, out var cachedState))
        {
            ApplyCacheState(cachedState.RobotArmState);
            return cachedState.KeyPressCount;
        }

        long keyPressCount = PressButtonCountingHumanPressesInternal(button);

        _pressCountCache[cacheKey] = new(GetCacheState(), keyPressCount);
        return keyPressCount;
    }

    private long PressButtonCountingHumanPressesInternal(KeypadButton button)
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

    private RobotArmCachedState GetCacheState() => new(ArmPosition, _steeringRobotArm?.GetCacheState());

    private void ApplyCacheState(RobotArmCachedState state)
    {
        ArmPosition = state.ArmPosition;
        _steeringRobotArm?.ApplyCacheState(state.SteeringRobotState!);
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

internal sealed record RobotArmKeyPressesCachedState(RobotArmCachedState RobotArmState, long KeyPressCount);

internal sealed record RobotArmCachedState(Point ArmPosition, RobotArmCachedState? SteeringRobotState = null);
