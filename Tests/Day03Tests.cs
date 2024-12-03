using AdventOfCode.Year2024.Day03;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "03")]
[Trait("Day", "3")]
public sealed class Day03Tests : BaseDayTests<Day03Solver, Day03SolverOptions>
{
    protected override string DayInputsDirectory => "Day03";

    protected override Day03Solver CreateSolver(Day03SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input-1.txt", "161")]
    [InlineData("my-input.txt", "179834255")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input-2.txt", "48")]
    [InlineData("my-input.txt", "80570939")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
