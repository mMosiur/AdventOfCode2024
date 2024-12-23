using AdventOfCode.Year2024.Day22;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "22")]
public sealed class Day22Tests : BaseDayTests<Day22Solver, Day22SolverOptions>
{
    protected override string DayInputsDirectory => "Day22";

    protected override Day22Solver CreateSolver(Day22SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input-1.txt", "37327623")]
    [InlineData("my-input.txt", "14392541715")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input-2.txt", "23")]
    [InlineData("my-input.txt", "1628")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
