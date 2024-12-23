namespace AdventOfCode.Year2024.Day23.Puzzle;

internal sealed class ConnectionAnalyzer(ConnectionMap connectionMap)
{
    private readonly ConnectionMap _connectionMap = connectionMap;

    public HashSet<ThreeComputerSet> FindInterconnectedTrios()
    {
        HashSet<ThreeComputerSet> computerTrios = [];
        foreach ((Computer firstComputer, var firstComputerConnections) in _connectionMap)
        {
            foreach (Computer secondComputer in firstComputerConnections)
            {
                var secondComputerConnections = _connectionMap[secondComputer];

                var computerSetEnumerable = firstComputerConnections.Intersect(secondComputerConnections)
                    .Select(thirdComputer => new ThreeComputerSet(firstComputer, secondComputer, thirdComputer));

                computerTrios.UnionWith(computerSetEnumerable);
            }
        }

        return computerTrios;
    }

    public ComputerClique ExpandTrioIntoClique(ThreeComputerSet trio)
    {
        var clique = new ComputerClique(trio);

        Queue<Computer> computersToProcess = new(trio);
        while (computersToProcess.TryDequeue(out Computer computer))
        {
            var computerConnections = _connectionMap[computer];
            foreach (var connectedComputer in computerConnections.Except(clique.Set))
            {
                var connectedComputerConnections = _connectionMap[connectedComputer];
                if (!clique.Set.IsSubsetOf(connectedComputerConnections)) continue;
                clique.Add(connectedComputer);
                computersToProcess.Enqueue(connectedComputer);
            }
        }

        return clique;
    }
}
