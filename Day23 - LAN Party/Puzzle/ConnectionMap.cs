using System.Collections;

namespace AdventOfCode.Year2024.Day23.Puzzle;

internal sealed class ConnectionMap : IEnumerable<KeyValuePair<Computer, HashSet<Computer>>>
{
    private readonly Dictionary<Computer, HashSet<Computer>> _map;

    private ConnectionMap(Dictionary<Computer, HashSet<Computer>> map)
    {
        _map = map;
    }

    public HashSet<Computer> this[Computer key] => _map[key];

    public IEnumerator<KeyValuePair<Computer, HashSet<Computer>>> GetEnumerator() => _map.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public static ConnectionMap Create(IReadOnlyList<ComputerConnection> connections)
    {
        var map = new Dictionary<Computer, HashSet<Computer>>();
        foreach (var connection in connections)
        {
            if (!map.TryGetValue(connection.Computer1, out var computer1Connections))
            {
                computer1Connections = new(1);
                map[connection.Computer1] = computer1Connections;
            }

            computer1Connections.Add(connection.Computer2);

            if (!map.TryGetValue(connection.Computer2, out var computer2Connections))
            {
                computer2Connections = new(1);
                map[connection.Computer2] = computer2Connections;
            }

            computer2Connections.Add(connection.Computer1);
        }

        return new(map);
    }
}
