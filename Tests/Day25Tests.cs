using AdventOfCode.Year2024.Day25;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "25")]
public sealed class Day25Tests : BaseDayTests<Day25Solver, Day25SolverOptions>
{
    protected override string DayInputsDirectory => "Day25";

    protected override Day25Solver CreateSolver(Day25SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "3")]
    [InlineData("my-input.txt", "2691")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    // No tests for part two,
    // Merry Christmas!
}
