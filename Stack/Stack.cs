namespace Stack;

public class Stack
{
    private Node _top;
    private int _height;

    public Stack(int value)
    {
        Node newNode = new Node(value);
        _top = newNode;
        _height = 1;
    }

    public void Push(int value)
    {
        Node newNode = new Node(value);

        if (_height == 0)
        {
            _top = newNode;
        }
        else
        {
            newNode.Next = _top;
            _top = newNode;
        }

        _height++;
    }

    public Node? Pop()
    {
        if (_height == 0) return null;

        Node temp = _top;
        _top = _top.Next!;
        temp.Next = null;

        _height--;
        
        return temp;
    }

    public void PrintVisual()
    {
        if (_top == null)
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        Console.WriteLine("\nStack Visualization (TOP to BOTTOM):");
        Console.WriteLine("-------------------");
        Console.WriteLine("  TOP");

        Node current = _top;
        int position = _height;

        while (current != null)
        {
            Console.WriteLine("+-----+");
            Console.WriteLine($"| {current.Value.ToString(),3} |");
            current = current.Next;
            position--;
        }

        Console.WriteLine("+-----+");
        Console.WriteLine("  BOTTOM");
        Console.WriteLine($"\nStack height: {_height}\n");
    }
}