namespace Factorial;

class Program
{
    static void Main(string[] args)
    {
        int fact = Factorial(4);
        Console.WriteLine(fact);
    }

    private static int Factorial(int n)
    {
        if (n == 1) return 1;

        return n * Factorial(n - 1);
    }
}