namespace BinarySearchTree;

public class BinarySearchTree
{
    private Node? _root;

    public bool Insert(int value)
    {
        Node newNode = new Node(value);

        if (_root == null)
        {
            _root = newNode;
            return true;
        }

        Node pointer = _root;

        while (true)
        {
            if (value == pointer.Value) return false;

            if (value < pointer.Value)
            {
                if (pointer.Left == null)
                {
                    pointer.Left = newNode;
                    return true;
                }

                pointer = pointer.Left;
            }
            else
            {
                if (pointer.Right == null)
                {
                    pointer.Right = newNode;
                    return true;
                }

                pointer = pointer.Right;
            }
        }
    }

    public bool Contains(int value)
    {
        Node? pointer = _root;

        while (pointer != null)
        {
            if (value < pointer.Value)
            {
                pointer = pointer.Left;
            }
            else if (value > pointer.Value)
            {
                pointer = pointer.Right;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public void PrintTree()
    {
        PrintNode(_root, "", true, 0);
    }

    private void PrintNode(Node? node, string indent, bool isRight, int level)
    {
        if (node == null) return;

        ConsoleColor[] levelColors =
        [
            ConsoleColor.Magenta,
            ConsoleColor.Cyan,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkYellow,
            ConsoleColor.DarkGreen
        ];

        PrintNode(node.Right, indent + (isRight ? "    " : "│   "), true, level + 1);

        Console.Write(indent);
        Console.Write(isRight ? "┌── " : "└── ");

        Console.ForegroundColor = level < levelColors.Length ? levelColors[level] : ConsoleColor.Gray;
        Console.WriteLine(node.Value);
        Console.ResetColor();

        PrintNode(node.Left, indent + (isRight ? "│   " : "    "), false, level + 1);
    }
}