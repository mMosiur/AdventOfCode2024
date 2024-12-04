using AdventOfCode.Year2024.Day04;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "04")]
[Trait("Day", "4")]
public sealed class Day04Tests : BaseDayTests<Day04Solver, Day04SolverOptions>
{
    protected override string DayInputsDirectory => "Day04";

    protected override Day04Solver CreateSolver(Day04SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "18")]
    [InlineData("my-input.txt", "2496")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "9")]
    [InlineData("my-input.txt", "1967")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
