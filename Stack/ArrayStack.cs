namespace Stack;

public class ArrayStack
{
    private int[] _items;
    private int _top;
    private int _capacity;

    public ArrayStack(int capacity = 10)
    {
        _capacity = capacity;
        _items = new int[capacity];
        _top = -1;
    }

    public void Push(int value)
    {
        if (_top == _capacity - 1)
        {
            _capacity *= 2;
            Array.Resize(ref _items, _capacity);
        }

        _top++;
        _items[_top] = value;
    }

    public int? Pop()
    {
        if (IsEmpty())
            return null;

        int value = _items[_top];
        _top--;

        return value;
    }

    public bool IsEmpty()
    {
        return _top == -1;
    }

    public int Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty");

        return _items[_top];
    }

    public void PrintVisual()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        Console.WriteLine("\nStack Visualization (TOP to BOTTOM):");
        Console.WriteLine("-------------------");
        Console.WriteLine("  TOP");

        for (int i = _top; i >= 0; i--)
        {
            Console.WriteLine("+-----+");
            Console.WriteLine($"| {_items[i],3} |");
        }

        Console.WriteLine("+-----+");
        Console.WriteLine("  BOTTOM");
        Console.WriteLine($"\nStack size: {_top + 1}\n");
        Console.WriteLine($"Current capacity: {_capacity}\n");
    }
}