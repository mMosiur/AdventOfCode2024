using AdventOfCode.Year2024.Day17;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "17")]
public sealed class Day17Tests : BaseDayTests<Day17Solver, Day17SolverOptions>
{
    protected override string DayInputsDirectory => "Day17";

    protected override Day17Solver CreateSolver(Day17SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input-1.txt", "4,6,3,5,6,3,5,2,1,0")]
    [InlineData("my-input.txt", "7,6,1,5,3,1,4,2,6")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input-2.txt", "117440")]
    [InlineData("my-input.txt", "164541017976509")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
