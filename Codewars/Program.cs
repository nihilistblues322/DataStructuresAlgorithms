using System.Linq;
using System.Text;
using System.Collections;

namespace Codewars;

class Program
{
    static void Main(string[] args)
    {
        // int[] arr = [1, -4, 7, 12];
        // PositiveSum(arr);
        // Print(arr);

        string str = "world";
        Console.WriteLine(ReversedStrings(str));


        int[] arr = [1, 2, 2];
        Console.WriteLine(SquareSum(arr));

        string str2 = "world";
        Console.WriteLine(Remove_char(str2));
    }

    public static int CountSheeps(bool[] sheeps)
    {
        int count = 0;
        for (int i = 0; i < sheeps.Length; i++)
        {
            if (sheeps[i])
            {
                count++;
            }
        }

        return count;
    }

    public static string RepeatStr(int n, string s)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(s);
        }

        return sb.ToString();
    }

    public static string NoSpace(string input)
    {
        var result = new StringBuilder();
        foreach (var c in input.Where(c => c != ' '))
        {
            result.Append(c);
        }

        return result.ToString();
    }

    public static int FindSmallestInt(int[] args)
    {
        int min = args[0];
        for (int i = 1; i < args.Length; i++)
        {
            if (args[i] < min)
            {
                min = args[i];
            }
        }

        return min;
    }

    public static string Remove_char(string s)
    {
        var chars = s.ToList();
        chars.RemoveAt(0);
        chars.RemoveAt(chars.Count - 1);


        return chars.Aggregate("", (a, b) => a + b);
    }


    public static int SquareSum(int[] numbers)
    {
        return numbers.Select(x => x * x).Sum();
    }

    public static string ReversedStrings(string str)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = str.Length - 1; i >= 0; i--)
        {
            sb.Append(str[i]);
        }

        return sb.ToString();
    }


    public static int PositiveSum(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (0 < arr[i])
            {
                sum += arr[i];
            }
        }

        return sum;
    }

    private static void Print(int[] array)
    {
        Console.WriteLine("[" + string.Join(", ", array) + "]");
    }
}