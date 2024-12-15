namespace AdventOfCode.Year2024.Day15.Puzzle;

internal sealed partial class WarehouseMap
{
    public abstract class WarehouseObject(WarehouseMap map, Point initialPosition)
    {
        private readonly WarehouseMap _map = map;
        public Point Position { get; protected set; } = initialPosition;

        public virtual bool TryMove(MoveDirection direction)
        {
            var moveVector = direction.ToVector();
            var newPosition = Position + moveVector;
            if (!_map.Bounds.Contains(newPosition)) return false;

            if (_map[newPosition] is { } blockingObject)
            {
                blockingObject.TryMove(direction);
            }

            if (_map[newPosition] is not null)
            {
                return false;
            }

            _map[Position] = null;
            _map[newPosition] = this;
            Position = newPosition;
            return true;
        }
    }

    internal sealed class Robot(WarehouseMap map, Point initialPosition) : WarehouseObject(map, initialPosition);

    internal sealed class Box(WarehouseMap map, Point initialPosition) : WarehouseObject(map, initialPosition)
    {
        public int GpsCoordinate => Position.X * 100 + Position.Y;
    }

    internal sealed class Wall(WarehouseMap map, Point initialPosition) : WarehouseObject(map, initialPosition)
    {
        public override bool TryMove(MoveDirection direction)
        {
            return false;
        }
    }
}
