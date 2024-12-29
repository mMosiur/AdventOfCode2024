using System.Diagnostics;
using AdventOfCode.Common;
using AdventOfCode.Year2024.Day24;

try
{
    string? filepath = args.Length switch
    {
        0 => null,
        1 => args[0],
        2 => args[0],
        _ => throw new CommandLineException(
            $"Program was called with too many arguments. Proper usage: \"dotnet run [<input filepath>] [--dont-fix-adder]\"."
        )
    };

    bool? dontFixAdder = null;
    if (args.Length == 2)
    {
        if (args[1] == "--dont-fix-adder")
        {
            dontFixAdder = true;
        }
        else
        {
            throw new CommandLineException(
                $"Invalid argument \"{args[1]}\". Proper usage: \"dotnet run [<input filepath>] [--dont-fix-adder]\"."
            );
        }
    }

    Day24Solver solver = new(options =>
    {
        options.InputFilepath = filepath ?? options.InputFilepath;
        options.DontFixAdder = dontFixAdder ?? options.DontFixAdder;
    });

    Console.WriteLine($"--- Day {solver.Day}: {solver.Title} ---");

    Console.Write("Part one: ");
    string part1 = solver.SolvePart1();
    Console.WriteLine(part1);

    Console.Write("Part two: ");
    string part2 = solver.SolvePart2();
    Console.WriteLine(part2);
}
catch (AdventOfCodeException e)
{
    string errorPrefix = e switch
    {
        CommandLineException => "Command line error",
        InputException => "Input error",
        DaySolverException => "Day solver error",
        _ => throw new UnreachableException($"Unknown exception type \"{e.GetType()}\".")
    };

    Console.ForegroundColor = ConsoleColor.Red;
    Console.Error.WriteLine($"{errorPrefix}: {e.Message}");
    Console.ResetColor();
    Environment.Exit(1);
}
