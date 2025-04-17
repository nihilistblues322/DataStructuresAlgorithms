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

    public void PrintVisual()
    {
        if (_top == null)
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        Console.WriteLine("\nStack Visualization:");
        Console.WriteLine("-------------------");

        Node current = _top;
        int position = _height;

        while (current != null)
        {
            Console.WriteLine($"| {current.Value.ToString(),3} |");
            Console.WriteLine("+-----+");
            current = current.Next;
            position--;
        }

        Console.WriteLine("  TOP");
        Console.WriteLine($"Stack height: {_height}\n");
    }
}