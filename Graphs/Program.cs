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

        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("A", "D");
        graph.AddEdge("B", "D");
        graph.AddEdge("C", "D");
        
        graph.BreadthFirstSearch("D");


        graph.PrintAdjacencyList();
        graph.PrintAdjacencyMatrix();
    }
}