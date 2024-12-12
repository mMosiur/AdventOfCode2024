using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day12.Puzzle;

internal sealed class GardenPlotMap
{
    private readonly PlantType[,] _plotMap;

    public int Height { get; }
    public int Width { get; }
    public Rectangle<int> Bounds { get; }

    public GardenPlotMap(PlantType[,] plotMap)
    {
        _plotMap = plotMap;
        Height = plotMap.GetLength(0);
        Width = plotMap.GetLength(1);
        Bounds = new(0, Height - 1, 0, Width - 1);
    }

    public PlantType this[int row, int col] => _plotMap[row, col];
    public PlantType this[Point point] => this[point.X, point.Y];
}
