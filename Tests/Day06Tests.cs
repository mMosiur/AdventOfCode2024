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
    [InlineData("example-input.txt", "41")]
    [InlineData("my-input.txt", "4433")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "6")]
    [InlineData("my-input.txt", "1516")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
