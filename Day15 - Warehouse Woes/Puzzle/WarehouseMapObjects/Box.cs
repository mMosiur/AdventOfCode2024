namespace AdventOfCode.Year2024.Day15.Puzzle;

internal sealed partial class WarehouseMap
{
    internal sealed class Box(WarehouseMap map, Point initialPosition) : WarehouseObject(map)
    {
        public Point Position { get; private set; } = initialPosition;
        public int GpsCoordinate => Position.X * 100 + Position.Y;

        public override bool CanMove(MoveDirection direction)
        {
            var moveVector = direction.ToVector();
            var newPosition = Position + moveVector;
            if (!Map.Bounds.Contains(newPosition)) return false;

            if (Map[newPosition] is { } blockingObject)
            {
                // This object can only move if the blocking object can be moved out of the way
                return blockingObject.CanMove(direction);
            }

            return true;
        }

        public override bool TryMove(MoveDirection direction)
        {
            var moveVector = direction.ToVector();
            var newPosition = Position + moveVector;
            if (!Map.Bounds.Contains(newPosition)) return false;

            if (Map[newPosition] is { } blockingObject)
            {
                if (!blockingObject.TryMove(direction))
                {
                    return false;
                }
            }

            Map[Position] = null;
            Map[newPosition] = this;
            Position = newPosition;
            return true;
        }
    }
}
