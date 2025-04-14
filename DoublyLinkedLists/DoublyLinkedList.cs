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
        else if (_tail != null) // Проверка на null перед использованием
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }

        _length++;
    }

    public Node? RemoveLast()
    {
        if (_length == 0 || _tail == null) return null;

        Node temp = _tail;

        if (_length == 1)
        {
            _head = null;
            _tail = null;
        }
        else if (_tail.Prev != null) // Проверка на null перед использованием
        {
            _tail = _tail.Prev;
            _tail.Next = null;
            temp.Prev = null;
        }

        _length--;

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

        Node? temp = _head;
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