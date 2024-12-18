using AdventOfCode.Year2024.Day18;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "18")]
public sealed class Day18Tests : BaseDayTests<Day18Solver, Day18SolverOptions>
{
    protected override string DayInputsDirectory => "Day18";

    protected override Day18Solver CreateSolver(Day18SolverOptions options) => new(options);

    public static TheoryData<string, string, Day18SolverOptions?> TestPart1Data { get; } = new()
    {
        {
            "example-input.txt", "22",
            new Day18SolverOptions
            {
                MemorySpaceHeight = 7,
                MemorySpaceWidth = 7,
                PartOneFallingByteCount = 12,
            }
        },
        {
            "my-input.txt", "294",
            null
        }
    };

    [Theory]
    [MemberData(nameof(TestPart1Data))]
    public void TestPart1(string inputFilename, string expectedResult, Day18SolverOptions? customOptions)
        => BaseTestPart1(inputFilename, expectedResult, customOptions);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
