using AdventOfCode.Common;
using AdventOfCode.Common.EnumerableExtensions;

namespace AdventOfCode.Year2024.Day25.Puzzle;

internal static class InputReader
{
    private const char EmptyChar = '.';
    private const char FilledChar = '#';

    public static (List<LockPins> Locks, List<Key> Keys) Read(IEnumerable<string> inputLines)
    {
        List<LockPins> locks = new();
        List<Key> keys = new();
        foreach (var inputGroup in inputLines.SplitWithSeparator(string.Empty))
        {
            if (IsLockGroup(inputGroup))
            {
                LockPins lockPins = ParseLockPins(inputGroup);
                locks.Add(lockPins);
            }
            else if (IsKeyGroup(inputGroup))
            {
                Key key = ParseKey(inputGroup);
                keys.Add(key);
            }
            else
            {
                throw new InputException("Invalid input");
            }
        }

        return (locks, keys);
    }

    private static bool IsLockGroup(IReadOnlyList<string> inputGroup)
    {
        return inputGroup[0].All(c => c is FilledChar)
            && inputGroup[^1].All(c => c is EmptyChar);
    }

    private static LockPins ParseLockPins(IReadOnlyList<string> inputGroup)
    {
        int height = inputGroup.Count - 1;
        int width = inputGroup[0].Length;
        int[] pins = new int[width];

        for (int c = 0; c < width; c++)
        {
            bool columnFinished = false;
            for (int r = 1; r < height; r++)
            {
                if (inputGroup[r][c] is FilledChar)
                {
                    if (columnFinished) throw new InputException("Invalid lock input");
                    pins[c]++;
                }
                else if (inputGroup[r][c] is EmptyChar)
                {
                    columnFinished = true;
                    break;
                }
            }
        }

        return new(height - 1, pins);
    }

    private static bool IsKeyGroup(IReadOnlyList<string> inputGroup)
    {
        return inputGroup[0].All(c => c is EmptyChar)
            && inputGroup[^1].All(c => c is FilledChar);
    }

    private static Key ParseKey(IReadOnlyList<string> inputGroup)
    {
        int height = inputGroup.Count - 1;
        int width = inputGroup[0].Length;
        int[] heights = new int[width];

        for (int c = 0; c < width; c++)
        {
            bool columnFinished = false;
            for (int r = height - 1; r > 0; r--)
            {
                if (inputGroup[r][c] is FilledChar)
                {
                    if (columnFinished) throw new InputException("Invalid key input");
                    heights[c]++;
                }
                else if (inputGroup[r][c] is EmptyChar)
                {
                    columnFinished = true;
                    break;
                }
            }
        }

        return new(heights);
    }
}
