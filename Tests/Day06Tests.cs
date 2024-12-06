using AdventOfCode.Year2024.Day06;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "06")]
[Trait("Day", "6")]
public sealed class Day06Tests : BaseDayTests<Day06Solver, Day06SolverOptions>
{
    protected override string DayInputsDirectory => "Day06";

    protected override Day06Solver CreateSolver(Day06SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
