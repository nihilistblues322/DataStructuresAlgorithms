namespace MergeSortOptimized;

class Program
{
    static void Main(string[] args)
    {
        int[] array = [3, 1, 4, 2];
        MergeSort.Sort(array);

        MergeSort.Print(array);
    }
}