namespace DoublyLinkedList;

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList myDll = new DoublyLinkedList(1);
        myDll.Append(2);
        myDll.Append(3);
        myDll.Append(4);
        myDll.Set(2, 99);
        myDll.Insert(3, 66);
        myDll.RemoveLast();
        myDll.Prepend(14);
        myDll.RemoveFirst();
        Console.WriteLine(myDll.Get(1)!.Value);
        Console.WriteLine(myDll.Get(2)!.Value);
        myDll.Remove(2);
        
   
        
        myDll.PrintVisual();
    }
}