using AdventOfCode.Year2024.Day08;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "08")]
[Trait("Day", "8")]
public sealed class Day08Tests : BaseDayTests<Day08Solver, Day08SolverOptions>
{
    protected override string DayInputsDirectory => "Day08";

    protected override Day08Solver CreateSolver(Day08SolverOptions options) => new(options);

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
