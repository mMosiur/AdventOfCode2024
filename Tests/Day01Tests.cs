using AdventOfCode.Year2024.Day01;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "01")]
[Trait("Day", "1")]
public sealed class Day01Tests : BaseDayTests<Day01Solver, Day01SolverOptions>
{
    protected override string DayInputsDirectory => "Day01";

    protected override Day01Solver CreateSolver(Day01SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "11")]
    [InlineData("my-input.txt", "1258579")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "31")]
    [InlineData("my-input.txt", "23981443")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
