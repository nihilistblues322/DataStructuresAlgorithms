namespace BinarySearchTree;

public class AvlTree
{
    private class AvlNode
    {
        public int Value;
        public AvlNode? Left;
        public AvlNode? Right;
        public int Height;

        public AvlNode(int value)
        {
            Value = value;
            Height = 1;
        }
    }

    private AvlNode? _root;

    public void Insert(int value) => _root = Insert(_root, value);

    private AvlNode Insert(AvlNode? node, int value)
    {
        if (node == null) return new AvlNode(value);

        if (value < node.Value) node.Left = Insert(node.Left, value);
        else if (value > node.Value) node.Right = Insert(node.Right, value);
        else return node;

        UpdateHeight(node);
        return Rebalance(node);
    }

    private void UpdateHeight(AvlNode node) =>
        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

    private int GetHeight(AvlNode? node) => node?.Height ?? 0;

    private int GetBalanceFactor(AvlNode node) =>
        GetHeight(node.Left) - GetHeight(node.Right);

    private AvlNode Rebalance(AvlNode node)
    {
        int balance = GetBalanceFactor(node);

        if (balance > 1)
        {
            if (GetBalanceFactor(node.Left!) < 0) node.Left = RotateLeft(node.Left!);
            return RotateRight(node);
        }

        if (balance < -1)
        {
            if (GetBalanceFactor(node.Right!) > 0) node.Right = RotateRight(node.Right!);
            return RotateLeft(node);
        }

        return node;
    }

    private AvlNode RotateRight(AvlNode y)
    {
        var x = y.Left!;
        y.Left = x.Right;
        x.Right = y;
        UpdateHeight(y);
        UpdateHeight(x);
        return x;
    }

    private AvlNode RotateLeft(AvlNode x)
    {
        var y = x.Right!;
        x.Right = y.Left;
        y.Left = x;
        UpdateHeight(x);
        UpdateHeight(y);
        return y;
    }

    public void PrintWithHeights()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        PrintAVLNode(_root, "", true);
    }

    private void PrintAVLNode(AvlNode? node, string indent, bool isRight)
    {
        if (node == null) return;

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        PrintAVLNode(node.Right, indent + (isRight ? "    " : "│   "), true);

        Console.Write(indent);
        Console.Write(isRight ? "┌── " : "└── ");
        Console.Write($"{node.Value} (h:{node.Height})");
        Console.WriteLine();

        Console.ResetColor();
        PrintAVLNode(node.Left, indent + (isRight ? "│   " : "    "), false);
    }
}