using AdventOfCode.Year2024.Day23;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "23")]
public sealed class Day23Tests : BaseDayTests<Day23Solver, Day23SolverOptions>
{
    protected override string DayInputsDirectory => "Day23";

    protected override Day23Solver CreateSolver(Day23SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "7")]
    [InlineData("my-input.txt", "926")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
