using AdventOfCode.Year2024.Day13;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "13")]
public sealed class Day13Tests : BaseDayTests<Day13Solver, Day13SolverOptions>
{
    protected override string DayInputsDirectory => "Day13";

    protected override Day13Solver CreateSolver(Day13SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "480")]
    [InlineData("my-input.txt", "31065")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("my-input.txt", "93866170395343")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
