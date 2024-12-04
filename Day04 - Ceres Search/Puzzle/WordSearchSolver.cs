namespace AdventOfCode.Year2024.Day04.Puzzle;

internal sealed class WordSearchSolver(WordSearchPuzzle puzzle)
{
    private readonly WordSearchPuzzle _puzzle = puzzle;

    public int CountWords(ReadOnlySpan<char> targetWord)
    {
        if (targetWord.IsEmpty)
        {
            throw new ArgumentException("Target word must not be empty.", nameof(targetWord));
        }

        int count = 0;
        foreach (var point in _puzzle.Bounds.Points)
        {
            int wordsCount = CountWordsStartingAt(targetWord, point);
            count += wordsCount;
        }

        return count;
    }

    private int CountWordsStartingAt(ReadOnlySpan<char> targetWord, Point startPoint)
    {
        if (_puzzle[startPoint] != targetWord[0])
        {
            return 0;
        }

        int wordsCount = 0;
        foreach (var direction in Directions.All)
        {
            if (IsWordInDirection(targetWord, startPoint, direction))
            {
                wordsCount++;
            }
        }

        return wordsCount;
    }

    private bool IsWordInDirection(ReadOnlySpan<char> targetWord, Point startPoint, Vector direction)
    {
        var furthestPoint = startPoint + direction * (targetWord.Length - 1);
        if (!_puzzle.Bounds.Contains(furthestPoint)) return false;

        var point = startPoint;
        foreach (char c in targetWord[1..])
        {
            point += direction;
            if (_puzzle[point] != c)
            {
                return false;
            }
        }

        return true;
    }
}
