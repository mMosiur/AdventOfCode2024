using AdventOfCode.Year2024.Day05;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "05")]
[Trait("Day", "5")]
public sealed class Day05Tests : BaseDayTests<Day05Solver, Day05SolverOptions>
{
    protected override string DayInputsDirectory => "Day05";

    protected override Day05Solver CreateSolver(Day05SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "143")]
    [InlineData("my-input.txt", "4872")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "123")]
    [InlineData("my-input.txt", "5564")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
