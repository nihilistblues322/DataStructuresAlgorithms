using System.Text;

namespace Queue;

public class Queue
{
    private Node? _first;
    private Node? _last;
    private int _length;

    public Queue(int value)
    {
        Node newNode = new Node(value);

        _first = newNode;
        _last = newNode;

        _length = 1;
    }

    public void Enqueue(int value)
    {
        Node newNode = new Node(value);

        if (_length == 0)
        {
            _first = newNode;
            _last = newNode;
        }
        else
        {
            _last.Next = newNode;
            _last = newNode;
        }

        _length++;
    }

    public Node? Dequeue()
    {
        if (_length == 0 || _first == null)
        {
            return null;
        }

        Node temp = _first;

        if (_length == 1)
        {
            _first = null;
            _last = null;
        }
        else
        {
            _first = _first.Next;
            temp.Next = null;
        }

        _length--;

        return temp;
    }

    public void PrintVisual()
    {
        Console.WriteLine("\n--- Queue Visualization ---");
        if (_length == 0)
        {
            Console.WriteLine("Queue is empty.");
            Console.WriteLine($"Length: {_length}");
            Console.WriteLine("-------------------------\n");
            return;
        }

        StringBuilder sb = new StringBuilder();
        Node current = _first;

        sb.Append("FIRST -> ");

        while (current != null)
        {
            sb.Append($"[ {current.Value} ]");
            if (current.Next != null)
            {
                sb.Append(" -> ");
            }

            current = current.Next!;
        }

        sb.Append(" <- LAST");

        Console.WriteLine(sb.ToString());
        Console.WriteLine($"Length: {_length}");
        Console.WriteLine("-------------------------\n");
    }
}