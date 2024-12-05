namespace AdventOfCode.Year2024.Day05.Puzzle;

internal sealed class ManualUpdateOrderValidator
{
    private readonly PageOrderingRules _pageOrderingRules;

    public ManualUpdateOrderValidator(PageOrderingRules pageOrderingRules)
    {
        _pageOrderingRules = pageOrderingRules;
    }

    public (List<ManualUpdate> CorrectlyOrderedUpdates, List<ManualUpdate> IncorrectlyOrderedUpdates) SplitIntoOrderedAndUnordered(IEnumerable<ManualUpdate> manualUpdates)
    {
        var correctlyOrderedUpdates = new List<ManualUpdate>();
        var incorrectlyOrderedUpdates = new List<ManualUpdate>();

        foreach (var manualUpdate in manualUpdates)
        {
            var updatesList = IsManualUpdateInCorrectOrder(manualUpdate)
                ? correctlyOrderedUpdates
                : incorrectlyOrderedUpdates;
            updatesList.Add(manualUpdate);
        }

        return (correctlyOrderedUpdates, incorrectlyOrderedUpdates);
    }

    public bool IsManualUpdateInCorrectOrder(ManualUpdate manualUpdate)
    {
        for (int pi = 0; pi < manualUpdate.PageNumbers.Count; pi++)
        {
            int pageNumber = manualUpdate.PageNumbers[pi];
            for (int fi = pi + 1; fi < manualUpdate.PageNumbers.Count; fi++)
            {
                int followingPageNumber = manualUpdate.PageNumbers[fi];

                if (_pageOrderingRules.GetFollowingPages(followingPageNumber).Contains(pageNumber)
                 || _pageOrderingRules.GetPrecedingPages(pageNumber).Contains(followingPageNumber))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
