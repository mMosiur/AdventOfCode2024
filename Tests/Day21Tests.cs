using AdventOfCode.Year2024.Day21;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "21")]
public sealed class Day21Tests : BaseDayTests<Day21Solver, Day21SolverOptions>
{
    protected override string DayInputsDirectory => "Day21";

    protected override Day21Solver CreateSolver(Day21SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "126384")]
    [InlineData("my-input.txt", "138764")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
