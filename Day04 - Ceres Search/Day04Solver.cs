using AdventOfCode.Common;
using AdventOfCode.Year2024.Day04.Puzzle;

namespace AdventOfCode.Year2024.Day04;

public sealed class Day04Solver : DaySolver<Day04SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 4;
    public override string Title => "Ceres Search";

    private readonly WordSearchPuzzle _wordSearchPuzzle;

    public Day04Solver(Day04SolverOptions options) : base(options)
    {
        _wordSearchPuzzle = InputReader.Read(InputLines);
    }

    public Day04Solver(Action<Day04SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day04Solver() : this(new Day04SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var solver = new SimpleWordSearchSolver(_wordSearchPuzzle);
        int wordCount = solver.CountWords(Options.WordSearchTargetWord);
        return wordCount.ToString();
    }

    public override string SolvePart2()
    {
        var solver = new XWordSearchSolver(_wordSearchPuzzle);
        int wordCount = solver.CountWords(Options.XWordSearchTargetWord);
        return wordCount.ToString();
    }
}