using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day01;

public sealed class Day01Solver : DaySolver<Day01SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 1;
    public override string Title => "Historian Hysteria";

    private readonly IReadOnlyList<int> _leftInputList;
    private readonly IReadOnlyList<int> _rightInputList;

    public Day01Solver(Day01SolverOptions options) : base(options)
    {
        (_leftInputList, _rightInputList) = InputReader.Read(Input);
    }

    public Day01Solver(Action<Day01SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day01Solver() : this(new Day01SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var leftList = _leftInputList.ToList();
        var rightList = _rightInputList.ToList();

        leftList.Sort();
        rightList.Sort();

        long pairDistancesSum = 0;
        foreach ((int leftListNumber, int rightListNumber) in leftList.Zip(rightList))
        {
            int distance = Math.Abs(leftListNumber - rightListNumber);
            pairDistancesSum += distance;
        }

        return pairDistancesSum.ToString();
    }

    public override string SolvePart2()
    {
        var leftList = _leftInputList.ToList();
        var rightList = _rightInputList.ToList();

        leftList.Sort();
        rightList.Sort();

        long similarityScoreSum = 0;
        foreach (int leftListNumber in leftList)
        {
            int countRightAppearances = rightList.Count(rln => rln == leftListNumber);
            int similarityScore = countRightAppearances * leftListNumber;
            similarityScoreSum += similarityScore;
        }

        return similarityScoreSum.ToString();
    }
}
