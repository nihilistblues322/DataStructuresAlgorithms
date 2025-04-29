namespace Graphs;

public class Graph
{
    private readonly Dictionary<string, List<string>> _adjacencyList = new Dictionary<string, List<string>>();

    public bool AddVertex(string vertex)
    {
        if (_adjacencyList.ContainsKey(vertex)) return false;
        _adjacencyList.Add(vertex, new List<string>());

        return true;
    }

    #region print
    public void PrintGraphWithConnections()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n╔════════════════════════════╗");
        Console.WriteLine("║     GRAPH CONNECTIONS     ║");
        Console.WriteLine("╚════════════════════════════╝");
        Console.ResetColor();

        foreach (var vertex in _adjacencyList)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  {vertex.Key}");
            Console.ResetColor();

            if (vertex.Value.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                foreach (var connection in vertex.Value)
                {
                    Console.WriteLine($"    │\n    ├──● {connection}");
                }

                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("    │\n    └── (no connections)");
                Console.ResetColor();
            }

            // ReSharper disable once UsageOfDefaultStructEquality
            if (!vertex.Equals(_adjacencyList.Last()))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("    │");
                Console.ResetColor();
            }
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n┌────────────────────────────┐");
        Console.WriteLine($"│ Vertices: {_adjacencyList.Count,-15} │");
        Console.WriteLine($"│ Edges: {_adjacencyList.Sum(v => v.Value.Count),-17} │");
        Console.WriteLine("└────────────────────────────┘");
        Console.ResetColor();
    }

    #endregion
}