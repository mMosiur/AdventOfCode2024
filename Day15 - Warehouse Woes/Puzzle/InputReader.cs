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

    public static char[,] WidenInputWarehouse(char[,] inputWarehouseChars)
    {
        int newHeight = inputWarehouseChars.GetLength(0);
        int newWidth = inputWarehouseChars.GetLength(1) * 2;
        char[,] widenedWarehouseChars = new char[newHeight, newWidth];

        for (int row = 0; row < inputWarehouseChars.GetLength(0); row++)
        {
            for (int col = 0; col < inputWarehouseChars.GetLength(1); col++)
            {
                int newCol = col * 2;
                char c = inputWarehouseChars[row, col];
                (widenedWarehouseChars[row, newCol], widenedWarehouseChars[row, newCol + 1]) = c switch
                {
                    '#' => ('#', '#'),
                    'O' => ('[', ']'),
                    '.' => ('.', '.'),
                    '@' => ('@', '.'),
                    _ => throw new InvalidOperationException($"Unknown map character '{c}'")
                };
            }
        }

        return widenedWarehouseChars;
    }
}
