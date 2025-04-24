namespace HashTable;

public class HashTable
{
    private int _size = 7;
    private Node?[] _dataMap;

    public HashTable()
    {
        _dataMap = new Node[_size];
    }

    private int Hash(string key)
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
        int index = Hash(key);

        Node newNode = new Node(key, value);

        if (_dataMap[index] == null)
        {
            _dataMap[index] = newNode;
        }
        else
        {
            Node temp = _dataMap[index]!;

            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
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