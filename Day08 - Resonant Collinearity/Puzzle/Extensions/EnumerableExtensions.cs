namespace AdventOfCode.Year2024.Day08.Puzzle.Extensions;

internal static class EnumerableExtensions
{
    public static IEnumerable<(T, T)> UniquePairs<T>(this List<T> source)
    {
        for (int i = 0; i < source.Count; i++)
        {
            for (int j = i + 1; j < source.Count; j++)
            {
                yield return (source[i], source[j]);
            }
        }
    }
}
