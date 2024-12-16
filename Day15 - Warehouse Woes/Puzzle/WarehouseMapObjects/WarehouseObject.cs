namespace AdventOfCode.Year2024.Day15.Puzzle;

internal sealed partial class WarehouseMap
{
    internal abstract class WarehouseObject(WarehouseMap map)
    {
        protected readonly WarehouseMap Map = map;

        public abstract bool CanMove(MoveDirection direction);
        public abstract bool TryMove(MoveDirection direction);
    }
}
