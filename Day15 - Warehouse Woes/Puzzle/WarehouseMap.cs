using System.Collections;

namespace AdventOfCode.Year2024.Day15.Puzzle;

internal sealed partial class WarehouseMap : IEnumerable<WarehouseMap.WarehouseObject?>
{
    private readonly WarehouseObject?[,] _map;

    private WarehouseMap(WarehouseObject?[,] map)
    {
        _map = map;
        Bounds = new(0, map.GetLength(0) - 1, 0, map.GetLength(1) - 1);
    }

    public Bounds Bounds { get; }

    public WarehouseObject? this[Point point]
    {
        get => _map[point.X, point.Y];
        private set => _map[point.X, point.Y] = value;
    }

    public static WarehouseMap CreateFromCharMap(char[,] map)
    {
        var warehouseRawMap = new WarehouseObject?[map.GetLength(0), map.GetLength(1)];
        var warehouseMap = new WarehouseMap(warehouseRawMap);
        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                var point = new Point(row, col);
                warehouseRawMap[row, col] = map[row, col] switch
                {
                    '.' => null,
                    '#' => new Wall(warehouseMap, point),
                    '@' => new Robot(warehouseMap, point),
                    'O' => new Box(warehouseMap, point),
                    _ => throw new InvalidOperationException($"Unknown map character '{map[row, col]}'")
                };
            }
        }

        return warehouseMap;
    }

    public IEnumerator<WarehouseObject?> GetEnumerator() => _map.Cast<WarehouseObject?>().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
