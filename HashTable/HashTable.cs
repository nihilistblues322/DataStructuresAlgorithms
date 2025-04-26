namespace HashTable;

public class HashTable
{
    private int _size = 7;
    private Node?[] _dataMap;

    private const int PrimeMultiplier = 23;
    private static int _count = 0;

    public HashTable()
    {
        _dataMap = new Node[_size];
    }

    private int Hash(string key)
    {
        unchecked
        {
            return key
                .Aggregate(0,
                    (currentHash, character) => (currentHash + character * PrimeMultiplier) % _dataMap.Length);
        }
    }

    private int OldHash(string key)
    {
        int hash = 0;

        char[] keyChars = key.ToCharArray();

        for (int i = 0; i < keyChars.Length; i++)
        {
            int asciiValue = keyChars[i];
            hash = (hash + asciiValue * 23) % _dataMap.Length;
        }

        return hash;
    }

    public void Set(string key, int value)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Key cannot be null, empty, or whitespace.", nameof(key));

        int index = Hash(key);

        Node newNode = new Node(key, value);

        if (_dataMap[index] == null)
        {
            _dataMap[index] = newNode;
            _count++;
        }
        else
        {
            Node current = _dataMap[index]!;

            while (true)
            {
                if (string.Equals(current.Key, key, StringComparison.Ordinal))
                {
                    current.Value = value;
                    return;
                }

                if (current.Next == null)
                {
                    current.Next = newNode;
                    _count++;
                    return;
                }

                current = current.Next;
            }
        }

        if ((double)_count / _size > 0.7)
        {
            Console.WriteLine("\nResize table, LoadFactor > 70%");
            Resize();
        }
    }

    public int Get(string key)
    {
        int index = Hash(key);

        Node? current = _dataMap[index];

        while (current != null)
        {
            if (string.Equals(current.Key, key, StringComparison.Ordinal))
            {
                Console.WriteLine($" Found key '{key}' with Value = {current.Value}");
                return current.Value;
            }

            current = current.Next;
        }

        return 0;
    }

    private void Resize()
    {
        int newSize = _size * 2;
        Node?[] newDataMap = new Node[newSize];

        Node?[] oldDataMap = _dataMap;


        _dataMap = newDataMap;
        _size = newSize;

        foreach (var node in oldDataMap)
        {
            Node? current = node;
            while (current != null)
            {
                RehashAndInsert(current.Key, current.Value);
                current = current.Next;
            }
        }
    }

    private void RehashAndInsert(string key, int value)
    {
        int index = Hash(key);

        Node newNode = new Node(key, value);

        if (_dataMap[index] == null)
        {
            _dataMap[index] = newNode;
        }
        else
        {
            Node current = _dataMap[index]!;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }
    }


    public void PrintTable()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nHash Table:");
        Console.ResetColor();

        for (int i = 0; i < _size; i++)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($"[{i}] ");
            Console.ResetColor();

            Node? current = _dataMap[i];
            if (current == null)
            {
                Console.WriteLine("∅");
                continue;
            }

            while (current != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{current.Key}");
                Console.ResetColor();
                Console.Write(" → ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{current.Value}");
                Console.ResetColor();

                current = current.Next;
                if (current != null) Console.Write(" ║ ");
            }

            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("➾ Size: " + _size);
        Console.ResetColor();
    }
}