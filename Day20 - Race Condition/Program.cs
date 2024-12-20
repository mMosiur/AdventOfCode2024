using System.Diagnostics;
using AdventOfCode.Common;
using AdventOfCode.Year2024.Day20;

try
{
    string? filepath = args.Length switch
    {
        0 => null,
        1 => args[0],
        3 => args[0],
        _ => throw new CommandLineException(
            $"Program was called with too many arguments. Proper usage: \"dotnet run [<input filepath>] [<part one min picoseconds saved> <part two min picoseconds saved>]\"."
        )
    };

    int? partOneMinPicosecondsSaved = null;
    int? partTwoMinPicosecondsSaved = null;
    if (args.Length == 3)
    {
        if (!int.TryParse(args[1], out int parsedPartOneMinPicosecondsSaved))
        {
            throw new CommandLineException("First Min picoseconds saved must be an integer.");
        }

        if (!int.TryParse(args[2], out int parsedPartTwoMinPicosecondsSaved))
        {
            throw new CommandLineException("Second Min picoseconds saved must be an integer.");
        }

        partOneMinPicosecondsSaved = parsedPartOneMinPicosecondsSaved;
        partTwoMinPicosecondsSaved = parsedPartTwoMinPicosecondsSaved;
    }

    Day20Solver solver = new(options =>
    {
        options.InputFilepath = filepath ?? options.InputFilepath;
        options.PartOneMinPicosecondsSaved = partOneMinPicosecondsSaved ?? options.PartOneMinPicosecondsSaved;
        options.PartTwoMinPicosecondsSaved = partTwoMinPicosecondsSaved ?? options.PartTwoMinPicosecondsSaved;
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
