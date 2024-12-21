namespace AdventOfCode.Year2024.Day21.Puzzle;

internal static class ListExtensions
{
    public static void AddIfNotNull<T>(this List<T> list, T? item)
        where T : class
    {
        if (item is not null)
        {
            list.Add(item);
        }
    }
}
