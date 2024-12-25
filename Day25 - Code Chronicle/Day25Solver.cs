using AdventOfCode.Common;
using AdventOfCode.Year2024.Day25.Puzzle;

namespace AdventOfCode.Year2024.Day25;

public sealed class Day25Solver : DaySolver<Day25SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 25;
    public override string Title => "Code Chronicle";

    private readonly IReadOnlyList<LockPins> _locks;
    private readonly IReadOnlyList<Key> _keys;

    public Day25Solver(Day25SolverOptions options) : base(options)
    {
        (_locks, _keys) = InputReader.Read(InputLines);
    }

    public Day25Solver(Action<Day25SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day25Solver() : this(new Day25SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        int count = _locks.Sum(lockPins => _keys.Count(key => key.DoesFit(lockPins)));

        return count.ToString();
    }

    public override string SolvePart2()
    {
        // No part two, Merry Christmas!
        return "";
    }
}
