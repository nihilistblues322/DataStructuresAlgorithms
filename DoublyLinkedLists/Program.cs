namespace DoublyLinkedList;

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList myDll = new DoublyLinkedList(5);
        myDll.Append(2);
        myDll.Append(3);
        // myDll.RemoveLast();
        myDll.Prepend(1);
        
   
        
        myDll.PrintVisual();
    }
}