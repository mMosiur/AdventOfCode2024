using AdventOfCode.Common;
using AdventOfCode.Year2024.Day15.Puzzle;

namespace AdventOfCode.Year2024.Day15;

public sealed class Day15Solver : DaySolver<Day15SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 15;
    public override string Title => "Warehouse Woes";

    private readonly char[,] _warehouseCharMap;
    private readonly char[,] _widenedWarehouseCharMap;
    private readonly MoveDirection[] _robotMovementList;

    public Day15Solver(Day15SolverOptions options) : base(options)
    {
        (_warehouseCharMap, _robotMovementList) = InputReader.Read(Input);
        _widenedWarehouseCharMap = InputReader.WidenInputWarehouse(_warehouseCharMap);
    }

    public Day15Solver(Action<Day15SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day15Solver() : this(new Day15SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var warehouseMap = WarehouseMap.CreateFromCharMap(_warehouseCharMap);
        var robotMover = new WarehouseRobotMover(warehouseMap);
        robotMover.MakeMoves(_robotMovementList);
        var boxes = warehouseMap.OfType<WarehouseMap.Box>().ToList();
        int gpsCoordinateSum = boxes.Sum(box => box.GpsCoordinate);
        return gpsCoordinateSum.ToString();
    }

    public override string SolvePart2()
    {
        var warehouseMap = WarehouseMap.CreateFromCharMap(_widenedWarehouseCharMap);
        var robotMover = new WarehouseRobotMover(warehouseMap);
        robotMover.MakeMoves(_robotMovementList);
        var boxes = warehouseMap.OfType<WarehouseMap.WideBox>().Distinct().ToList();
        int gpsCoordinateSum = boxes.Sum(box => box.GpsCoordinate);
        return gpsCoordinateSum.ToString();
    }
}
