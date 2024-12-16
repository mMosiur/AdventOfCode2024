using AdventOfCode.Year2024.Day16;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "16")]
public sealed class Day16Tests : BaseDayTests<Day16Solver, Day16SolverOptions>
{
    protected override string DayInputsDirectory => "Day16";

    protected override Day16Solver CreateSolver(Day16SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input-1.txt", "7036")]
    [InlineData("example-input-2.txt", "11048")]
    [InlineData("my-input.txt", "66404")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input-1.txt", "45")]
    [InlineData("example-input-2.txt", "64")]
    [InlineData("my-input.txt", "433")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
