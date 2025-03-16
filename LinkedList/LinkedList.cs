namespace DataStructuresAlgorithms;

public class LinkedList
{
    private Node? _head;
    private Node? _tail;
    private int _length;

    public LinkedList(int value)
    {
        Node newNode = new Node(value);
        _head = newNode;
        _tail = newNode;
        _length = 1;
    }

    public void Append(int value)
    {
        Node newNode = new Node(value);
        if (_length == 0)
        {
            _head = newNode;
        }
        else
        {
            _tail!.Next = newNode;
        }

        _tail = newNode;
        _length++;
    }

    public void Prepend(int value)
    {
        Node newNode = new Node(value);
        if (_length == 0)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode!.Next = _head;
            _head = newNode;
        }

        _length++;
    }

    public Node? RemoveFirst()
    {
        if (_length == 0) return null;

        Node temp = _head!;
        _head = _head!.Next;
        temp.Next = null;

        _length--;

        if (_length == 0) _tail = null;

        return temp;
    }

    public Node? RemoveLast()
    {
        if (_length == 0) return null;

        Node temp = _head!;
        Node previous = _head!;

        while (temp.Next != null)
        {
            previous = temp;
            temp = temp.Next;
        }

        _tail = previous;
        _tail.Next = null;
        _length--;

        if (_length == 0)
        {
            _head = null;
            _tail = null;
        }

        return temp;
    }

    public Node? Get(int index)
    {
        if (index < 0 || index >= _length) return null;

        Node temp = _head!;

        for (var i = 0; i < index; i++)
            if (temp.Next != null)
                temp = temp.Next;

        return temp;
    }

    public void PrintList()
    {
        Node temp = _head;
        while (temp != null)
        {
            Console.WriteLine(temp.Value);
            temp = temp.Next;
        }
    }

    public void GetHead()
    {
        Console.WriteLine("Head: " + _head.Value);
    }

    public void GetTail()
    {
        Console.WriteLine("Tail: " + _tail.Value);
    }

    public void GetLength()
    {
        Console.WriteLine("Length: " + _length);
    }

    public void PrintVisual()
    {
        if (_head == null)
        {
            Console.WriteLine("Empty list");
            return;
        }

        Node temp = _head;
        Console.WriteLine("\nLinked List Visualization:");

        temp = _head;
        while (temp != null)
        {
            Console.Write("+-----+");
            if (temp.Next != null)
                Console.Write("    ");
            temp = temp.Next;
        }

        Console.WriteLine();

        temp = _head;
        while (temp != null)
        {
            Console.Write("|  " + temp.Value.ToString().PadRight(2) + " |");
            if (temp.Next != null)
                Console.Write(" -> ");
            temp = temp.Next;
        }

        Console.WriteLine();

        temp = _head;
        while (temp != null)
        {
            Console.Write("+-----+");
            if (temp.Next != null)
                Console.Write("    ");
            temp = temp.Next;
        }

        Console.WriteLine();

        Console.WriteLine();
    }
}