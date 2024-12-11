using AdventOfCode.Year2024.Day11;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "11")]
public sealed class Day11Tests : BaseDayTests<Day11Solver, Day11SolverOptions>
{
    protected override string DayInputsDirectory => "Day11";

    protected override Day11Solver CreateSolver(Day11SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "55312")]
    [InlineData("my-input.txt", "186996")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
