using AdventOfCode.Common.Geometry;

namespace AdventOfCode.Year2024.Day08.Puzzle;

internal static class InputReader
{
    public static AntennaMap Read(IEnumerable<string> inputLines)
    {
        var dictionary = new Dictionary<Antenna, List<GridPoint>>();
        var inputArray = inputLines.ToArray();
        var bounds = new Rectangle<int>(0, inputArray.Length - 1, 0, inputArray[0].Length - 1);
        for (int row = 0; row < inputArray.Length; row++)
        {
            var line = inputArray[row];
            for (int col = 0; col < line.Length; col++)
            {
                if (line[col] == '.') continue;

                var antenna = new Antenna(line[col]);

                if (!dictionary.TryGetValue(antenna, out var points))
                {
                    points = new(1);
                    dictionary[antenna] = points;
                }

                points.Add(new(row, col));
            }
        }

        return new(bounds, dictionary);
    }
}
