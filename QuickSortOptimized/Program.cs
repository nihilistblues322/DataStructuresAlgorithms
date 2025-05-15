namespace QuickSortOptimized;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 4, 6, 1, 7, 3, 2, 5 };

        Console.WriteLine("Initial Array:");
        PrintArray(array);

        QuickSort(array, 0, array.Length - 1);

        Console.WriteLine("\nSorted Array:");
        PrintArray(array);
    }

    public static void QuickSort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);
            QuickSort(array, low, pivotIndex);
            QuickSort(array, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = MedianOfThree(array, low, high);
        int i = low - 1;
        int j = high + 1;

        while (true)
        {
            do
            {
                i++;
            } while (array[i] < pivot);

            do
            {
                j--;
            } while (array[j] > pivot);

            if (i >= j)
                return j;

            Swap(array, i, j);
        }
    }

    private static int MedianOfThree(int[] array, int low, int high)
    {
        int mid = low + (high - low) / 2;

        if (array[high] < array[low])
            Swap(array, low, high);
        if (array[mid] < array[low])
            Swap(array, mid, low);
        if (array[high] < array[mid])
            Swap(array, high, mid);

        return array[mid];
    }

    private static void Swap(int[] array, int i, int j)
    {
        (array[i], array[j]) = (array[j], array[i]);
    }

    private static void PrintArray(int[] array)
    {
        Console.WriteLine("[" + string.Join(", ", array) + "]");
    }
}