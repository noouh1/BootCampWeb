public class MyQueue<T>
{
    private Stack<int> input;
    private Stack<int> output;
    public MyQueue()
    {
        input = new Stack<int>();
        output = new Stack<int>();
        count = 0;
    }
    public void Enqueue(int x)
    {
        input.Push(x);
        count++;
    }
    public int Dequeue()
    {
        if (output.Count == 0)
        {
            while (input.Count > 0)
            {
                output.Push(input.Pop());
            }
        }

        count--;
        return output.Pop();
    }

    public int Peek()
    {
        if (output.Count == 0)
        {
            while (input.Count > 0)
            {
                output.Push(input.Pop());
            }
        }

        return output.Peek();
    }

    public bool Empty()
    {
        return count == 0;
    }
    public int Count() {
        return count;
    }
}