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

        // We can operate under the assumption that the Christmas tres will have safety factor very low,
        // as a lot of pixels will be concentrated in one place around the tree center.

        var bathroomImager = CreateBathroomImagerIfRequested("images");
        bathroomImager?.PrepareFolder();

        int minSafetyFactor = int.MaxValue;
        int minSafetyFactorIndex = -1;
        for (int i = _bathroom.SecondsPassed + 1; i <= 10_000; i++)
        {
            _bathroom.SimulateSecond();

            bathroomImager?.GenerateImage(filenameWithoutExtension: $"bathroom_{i}");

            int safetyFactor = _bathroom.SafetyFactor();
            if (safetyFactor >= minSafetyFactor) continue;

            minSafetyFactor = safetyFactor;
            minSafetyFactorIndex = i; // Seconds passed to get that minimum safety factor
        }

        return minSafetyFactorIndex.ToString();
    }

    private BathroomImager? CreateBathroomImagerIfRequested(string folderName)
    {
        return Options.GenerateImages
            ? new BathroomImager(_bathroom, folderName)
            : null;
    }
}
