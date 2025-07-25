namespace Task4;

public class AdjList
{
    private Dictionary<string, List<string>> adjList;

    public AdjList()
    {
        adjList = new Dictionary<string, List<string>>();
    }

    public void AddEdge(string from, string to, bool isDirected = false)
    {
        if (!adjList.ContainsKey(from))
            adjList[from] = new List<string>();

        if (!adjList.ContainsKey(to))
            adjList[to] = new List<string>();

        adjList[from].Add(to);

        if (!isDirected)
        {
            adjList[to].Add(from);
        }
    }

    public void PrintGraph()
    {
        foreach (var pair in adjList)
        {
            Console.Write(pair.Key + " → ");
            foreach (var neighbor in pair.Value)
            {
                Console.Write(neighbor + " ");
            }
            Console.WriteLine();
        }
    }
}