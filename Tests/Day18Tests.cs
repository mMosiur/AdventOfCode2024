using AdventOfCode.Year2024.Day18;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "18")]
public sealed class Day18Tests : BaseDayTests<Day18Solver, Day18SolverOptions>
{
    protected override string DayInputsDirectory => "Day18";

    protected override Day18Solver CreateSolver(Day18SolverOptions options) => new(options);

    private static readonly Day18SolverOptions ExampleOptions = new()
    {
        MemorySpaceHeight = 7,
        MemorySpaceWidth = 7,
        PartOneFallingByteCount = 12,
    };

    public static TheoryData<string, string, Day18SolverOptions?> TestPart1Data { get; } = new()
    {
        { "example-input.txt", "22", ExampleOptions },
        { "my-input.txt", "294", null }
    };

    [Theory]
    [MemberData(nameof(TestPart1Data))]
    public void TestPart1(string inputFilename, string expectedResult, Day18SolverOptions? customOptions)
        => BaseTestPart1(inputFilename, expectedResult, customOptions);

    public static TheoryData<string, string, Day18SolverOptions?> TestPart2Data { get; } = new()
    {
        { "example-input.txt", "6,1", ExampleOptions },
        { "my-input.txt", "31,22", null }
    };

    [Theory]
    [MemberData(nameof(TestPart2Data))]
    public void TestPart2(string inputFilename, string expectedResult, Day18SolverOptions? customOptions)
        => BaseTestPart2(inputFilename, expectedResult, customOptions);
}
