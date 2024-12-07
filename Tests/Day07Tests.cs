using AdventOfCode.Year2024.Day07;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "07")]
[Trait("Day", "7")]
public sealed class Day07Tests : BaseDayTests<Day07Solver, Day07SolverOptions>
{
    protected override string DayInputsDirectory => "Day07";

    protected override Day07Solver CreateSolver(Day07SolverOptions options) => new(options);

    [Theory]
    [InlineData("example-input.txt", "3749")]
    [InlineData("my-input.txt", "1430271835320")]
    public void TestPart1(string inputFilename, string expectedResult)
        => BaseTestPart1(inputFilename, expectedResult);

    [Theory]
    [InlineData("example-input.txt", "11387")]
    [InlineData("my-input.txt", "456565678667482")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
