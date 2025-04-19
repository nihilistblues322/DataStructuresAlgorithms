namespace Stack;

class Program
{
    static void Main(string[] args)
    {
        Stack myStack = new Stack(0);
        
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);
        myStack.Push(4);
        myStack.Push(5);
        myStack.Pop();
        myStack.Pop();
        
        myStack.PrintVisual();
        
        
        ArrayStack myArrayStack = new ArrayStack(10);
        
        myArrayStack.Push(100);
        myArrayStack.Push(200);
        myArrayStack.Push(300);
        myArrayStack.Push(400);
        
        myArrayStack.PrintVisual();
    }
}