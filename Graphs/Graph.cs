namespace Graphs;

public class Graph
{
    private readonly Dictionary<string, List<string>> _list = new();


    public bool AddVertex(string vertex)
    {
        if (_list.ContainsKey(vertex)) return false;
        _list.Add(vertex, []);

        return true;
    }

    public bool AddEdge(string vertex1, string vertex2)
    {
        if (vertex1 == vertex2) return false;

        if (!_list.ContainsKey(vertex1) || !_list.ContainsKey(vertex2))
            return false;

        if (!_list[vertex1].Contains(vertex2) && !_list[vertex2].Contains(vertex1))
        {
            _list[vertex1].Add(vertex2);
            _list[vertex2].Add(vertex1);
            return true;
        }

        return false;
    }

    public bool RemoveEdge(string vertex1, string vertex2)
    {
        if (!_list.ContainsKey(vertex1) || !_list.ContainsKey(vertex2))
            return false;

        if (_list[vertex1].Contains(vertex2) && _list[vertex2].Contains(vertex1))
        {
            _list[vertex1].Remove(vertex2);
            _list[vertex2].Remove(vertex1);
            return true;
        }

        return false;
    }

    public bool RemoveVertex(string vertex)
    {
        if (!_list.TryGetValue(vertex, out var adjacentVertices))
            return false;

        foreach (var otherVertex in adjacentVertices)
        {
            _list[otherVertex].Remove(vertex);
        }

        _list.Remove(vertex);

        return true;
    }

    public void BreadthFirstSearch(string startVertex)
    {
        if (!_list.ContainsKey(startVertex))
        {
            Console.WriteLine($"'{startVertex}' not found.");
            return;
        }

        var visited = new HashSet<string>();
        var queue = new Queue<string>();

        visited.Add(startVertex);
        queue.Enqueue(startVertex);

        Console.Write("BFS Search: ");

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.Write($"{current} ");

            foreach (var neighbor in _list[current])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        Console.WriteLine();
    }


    #region print

    public void PrintAdjacencyList()
    {
        foreach (var vertex in _list.OrderBy(v => v.Key))
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{vertex.Key} => [ ");
            Console.ResetColor();

            if (vertex.Value.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("∅");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(string.Join(", ", vertex.Value.OrderBy(v => v)));
            }

            Console.ResetColor();
            Console.WriteLine(" ]");
        }

        Console.WriteLine($"\nAll: {_list.Count}");
    }

    public void PrintAdjacencyMatrix()
    {
        var vertices = _list.Keys.OrderBy(v => v).ToList();
        int cellWidth = 3;


        Console.Write(new string(' ', cellWidth));
        foreach (var col in vertices)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{col.PadLeft(cellWidth)}");
        }

        Console.ResetColor();
        Console.WriteLine();
    
        foreach (var row in vertices)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{row.PadLeft(cellWidth)}");
            Console.ResetColor();

            foreach (var col in vertices)
            {
                var isConnected = _list[row].Contains(col);
                if (isConnected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("  ■");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("  ·");
                }

                Console.ResetColor();
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    #endregion
}