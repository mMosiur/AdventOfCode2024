using AdventOfCode.Year2024.Day19;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "19")]
public sealed class Day19Tests : BaseDayTests<Day19Solver, Day19SolverOptions>
{
    protected override string DayInputsDirectory => "Day19";

    protected override Day19Solver CreateSolver(Day19SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "6")]
    [InlineData("my-input.txt", "358")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
