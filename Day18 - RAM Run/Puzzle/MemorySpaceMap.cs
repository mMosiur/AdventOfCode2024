namespace AdventOfCode.Year2024.Day18.Puzzle;

internal sealed class MemorySpaceMap(int height, int width)
{
    private readonly MemorySpaceByte[,] _map = new MemorySpaceByte[height, width];

    public int Height => _map.GetLength(0);
    public int Width => _map.GetLength(1);
    public Bounds Bounds { get; } = new(0, width - 1, 0, height - 1);

    public MemorySpaceByte this[int x, int y] => _map[y, x];
    public MemorySpaceByte this[Point point] => this[point.Y, point.X];

    public void FallBytes(IEnumerable<Point> fallingBytePositions)
    {
        try
        {
            foreach (var position in fallingBytePositions)
            {
                _map[position.Y, position.X] = MemorySpaceByte.Corrupted;
            }
        }
        catch (IndexOutOfRangeException)
        {
            throw new ArgumentException("Some points are out of the memory space.");
        }
    }
}

internal enum MemorySpaceByte : byte
{
    Empty = 0,
    Corrupted = 1,
}
