namespace Sorting;

class Program
{
    static void Main(string[] args)
    {
        int[] array = [4, 2, 6, 5, 1, 3];
        SelectionSort(array);
        Console.WriteLine(string.Join(", ", array));
    }

    static void BubbleSort(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }

    static void BubbleSort2(int[] array)
    {
        int n = array.Length;
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 1; i < n; i++)
            {
                if (array[i - 1] > array[i])
                {
                    (array[i], array[i - 1]) = (array[i - 1], array[i]);
                    swapped = true;
                }
            }

            n--;
        } while (swapped);
    }

    static void SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[min])
                {
                    min = j;
                }
            }

            if (i != min)
            {
                (array[i], array[min]) = (array[min], array[i]);
            }
        }
    }
}