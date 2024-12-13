using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day13;

public sealed class Day13SolverOptions : DaySolverOptions
{
    public int ButtonATokenCost { get; set; } = 3;
    public int ButtonBTokenCost { get; set; } = 1;
    public long PricePositionError { get; set; } = 10000000000000;
}
