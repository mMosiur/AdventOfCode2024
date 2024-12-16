namespace AdventOfCode.Year2024.Day15.Puzzle;

internal sealed partial class WarehouseMap
{
    internal sealed class Wall(WarehouseMap map) : WarehouseObject(map)
    {
        public override bool CanMove(MoveDirection direction)
        {
            return false;
        }

        public override bool TryMove(MoveDirection direction)
        {
            return false;
        }
    }
}
