namespace AdventOfCode.Year2024.Day05.Puzzle;

internal sealed class UpdateOrderValidator
{
    private readonly PageOrderingRules _pageOrderingRules;

    public UpdateOrderValidator(PageOrderingRules pageOrderingRules)
    {
        _pageOrderingRules = pageOrderingRules;
    }

    public IEnumerable<ManualUpdate> FilterCorrectlyOrderedUpdates(IEnumerable<ManualUpdate> manualUpdates)
    {
        return manualUpdates.Where(IsManualUpdateInCorrectOrder);
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
