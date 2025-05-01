namespace Heap;

class Program
{
    static void Main(string[] args)
    {
        var heap = new Heap();
        
        heap.Insert(99);
        heap.Insert(72);
        heap.Insert(61);
        heap.Insert(58);

        heap.PrintHeap();
        heap.PrintArray();
        
        heap.Insert(21);
        
        heap.PrintHeap();
        heap.PrintArray();

        
        heap.Remove();
        heap.PrintHeap();
        heap.PrintArray();

        
        // heap.Insert(75);
        //
        // heap.PrintHeap();
        //
        // heap.Insert(65);
        // heap.Insert(77);
        // heap.Insert(42);
        //
        // heap.Remove();
        // heap.PrintHeap();
    }
}