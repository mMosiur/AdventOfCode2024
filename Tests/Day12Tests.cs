using AdventOfCode.Year2024.Day12;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "12")]
public sealed class Day12Tests : BaseDayTests<Day12Solver, Day12SolverOptions>
{
    protected override string DayInputsDirectory => "Day12";

    protected override Day12Solver CreateSolver(Day12SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input-1.txt", "140")]
    [InlineData("example-input-2.txt", "772")]
    [InlineData("example-input-3.txt", "1930")]
    [InlineData("my-input.txt", "1465112")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input-1.txt", "80")]
    [InlineData("example-input-2.txt", "436")]
    [InlineData("example-input-3.txt", "1206")]
    [InlineData("example-input-4.txt", "236")]
    [InlineData("example-input-5.txt", "368")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
