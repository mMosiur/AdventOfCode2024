using System.Diagnostics;
using AdventOfCode.Common;
using AdventOfCode.Year2024.Day14;

try
{
    string? filepath = args.Length switch
    {
        0 => null,
        1 => args[0],
        3 => args[0],
        _ => throw new CommandLineException(
            $"Program was called with too many arguments. Proper usage: \"dotnet run [<input filepath> | generate] [<bathroom width> <bathroom height>]\"."
        )
    };

    bool? generateImages = null;
    if ("generate".Equals(filepath, StringComparison.OrdinalIgnoreCase))
    {
        filepath = null;
        generateImages = true;
    }

    int? bathroomWidth;
    int? bathroomHeight;
    try
    {
        bathroomWidth = args.Length == 3 ? int.Parse(args[1]) : null;
        bathroomHeight = args.Length == 3 ? int.Parse(args[2]) : null;
        if (bathroomWidth.HasValue)
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(bathroomWidth.Value);
        if (bathroomHeight.HasValue)
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(bathroomHeight.Value);
    }
    catch (Exception e)
    {
        throw new CommandLineException(
            "Bathroom width and height (seconds and third arg) must be integers.", e
        );
    }

    Day14Solver solver = new(options =>
    {
        options.InputFilepath = filepath ?? options.InputFilepath;
        options.BathroomWidth = bathroomWidth ?? options.BathroomWidth;
        options.BathroomHeight = bathroomHeight ?? options.BathroomHeight;
        options.GenerateImages = generateImages ?? options.GenerateImages;
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
