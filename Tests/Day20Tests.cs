using AdventOfCode.Year2024.Day20;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "20")]
public sealed class Day20Tests : BaseDayTests<Day20Solver, Day20SolverOptions>
{
    protected override string DayInputsDirectory => "Day20";

    protected override Day20Solver CreateSolver(Day20SolverOptions options) => new(options);

    private static readonly Day20SolverOptions ExampleOptions = new()
    {
        MinPicosecondsSaved = 10,
    };

    public static TheoryData<string, string, Day20SolverOptions?> TestPart1Data { get; } = new()
    {
        { "example-input.txt", "10", ExampleOptions },
        { "my-input.txt", "1393", null }
    };

    [Theory]
    [MemberData(nameof(TestPart1Data))]
    public void TestPart1(string inputFilename, string expectedResult, Day20SolverOptions? customOptions)
        => BaseTestPart1(inputFilename, expectedResult, customOptions);

    [Theory]
    [InlineData("example-input.txt", "", Skip = "Unsolved yet")]
    [InlineData("my-input.txt", "", Skip = "Unsolved yet")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
