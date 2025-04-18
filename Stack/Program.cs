namespace Stack;

class Program
{
    static void Main(string[] args)
    {
        Stack myStack = new Stack(0);
        
        myStack.Push(1);
        myStack.Push(3);
        myStack.Push(4);
        myStack.Push(5);
        myStack.Push(6);
        myStack.Pop();
        
        myStack.PrintVisual();
    }
}