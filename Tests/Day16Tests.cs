using AdventOfCode.Year2024.Day16;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "16")]
public sealed class Day16Tests : BaseDayTests<Day16Solver, Day16SolverOptions>
{
    protected override string DayInputsDirectory => "Day16";

    protected override Day16Solver CreateSolver(Day16SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input-1.txt", "", Skip = "Unsolved yet")]
    [InlineData("example-input-2.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input-1.txt", "", Skip = "Unsolved yet")]
    [InlineData("example-input-2.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
