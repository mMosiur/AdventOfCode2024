namespace AdventOfCode.Year2024.Day05.Puzzle;

internal sealed class PageOrderingRules
{
    private static readonly HashSet<int> EmptySet = [];
    private readonly Dictionary<int, HashSet<int>> _precedingToFollowingRules;
    private readonly Dictionary<int, HashSet<int>> _followingToPrecedingRules;

    public PageOrderingRules(IReadOnlyCollection<PageOrderingRule> pageOrderingRules)
    {
        _precedingToFollowingRules = new(pageOrderingRules.Count);
        _followingToPrecedingRules = new(pageOrderingRules.Count);

        foreach (var pageOrderingRule in pageOrderingRules)
        {
            if (!_precedingToFollowingRules.TryGetValue(pageOrderingRule.PrecedingPageNumber, out var followingPageNumbers))
            {
                followingPageNumbers = new(1);
                _precedingToFollowingRules.Add(
                    key: pageOrderingRule.PrecedingPageNumber,
                    value: followingPageNumbers);
            }

            followingPageNumbers.Add(pageOrderingRule.FollowingPageNumber);

            if (!_followingToPrecedingRules.TryGetValue(pageOrderingRule.FollowingPageNumber, out var precedingPageNumbers))
            {
                precedingPageNumbers = new(1);
                _followingToPrecedingRules.Add(
                    key: pageOrderingRule.FollowingPageNumber,
                    value: precedingPageNumbers);
            }

            precedingPageNumbers.Add(pageOrderingRule.PrecedingPageNumber);
        }
    }

    public IReadOnlySet<int> GetFollowingPages(int precedingPageNumber)
    {
        return _precedingToFollowingRules.GetValueOrDefault(precedingPageNumber, EmptySet);
    }

    public IReadOnlySet<int> GetPrecedingPages(int followingPageNumber)
    {
        return _followingToPrecedingRules.GetValueOrDefault(followingPageNumber, EmptySet);
    }
}

internal record PageOrderingRule(int PrecedingPageNumber, int FollowingPageNumber);
