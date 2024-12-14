using AdventOfCode.Year2024.Day14;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "14")]
public sealed class Day14Tests : BaseDayTests<Day14Solver, Day14SolverOptions>
{
    protected override string DayInputsDirectory => "Day14";

    protected override Day14Solver CreateSolver(Day14SolverOptions options) => new(options);

    public static TheoryData<string, string, Day14SolverOptions?> TestPart1Data { get; }
        = new()
        {
            {
                "example-input.txt", "12", new()
                {
                    BathroomWidth = 11,
                    BathroomHeight = 7,
                }
            },
            { "my-input.txt", "216027840", null }
        };

    [Theory]
    [MemberData(nameof(TestPart1Data))]
    public void TestPart1(string inputFilename, string expectedResult, Day14SolverOptions? customOptions)
        => BaseTestPart1(inputFilename, expectedResult, customOptions);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
