using AdventOfCode.Common.EnumeratorExtensions;

namespace AdventOfCode.Year2024.Day15.Puzzle;

internal static class InputReader
{
    public static (char[,] WarehouseCharMap, MoveDirection[] RobotMovementList) Read(string input)
    {
        var it = input.AsSpan().EnumerateLines();
        it.EnsureMoveToNextNonEmptyLine(skipCurrent: false);
        List<string> mapLines = [];
        while (!it.Current.IsWhiteSpace())
        {
            mapLines.Add(it.Current.ToString());
            it.EnsureMoveNext();
        }

        char[,] warehouseCharMap = new char[mapLines.Count, mapLines[0].Length];
        for (int row = 0; row < mapLines.Count; row++)
        {
            for (int col = 0; col < mapLines[row].Length; col++)
            {
                warehouseCharMap[row, col] = mapLines[row][col];
            }
        }

        it.EnsureMoveNext();
        List<MoveDirection> robotMovementList = [];
        while (!it.Current.IsWhiteSpace())
        {
            foreach (char c in it.Current)
            {
                robotMovementList.Add(MoveDirections.Parse(c));
            }

            if (!it.MoveNext()) break;
        }

        return (warehouseCharMap, robotMovementList.ToArray());
    }
}
