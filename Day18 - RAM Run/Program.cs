using System.Diagnostics;
using AdventOfCode.Common;
using AdventOfCode.Year2024.Day18;

try
{
    string? filepath = args.Length switch
    {
        0 => null,
        1 => args[0],
        4 => args[0],
        _ => throw new CommandLineException(
            $"Program was called with too many arguments. Proper usage: \"dotnet run [<input filepath>] [<memory space height> <memory space width> <byte fall count>]\"."
        )
    };

    int? memorySpaceHeight = null;
    int? memorySpaceWidth = null;
    int? byteFallCount = null;
    if (args.Length == 4)
    {
        if (!int.TryParse(args[1], out int height) || height < 1)
        {
            throw new CommandLineException("Memory space height must be a positive integer.");
        }

        memorySpaceHeight = height;

        if (!int.TryParse(args[2], out int width) || width < 1)
        {
            throw new CommandLineException("Memory space width must be a positive integer.");
        }

        memorySpaceWidth = width;

        if (!int.TryParse(args[3], out int count) || count < 1)
        {
            throw new CommandLineException("Byte fall count must be a positive integer.");
        }

        byteFallCount = count;
    }


    Day18Solver solver = new(options =>
    {
        options.InputFilepath = filepath ?? options.InputFilepath;
        options.MemorySpaceHeight = memorySpaceHeight ?? options.MemorySpaceHeight;
        options.MemorySpaceWidth = memorySpaceWidth ?? options.MemorySpaceWidth;
        options.PartOneFallingByteCount = byteFallCount ?? options.PartOneFallingByteCount;
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
