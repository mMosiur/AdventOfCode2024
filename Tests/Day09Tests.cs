using AdventOfCode.Year2024.Day09;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "09")]
[Trait("Day", "9")]
public sealed class Day09Tests : BaseDayTests<Day09Solver, Day09SolverOptions>
{
    protected override string DayInputsDirectory => "Day09";

    protected override Day09Solver CreateSolver(Day09SolverOptions options) => new(options);

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
