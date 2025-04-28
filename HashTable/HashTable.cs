using System.Text;

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
                    break;
                }

                current = current.Next;
            }
        }

        if ((double)_count / _size > 0.7)
        {
            PrintResizeNotification();
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
                PrintFoundKey(key, current.Value);
                return current.Value;
            }

            current = current.Next;
        }

        return 0;
    }

    public List<string> Keys()
    {
        List<string> keys = [];

        foreach (var t in _dataMap)
        {
            Node? current = t;
            while (current != null)
            {
                keys.Add(current.Key);
                current = current.Next;
            }
        }

        PrintKeys(keys);
        return keys;
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
        Console.OutputEncoding = Encoding.UTF8;
        PrintTableHeader();

        for (int i = 0; i < _size; i++)
        {
            PrintTableRow(i, _dataMap[i]);
        }

        PrintTableFooter();
    }

    #region Print Methods

    private void PrintResizeNotification()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n⚠ Resizing table: LoadFactor > 70%");
        Console.ResetColor();
    }

    private void PrintFoundKey(string key, int value)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" 🔍 Found key '{key}' with Value = {value}");
        Console.ResetColor();
    }

    private void PrintKeys(List<string> keys)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\n╔══════════════════════════════╗");
        Console.WriteLine("║         All Keys Found       ║");
        Console.WriteLine("╠══════════════════════════════╣");

        for (int i = 0; i < keys.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("║ ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{i + 1}. {keys[i]}".PadRight(28));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ║");
        }

        Console.WriteLine("╚══════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine($"Total keys: {keys.Count}");
    }

    private void PrintTableHeader()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("\nHash Table:");
        Console.ResetColor();
    }

    private void PrintTableRow(int index, Node? node)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write($"[{index}] ");
        Console.ResetColor();

        if (node == null)
        {
            Console.WriteLine("∅");
            return;
        }

        while (node != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{node.Key}");
            Console.ResetColor();
            Console.Write(" → ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{node.Value}");
            Console.ResetColor();

            node = node.Next;
            if (node != null) Console.Write(" ║ ");
        }

        Console.WriteLine();
    }

    private void PrintTableFooter()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("➾ Size: " + _size);
        Console.ResetColor();
    }

    #endregion
}