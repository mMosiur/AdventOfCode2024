using AdventOfCode.Year2024.Day24;

namespace AdventOfCode.Year2024.Tests;

[Trait("Year", "2024")]
[Trait("Day", "24")]
public sealed class Day24Tests : BaseDayTests<Day24Solver, Day24SolverOptions>
{
    protected override string DayInputsDirectory => "Day24";

    protected override Day24Solver CreateSolver(Day24SolverOptions options) => new(options);

    private static readonly Day24SolverOptions ExampleOptions = new()
    {
        DontFixAdder = true,
    };

    public static TheoryData<string, string, Day24SolverOptions?> TestPart1Data { get; } = new()
    {
        { "example-input-1.txt", "4", ExampleOptions },
        { "example-input-2.txt", "2024", ExampleOptions },
        { "my-input.txt", "60614602965288", null }
    };

    [Theory]
    [MemberData(nameof(TestPart1Data))]
    public void TestPart1(string inputFilename, string expectedResult, Day24SolverOptions? customOptions = null)
        => BaseTestPart1(inputFilename, expectedResult, customOptions);

    [Theory]
    [InlineData("my-input.txt", "cgr,hpc,hwk,qmd,tnt,z06,z31,z37")]
    public void TestPart2(string inputFilename, string expectedResult)
        => BaseTestPart2(inputFilename, expectedResult);
}
