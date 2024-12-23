﻿namespace AdventOfCode.Year2024.Day23.Puzzle;

internal sealed class ConnectionAnalyzer(ConnectionMap connectionMap)
{
    private readonly ConnectionMap _connectionMap = connectionMap;

    public HashSet<ThreeComputerSet> FindInterconnectedTrios()
    {
        HashSet<ThreeComputerSet> computerTrios = [];
        foreach ((Computer firstComputer, var firstComputerConnections) in _connectionMap.Map)
        {
            foreach (Computer secondComputer in firstComputerConnections)
            {
                var secondComputerConnections = _connectionMap.Map[secondComputer];

                var computerSetEnumerable = firstComputerConnections.Intersect(secondComputerConnections)
                    .Select(thirdComputer => new ThreeComputerSet(firstComputer, secondComputer, thirdComputer));

                computerTrios.UnionWith(computerSetEnumerable);
            }
        }

        return computerTrios;
    }
}