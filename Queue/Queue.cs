namespace Queue;

public class Queue
{
    private Node _first;
    private Node _last;
    private int _length;

    public Queue(int value)
    {
        Node newNode = new Node(value);
        _first = newNode;
        _last = newNode;
        _length = 1;
    }

    public void PrintVisual()
    {
        if (_first == null)
        {
            Console.WriteLine("Queue is empty");
            return;
        }

        Console.WriteLine("\nQueue Visualization (FIRST to LAST):");
        Console.WriteLine("-------------------");
        Console.WriteLine("  FIRST");

        Node current = _first;
        int position = 1;

        while (current != null)
        {
            Console.WriteLine("+-----+");
            Console.WriteLine($"| {current.Value.ToString(),3} |");

            if (current.Next == null)
            {
                Console.WriteLine("+-----+");
                Console.WriteLine("  LAST");
            }
            else
            {
                Console.WriteLine("+-----+");
                Console.WriteLine("    ↓");
            }

            current = current.Next;
            position++;
        }

        Console.WriteLine($"\nQueue length: {_length}\n");
    }
}