﻿namespace BinarySearchTree;

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

    public bool Delete(int value)
    {
        Node? current = _root;
        Node? parent = null;

        while (current != null)
        {
            if (value < current.Value)
            {
                parent = current;
                current = current.Left;
            }
            else if (value > current.Value)
            {
                parent = current;
                current = current.Right;
            }
            else
            {
                if (current.Left == null && current.Right == null)
                {
                    ReplaceChild(parent, current, null);
                }
                else if (current.Left == null)
                {
                    ReplaceChild(parent, current, current.Right);
                }
                else if (current.Right == null)
                {
                    ReplaceChild(parent, current, current.Left);
                }
                else
                {
                    Node minParent = current;
                    Node min = current.Right;

                    while (min.Left != null)
                    {
                        minParent = min;
                        min = min.Left;
                    }

                    current.Value = min.Value;

                    if (minParent.Left == min)
                    {
                        minParent.Left = min.Right;
                    }
                    else
                    {
                        minParent.Right = min.Right;
                    }
                }

                return true;
            }
        }

        return false;
    }

    private void ReplaceChild(Node? parent, Node current, Node? newChild)
    {
        if (parent == null)
        {
            _root = newChild;
        }
        else if (parent.Left == current)
        {
            parent.Left = newChild;
        }
        else if (parent.Right == current)
        {
            parent.Right = newChild;
        }
    }

    public List<int> BreadthFirstSearch()
    {
        Node current = _root!;

        Queue<Node> queue = new();
        List<int> result = new();

        queue.Enqueue(current);

        while (queue.Count > 0)
        {
            current = queue.Dequeue();
            result.Add(current.Value);

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }

        return result;
    }

    public List<int> DepthFirstSearchPreOrderIterative()
    {
        var result = new List<int>();
        if (_root == null) return result;

        var stack = new Stack<Node>();
        stack.Push(_root);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            result.Add(current.Value);

            if (current.Right != null)
                stack.Push(current.Right);

            if (current.Left != null)
                stack.Push(current.Left);
        }

        return result;
    }

    public List<int> DepthFirstSearchPreOrderRecursive()
    {
        var result = new List<int>();
        DfsPreOrderRecursive(_root, result);
        return result;
    }

    private void DfsPreOrderRecursive(Node? current, List<int> result)
    {
        if (current == null) return;
        result.Add(current.Value);
        DfsPreOrderRecursive(current.Left, result);
        DfsPreOrderRecursive(current.Right, result);
    }

    public List<int> DepthFirstSearchPostOrderIterative()
    {
        var result = new List<int>();
        if (_root == null) return result;

        var stack1 = new Stack<Node>();
        var stack2 = new Stack<Node>();
        stack1.Push(_root);

        while (stack1.Count > 0)
        {
            var current = stack1.Pop();
            stack2.Push(current);

            if (current.Left != null)
                stack1.Push(current.Left);

            if (current.Right != null)
                stack1.Push(current.Right);
        }

        while (stack2.Count > 0)
        {
            result.Add(stack2.Pop().Value);
        }

        return result;
    }

    public List<int> DepthFirstSearchPostOrderRecursive()
    {
        var result = new List<int>();
        DfsPostOrderRecursive(_root, result);
        return result;
    }

    private void DfsPostOrderRecursive(Node? current, List<int> result)
    {
        if (current == null) return;

        DfsPostOrderRecursive(current.Left, result);
        DfsPostOrderRecursive(current.Right, result);
        result.Add(current.Value);
    }

    public List<int> DepthFirstSearchInOrderIterative()
    {
        var result = new List<int>();
        if (_root == null) return result;

        var stack = new Stack<Node>();
        Node current = _root;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left!;
            }

            current = stack.Pop();
            result.Add(current.Value);

            current = current.Right!;
        }

        return result;
    }

    public List<int> DepthFirstSearchInOrderRecursive()
    {
        var result = new List<int>();
        DfsInOrderRecursive(_root, result);
        return result;
    }

    private void DfsInOrderRecursive(Node? current, List<int> result)
    {
        if (current == null) return;

        DfsInOrderRecursive(current.Left, result);
        result.Add(current.Value);
        DfsInOrderRecursive(current.Right, result);
    }


    #region recursion

    public bool RecursiveContains(int value)
    {
        return RecursiveContains(_root, value);
    }

    private static bool RecursiveContains(Node? current, int value)
    {
        if (current == null)
        {
            Console.WriteLine($"Reached a null node. {value} not found.");

            return false;
        }

        Console.WriteLine($"Visiting node with value: {current.Value}");

        if (current.Value == value)
        {
            Console.WriteLine($"Found value: {value}!");

            return true;
        }

        if (value < current.Value)
        {
            Console.WriteLine($"Going left: {value} < {current.Value}");

            return RecursiveContains(current.Left, value);
        }
        else
        {
            Console.WriteLine($"Going right: {value} > {current.Value}");

            return RecursiveContains(current.Right, value);
        }
    }

    public void RecursiveInsert(int value)
    {
        if (_root == null)
        {
            Console.WriteLine($"Inserting {value} as root.");

            _root = new Node(value);
        }
        else
        {
            Console.WriteLine($"Starting recursive insert for {value}.");

            _root = RecursiveInsert(_root, value);
        }
    }

    private Node RecursiveInsert(Node? current, int value)
    {
        if (current == null)
        {
            Console.WriteLine($"Inserting {value} at null position.");

            return new Node(value);
        }

        if (value < current.Value)
        {
            Console.WriteLine($"Going left: {value} < {current.Value}");

            current.Left = RecursiveInsert(current.Left, value);
        }
        else if (value > current.Value)
        {
            Console.WriteLine($"Going right: {value} > {current.Value}");

            current.Right = RecursiveInsert(current.Right, value);
        }
        else
        {
            Console.WriteLine($"Value {value} already exists, skipping insert.");
        }

        return current;
    }


    public void RecursiveDelete(int value)
    {
        _root = RecursiveDelete(_root, value);
    }

    private Node? RecursiveDelete(Node? current, int value)
    {
        if (current == null)
        {
            Console.WriteLine($"Value {value} not found in the tree.");

            return null;
        }

        if (value < current.Value)
        {
            Console.WriteLine($"Going LEFT to delete {value} (current: {current.Value})");

            current.Left = RecursiveDelete(current.Left, value);
        }
        else if (value > current.Value)
        {
            Console.WriteLine($"Going RIGHT to delete {value} (current: {current.Value})");

            current.Right = RecursiveDelete(current.Right, value);
        }
        else
        {
            Console.WriteLine($"Found {value} - preparing to delete.");

            if (current.Left == null && current.Right == null)
            {
                Console.WriteLine($" - Node {current.Value} is a leaf. Deleting.");

                return null;
            }

            if (current.Left == null)
            {
                Console.WriteLine($" - Node {current.Value} has only right child. Replacing with right child.");

                return current.Right;
            }

            if (current.Right == null)
            {
                Console.WriteLine($" - Node {current.Value} has only left child. Replacing with left child.");

                return current.Left;
            }

            Console.WriteLine($" - Node {current.Value} has TWO children. Finding min in right subtree...");

            int minValue = MinValue(current.Right);

            Console.WriteLine($" - Min value in right subtree: {minValue}. Replacing and deleting duplicate.");

            current.Value = minValue;
            current.Right = RecursiveDelete(current.Right, minValue);
        }

        return current;
    }

    private int MinValue(Node? currentNode)
    {
        while (currentNode!.Left != null)
        {
            currentNode = currentNode.Left;
        }

        return currentNode.Value;
    }

    #endregion


    #region print

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

    #endregion
}