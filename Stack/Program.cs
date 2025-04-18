namespace Stack;

class Program
{
    static void Main(string[] args)
    {
        Stack myStack = new Stack(2);
        
        myStack.Push(1);
        
        myStack.PrintVisual();
    }
}