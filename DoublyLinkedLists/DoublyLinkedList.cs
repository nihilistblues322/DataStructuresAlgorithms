namespace DoublyLinkedList;

public class DoublyLinkedList
{
    private Node? _head;
    private Node? _tail;
    private int _length;

    public DoublyLinkedList(int value)
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
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }

        _length++;
    }

    public Node? RemoveLast()
    {
        if (_length == 0) return null;

        Node temp = _tail;

        if (_length == 1)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            _tail.Next = null;
            temp.Prev = null;
        }

        _length--;

        return temp;
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
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }

        _length++;
    }

    public Node? RemoveFirst()
    {
        if (_length == 0) return null;

        Node temp = _head;
        if (_length == 1)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head.Prev = null;
            temp.Next = null;
        }

        _length--;

        return temp;
    }

    public Node? Get(int index)
    {
        if (index < 0 || index >= _length) return null;

        Node temp = _head;
        if (index < _length / 2)
        {
            for (var i = 0; i < index; i++)
            {
                temp = temp.Next;
            }
        }
        else
        {
            temp = _tail;
            for (var i = _length - 1; i > index; i--)
            {
                temp = temp.Prev;
            }
        }

        return temp;
    }

    public void PrintVisual()
    {
        if (_head == null)
        {
            Console.WriteLine("Empty list");
            return;
        }

        Console.WriteLine("\nDoubly Linked List Visualization (forward):");

        Node temp = _head;
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
                Console.Write(" <-> ");
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

        Console.WriteLine("\n");

        Console.WriteLine("Doubly Linked List Visualization (backward):");

        temp = _tail;
        while (temp != null)
        {
            Console.Write("+-----+");
            if (temp.Prev != null)
                Console.Write("    ");
            temp = temp.Prev;
        }

        Console.WriteLine();

        temp = _tail;
        while (temp != null)
        {
            Console.Write("|  " + temp.Value.ToString().PadRight(2) + " |");
            if (temp.Prev != null)
                Console.Write(" <-> ");
            temp = temp.Prev;
        }

        Console.WriteLine();

        temp = _tail;
        while (temp != null)
        {
            Console.Write("+-----+");
            if (temp.Prev != null)
                Console.Write("    ");
            temp = temp.Prev;
        }

        Console.WriteLine();
    }
}