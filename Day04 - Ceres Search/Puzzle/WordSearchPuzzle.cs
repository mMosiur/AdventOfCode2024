using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day04.Puzzle;

internal sealed class WordSearchPuzzle(char[,] wordSearchPuzzle)
{
    private readonly char[,] _wordSearchPuzzle = wordSearchPuzzle;

    public Rectangle<int> Bounds => new(0, Width - 1, 0, Height - 1);
    public int Width => _wordSearchPuzzle.GetLength(0);
    public int Height => _wordSearchPuzzle.GetLength(1);

    public char this[int x, int y] => _wordSearchPuzzle[x, y];
    public char this[Point p] => this[p.X, p.Y];
}
