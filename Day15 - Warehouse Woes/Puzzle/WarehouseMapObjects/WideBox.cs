namespace AdventOfCode.Year2024.Day15.Puzzle;

internal sealed partial class WarehouseMap
{
    internal sealed class WideBox(WarehouseMap map, Point initialLeftPosition) : WarehouseObject(map)
    {
        public Point LeftPosition { get; private set; } = initialLeftPosition;
        public Point RightPosition => LeftPosition with { Y = LeftPosition.Y + 1 };

        public int GpsCoordinate => LeftPosition.X * 100 + LeftPosition.Y;

        public override bool CanMove(MoveDirection direction)
        {
            var moveVector = direction.ToVector();
            var newLeftPosition = LeftPosition + moveVector;
            var newRightPosition = newLeftPosition with { Y = newLeftPosition.Y + 1 };

            if (!Map.Bounds.Contains(newLeftPosition) || !Map.Bounds.Contains(newRightPosition))
            {
                return false;
            }

            if (Map[newLeftPosition] is { } blockingLeftObject && !ReferenceEquals(blockingLeftObject, this))
            {
                if (!blockingLeftObject.CanMove(direction))
                {
                    // If left blocking object cannot be moved, neither can this object
                    return false;
                }
            }

            if (Map[newRightPosition] is { } blockingRightObject && !ReferenceEquals(blockingRightObject, this))
            {
                if (!blockingRightObject.CanMove(direction))
                {
                    // If right blocking object cannot be moved, neither can this object
                    return false;
                }
            }

            // If no blocking objects, or blocking objects can be moved, this object can be moved
            return true;
        }

        public override bool TryMove(MoveDirection direction)
        {
            if (!CanMove(direction))
            {
                return false;
            }

            var moveVector = direction.ToVector();
            var newLeftPosition = LeftPosition + moveVector;
            var newRightPosition = newLeftPosition with { Y = newLeftPosition.Y + 1 };

            if (Map[newLeftPosition] is { } blockingLeftObject && !ReferenceEquals(Map[newLeftPosition], this))
            {
                if (!blockingLeftObject.TryMove(direction))
                {
                    throw new InvalidOperationException("Unexpected failed move");
                }
            }

            if (Map[newRightPosition] is { } blockingRightObject && !ReferenceEquals(Map[newRightPosition], this))
            {
                if (!blockingRightObject.TryMove(direction))
                {
                    throw new InvalidOperationException("Unexpected failed move");
                }
            }

            Map[LeftPosition] = null;
            Map[RightPosition] = null;
            Map[newLeftPosition] = this;
            Map[newRightPosition] = this;

            LeftPosition = newLeftPosition;
            return true;
        }
    }
}
