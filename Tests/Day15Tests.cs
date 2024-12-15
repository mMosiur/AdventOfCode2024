using AdventOfCode.Year2024.Day15;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "15")]
public sealed class Day15Tests : BaseDayTests<Day15Solver, Day15SolverOptions>
{
    protected override string DayInputsDirectory => "Day15";

    protected override Day15Solver CreateSolver(Day15SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt-1", "", Skip = "Unsolved yet")]
    [InlineData("example-input.txt-2", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt-1", "", Skip = "Unsolved yet")]
    [InlineData("example-input.txt-2", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
