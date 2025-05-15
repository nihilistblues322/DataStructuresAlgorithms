namespace QuickSort;

class Program
{
    static void Main(string[] args)
    {
        int[] array = [4, 6, 1, 7, 3, 2, 5];
        QuickSort(array, 0, array.Length - 1);

        Console.WriteLine("[" + string.Join(", ", array) + "]");
    }

    public static void QuickSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Pivot(array, left, right);
            QuickSort(array, left, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, right);
        }
    }

    private static int Pivot(int[] array, int pivotIndex, int endIndex)
    {
        int swapIndex = pivotIndex;

        for (int i = pivotIndex + 1; i <= endIndex; i++)
        {
            if (array[i] < array[pivotIndex])
            {
                swapIndex++;
                Swap(array, swapIndex, i);
            }
        }

        Swap(array, pivotIndex, swapIndex);

        return swapIndex;
    }

    private static void Swap(int[] array, int first, int second)
    {
        (array[first], array[second]) = (array[second], array[first]);
    }
}