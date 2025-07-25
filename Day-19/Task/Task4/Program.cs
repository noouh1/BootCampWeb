namespace Task4;

public class Program
{
    public static void Main(string[] args)
    {
        var graph = new AdjList();

        graph.AddEdge("A", "B");
        graph.AddEdge("A", "C");
        graph.AddEdge("B", "D");
        graph.AddEdge("D", "E");

        graph.PrintGraph();
    }
}