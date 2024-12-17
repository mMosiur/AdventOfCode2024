using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day16;

public sealed class Day16SolverOptions : DaySolverOptions
{
    public string StartingDirectionName { get; set; } = "East";
    public int ForwardMoveScore { get; set; } = 1;
    public int TurnMoveScore { get; set; } = 1000;
}
