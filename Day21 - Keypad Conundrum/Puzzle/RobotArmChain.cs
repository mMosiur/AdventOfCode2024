namespace AdventOfCode.Year2024.Day21.Puzzle;

internal sealed class RobotArmChain
{
    private readonly NumericRobotArm _depressurizedAreaRobot;

    public RobotArmChain(int directionalRobotCount)
    {
        DirectionalRobotArm? previousRobot = null;
        for (int i = 0; i < directionalRobotCount; i++)
        {
            var nextRobot = new DirectionalRobotArm(new(), previousRobot);
            previousRobot = nextRobot;
        }

        _depressurizedAreaRobot = new NumericRobotArm(new(), previousRobot);
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
