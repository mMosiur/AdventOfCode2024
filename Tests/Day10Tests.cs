using AdventOfCode.Year2024.Day10;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "10")]
public sealed class Day10Tests : BaseDayTests<Day10Solver, Day10SolverOptions>
{
    protected override string DayInputsDirectory => "Day10";

    protected override Day10Solver CreateSolver(Day10SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input-1.txt", "1")]
    [InlineData("example-input-2.txt", "36")]
    [InlineData("my-input.txt", "629")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input-2.txt", "81")]
    [InlineData("my-input.txt", "1242")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
