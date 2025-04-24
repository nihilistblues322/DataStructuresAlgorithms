namespace HashTable;

public class Node
{
    public string Key;
    public int Value;
    public Node? Next;

    public Node(string key, int value)
    {
        Key = key;
        Value = value;
    }
}