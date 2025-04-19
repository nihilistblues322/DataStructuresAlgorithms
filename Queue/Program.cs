namespace Queue;

class Program
{
    static void Main(string[] args)
    {
        Queue myQueue = new Queue(1);
        
        myQueue.Enqueue(2);
        myQueue.Dequeue();
        myQueue.Dequeue();
        
        myQueue.PrintVisual();
    }
}