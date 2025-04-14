namespace DoublyLinkedList;

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList myDll = new DoublyLinkedList(1);
        myDll.Append(2);
        myDll.Append(3);
        myDll.RemoveLast();
        
   
        
        myDll.PrintVisual();
    }
}