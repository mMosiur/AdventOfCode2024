namespace AdventOfCode.Year2024.Day04.Puzzle;

internal sealed class XWordSearchSolver(WordSearchPuzzle puzzle)
{
    private readonly WordSearchPuzzle _puzzle = puzzle;

    public int CountWords(ReadOnlySpan<char> targetXWord)
    {
        if (targetXWord.Length != 3)
        {
            throw new ArgumentException("Target X-word must be 3 characters long.", nameof(targetXWord));
        }

        int count = 0;
        foreach (var point in _puzzle.Bounds.Points)
        {
            if (IsMiddleOfWordX(targetXWord, point))
            {
                count++;
            }
        }

        return count;
    }

    private bool IsMiddleOfWordX(ReadOnlySpan<char> targetXWord, Point middlePoint)
    {
        if (middlePoint.X == 0 || middlePoint.X == _puzzle.Width - 1 || middlePoint.Y == 0 || middlePoint.Y == _puzzle.Height - 1)
        {
            // Is edge point
            return false;
        }

        if (_puzzle[middlePoint] != targetXWord[1])
        {
            return false;
        }

        int count = 0;

        foreach (var cornerDirection in Directions.Corners)
        {
            var cornerPoint = middlePoint + cornerDirection;
            var otherCornerPoint = middlePoint - cornerDirection;
            if (_puzzle[cornerPoint] == targetXWord[0] && _puzzle[otherCornerPoint] == targetXWord[2])
            {
                count++;
            }
        }

        return count >= 2;
    }
}
