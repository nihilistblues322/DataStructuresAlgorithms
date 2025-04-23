namespace BinarySearchTree;

public class RedBlackTree
{
    private enum Color
    {
        Red,
        Black
    }

    private class RBNode
    {
        public int Value;
        public RBNode? Left;
        public RBNode? Right;
        public Color Color;

        public RBNode(int value, Color color)
        {
            Value = value;
            Color = color;
        }
    }

    private RBNode? _root;

    public void Insert(int value)
    {
        _root = Insert(_root, value);
        _root!.Color = Color.Black;
    }

    private RBNode Insert(RBNode? node, int value)
    {
        if (node == null) return new RBNode(value, Color.Red);

        if (value < node.Value) node.Left = Insert(node.Left, value);
        else if (value > node.Value) node.Right = Insert(node.Right, value);

        return FixViolations(node);
    }

    private RBNode FixViolations(RBNode node)
    {
        if (IsRed(node.Right) && !IsRed(node.Left)) node = RotateLeft(node);
        if (IsRed(node.Left) && IsRed(node.Left!.Left)) node = RotateRight(node);
        if (IsRed(node.Left) && IsRed(node.Right)) FlipColors(node);

        return node;
    }

    private bool IsRed(RBNode? node) => node?.Color == Color.Red;

    private RBNode RotateLeft(RBNode h)
    {
        var x = h.Right!;
        h.Right = x.Left;
        x.Left = h;
        x.Color = h.Color;
        h.Color = Color.Red;
        return x;
    }

    private RBNode RotateRight(RBNode h)
    {
        var x = h.Left!;
        h.Left = x.Right;
        x.Right = h;
        x.Color = h.Color;
        h.Color = Color.Red;
        return x;
    }

    private void FlipColors(RBNode h)
    {
        h.Color = Color.Red;
        h.Left!.Color = Color.Black;
        h.Right!.Color = Color.Black;
    }

    public void PrintWithColors()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        PrintRbNode(_root, "", true);
    }

    private void PrintRbNode(RBNode? node, string indent, bool isRight)
    {
        if (node == null) return;

        Console.ForegroundColor = node.Color == Color.Red ? ConsoleColor.Red : ConsoleColor.DarkGray;

        PrintRbNode(node.Right, indent + (isRight ? "    " : "│   "), true);

        Console.Write(indent);
        Console.Write(isRight ? "┌── " : "└── ");
        Console.Write($"{node.Value}");
        Console.WriteLine();

        Console.ResetColor();
        PrintRbNode(node.Left, indent + (isRight ? "│   " : "    "), false);
    }
}