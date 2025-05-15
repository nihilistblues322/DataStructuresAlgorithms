namespace MergeSort;

class Program
{
    static void Main(string[] args)
    {
        int[] array = [3, 1, 4, 2];
        int[] merged = MergeSort.MergeSorting(array);
        
        MergeSort.Print(merged);
    }
}