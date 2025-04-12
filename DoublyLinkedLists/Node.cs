namespace DoublyLinkedList;

public class Node
{
    public int Value;
    public Node? Next;  
    public Node? Prev;

    public Node(int value)
    {
        Value = value;
    }
}