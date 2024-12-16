using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day15.Puzzle;

internal sealed class WarehouseRobotMover
{
    private readonly WarehouseMap.Robot _robot;

    public WarehouseRobotMover(WarehouseMap warehouseMap)
    {
        try
        {
            _robot = warehouseMap.OfType<WarehouseMap.Robot>().Single();
        }
        catch (InvalidOperationException)
        {
            throw new DaySolverException("Expected single robot on the warehouse map.");
        }
    }

    public void MakeMove(MoveDirection direction)
    {
        _robot.TryMove(direction);
    }

    public void MakeMoves(IEnumerable<MoveDirection> directions)
    {
        foreach (var direction in directions)
        {
            MakeMove(direction);
        }
    }
}
