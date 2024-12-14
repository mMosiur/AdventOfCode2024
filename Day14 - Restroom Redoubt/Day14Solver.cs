using AdventOfCode.Common;
using AdventOfCode.Year2024.Day14.Puzzle;

namespace AdventOfCode.Year2024.Day14;

public sealed class Day14Solver : DaySolver<Day14SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 14;
    public override string Title => "Restroom Redoubt";

    private readonly Bathroom _bathroom;

    public Day14Solver(Day14SolverOptions options) : base(options)
    {
        _bathroom = new(
            bounds: new(0, options.BathroomWidth - 1, 0, options.BathroomHeight - 1),
            robots: InputReader.Read(Input)
        );
    }

    public Day14Solver(Action<Day14SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day14Solver() : this(new Day14SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        _bathroom.SimulateSeconds(100);
        int safetyFactor = _bathroom.SafetyFactor();
        return safetyFactor.ToString();
    }

    public override string SolvePart2()
    {
        if (_bathroom.Width < 31 || _bathroom.Height < 33)
        {
            return "Bathroom is too small to contain christmas tree at any point.";
        }

        const string imagesFolder = "images";
        var bathroomImager = new BathroomImager(_bathroom, imagesFolder);
        bathroomImager.SimulateSecondsWithImages(10_000);
        return $"Look for christmas tree in folder \"{imagesFolder}\".";
    }
}
