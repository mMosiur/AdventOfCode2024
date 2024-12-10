using AdventOfCode.Year2024.Day10;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "10")]
public sealed class Day10Tests : BaseDayTests<Day10Solver, Day10SolverOptions>
{
    protected override string DayInputsDirectory => "Day10";

    protected override Day10Solver CreateSolver(Day10SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input-1.txt", "", Skip = "Unsolved yet")]
    [InlineData("example-input-2.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input-2.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
