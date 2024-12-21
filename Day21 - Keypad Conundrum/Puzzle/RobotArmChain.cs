using AdventOfCode.Year2024.Day21.Puzzle.Keypads;

namespace AdventOfCode.Year2024.Day21.Puzzle;

internal sealed class RobotArmChain
{
    private readonly NumericRobotArm _depressurizedAreaRobot;

    public RobotArmChain()
    {
        var historianRoomKeypad = new DirectionalKeypad(); // Controlling the freezing room robot
        var freezingRoomKeypad = new DirectionalKeypad(); // Controlling the high radiation room robot
        var highRadiationRoomKeypad = new DirectionalKeypad(); // Controlling the depressurized room robot
        var depressurizedRoomKeypad = new NumericKeypad(); // The door keypad

        var freezingAreaRobot = new DirectionalRobotArm(freezingRoomKeypad);
        var highRadiationAreaRobot = new DirectionalRobotArm(highRadiationRoomKeypad, freezingAreaRobot);
        _depressurizedAreaRobot = new NumericRobotArm(depressurizedRoomKeypad, highRadiationAreaRobot);
    }

    public long CalculateComplexity(DoorCode doorCode)
    {
        _depressurizedAreaRobot.ResetArmPosition();
        long keyPressCount = doorCode.KeyPresses
            .Sum(key => _depressurizedAreaRobot.PressButtonCountingHumanPresses(key));
        int numericPart = doorCode.GetNumericPart();
        long codeComplexity = keyPressCount * numericPart;
        return codeComplexity;
    }
}
