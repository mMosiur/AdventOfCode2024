using AdventOfCode.Year2024.Day15;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "15")]
public sealed class Day15Tests : BaseDayTests<Day15Solver, Day15SolverOptions>
{
    protected override string DayInputsDirectory => "Day15";

    protected override Day15Solver CreateSolver(Day15SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input-1.txt", "10092")]
    [InlineData("example-input-2.txt", "2028")]
    [InlineData("my-input.txt", "1429911")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input-1.txt", "9021")]
    [InlineData("my-input.txt", "1453087")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
