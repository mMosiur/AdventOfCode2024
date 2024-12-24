using AdventOfCode.Year2024.Day24;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "24")]
public sealed class Day24Tests : BaseDayTests<Day24Solver, Day24SolverOptions>
{
    protected override string DayInputsDirectory => "Day24";

    protected override Day24Solver CreateSolver(Day24SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input-1.txt", "4")]
    [InlineData("example-input-2.txt", "2024")]
    [InlineData("my-input.txt", "60614602965288")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input-1.txt", "", Skip = "Unsolved yet")]
    [InlineData("example-input-2.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
