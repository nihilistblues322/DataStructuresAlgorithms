namespace Graphs;

class Program
{
    static void Main(string[] args)
    {
        var graph = new Graph();

        graph.AddVertex("A");
        graph.AddVertex("B");
        graph.AddVertex("C");
        graph.AddVertex("D");
        graph.AddVertex("E");


        graph.PrintGraphWithConnections();
    }
}