using AdventOfCode.Common;

namespace AdventOfCode.Year2024.Day03;

public sealed class Day03Solver : DaySolver<Day03SolverOptions>
{
	public override int Year => 2024;
	public override int Day => 3;
	public override string Title => "Mull It Over";

	public Day03Solver(Day03SolverOptions options) : base(options)
	{
	}

	public Day03Solver(Action<Day03SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure)) { }

	public Day03Solver() : this(new Day03SolverOptions()) { }

	public override string SolvePart1()
	{
		var diagnoser = new CorruptedMemoryDiagnoser();
		int result = diagnoser.RetrieveMulInstructions(Input).Select(i => i.Result).Sum();
		return result.ToString();
	}

	public override string SolvePart2()
	{
		return "UNSOLVED";
	}
}
