using AdventOfCode.Common;
using AdventOfCode.Year2024.Day09.Puzzle;

namespace AdventOfCode.Year2024.Day09;

public sealed class Day09Solver : DaySolver<Day09SolverOptions>
{
    public override int Year => 2024;
    public override int Day => 9;
    public override string Title => "Disk Fragmenter";

    private readonly DiskMap _diskMap;

    public Day09Solver(Day09SolverOptions options) : base(options)
    {
        _diskMap = InputReader.ReadDiskMap(Input);
    }

    public Day09Solver(Action<Day09SolverOptions> configure) : this(DaySolverOptions.FromConfigureAction(configure))
    {
    }

    public Day09Solver() : this(new Day09SolverOptions())
    {
    }

    public override string SolvePart1()
    {
        var disk = Disk.CreateFromDiskMap(_diskMap);
        disk.CompressBlockWise();
        long checksum = disk.CalculateChecksum();
        return checksum.ToString();
    }

    public override string SolvePart2()
    {
        var disk = Disk.CreateFromDiskMap(_diskMap);
        disk.CompressFileWise();
        long checksum = disk.CalculateChecksum();
        return checksum.ToString();
    }
}
