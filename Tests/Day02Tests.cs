using AdventOfCode.Year2024.Day02;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "02")]
[Trait("Day", "2")]
public sealed class Day02Tests : BaseDayTests<Day02Solver, Day02SolverOptions>
{
    protected override string DayInputsDirectory => "Day02";

    protected override Day02Solver CreateSolver(Day02SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "2")]
    [InlineData("my-input.txt", "572")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
