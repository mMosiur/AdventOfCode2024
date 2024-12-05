namespace AdventOfCode.Year2024.Day05.Puzzle;

internal sealed class ManualUpdateSorter(PageOrderingRules pageOrderingRules)
{
    private readonly PageOrderingRules _pageOrderingRules = pageOrderingRules;

    public ManualUpdate Reordered(ManualUpdate manualUpdate)
    {
        var pageNumberToFollowingPageNumbersDictionary = manualUpdate.PageNumbers
            .ToDictionary(pageNumber => pageNumber, pageNumber => _pageOrderingRules.GetFollowingPages(pageNumber).ToHashSet());

        // Only consider page numbers that are present in the manual update sequence
        foreach (var followingPageNumbersSet in pageNumberToFollowingPageNumbersDictionary.Values)
        {
            followingPageNumbersSet.IntersectWith(manualUpdate.PageNumbers);
        }

        // Order by the number of following page numbers in descending order,
        // So that last number has 0 following page numbers and each next number has more following page numbers
        var orderedPageNumbers = pageNumberToFollowingPageNumbersDictionary.OrderByDescending(x => x.Value.Count).Select(x => x.Key).ToList();

        return new(orderedPageNumbers);
    }
}
