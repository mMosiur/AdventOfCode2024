using AdventOfCode.Year2024.Day03;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "03")]
[Trait("Day", "3")]
public sealed class Day03Tests : BaseDayTests<Day03Solver, Day03SolverOptions>
{
    protected override string DayInputsDirectory => "Day03";

    protected override Day03Solver CreateSolver(Day03SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "161")]
    [InlineData("my-input.txt", "179834255")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
