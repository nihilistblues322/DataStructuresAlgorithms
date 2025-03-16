namespace DataStructuresAlgorithms;

class Program
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList(95);

        linkedList.Append(65);
        linkedList.Append(152);
        // linkedList.RemoveLast();
        // linkedList.Prepend(54);
        // linkedList.RemoveFirst();
        Console.WriteLine(linkedList.Get(1)!.Value);


        linkedList.PrintVisual();
    }
}