namespace MergeSortOptimized;

public static class MergeSort
{
    public static void Sort(int[]? array)
    {
        if (array == null || array.Length <= 1) return;

        int[] buffer = new int[array.Length];
        MergeSortRecursive(array, buffer, 0, array.Length - 1);
    }

    private static void MergeSortRecursive(int[] array, int[] buffer, int left, int right)
    {
        if (left >= right)
            return;

        int mid = left + (right - left) / 2;

        MergeSortRecursive(array, buffer, left, mid);
        MergeSortRecursive(array, buffer, mid + 1, right);
        Merge(array, buffer, left, mid, right);
    }

    private static void Merge(int[] array, int[] buffer, int left, int mid, int right)
    {
        int i = left;
        int j = mid + 1;
        int k = left;

        while (i <= mid && j <= right)
        {
            if (array[i] <= array[j])
            {
                buffer[k++] = array[i++];
            }
            else
            {
                buffer[k++] = array[j++];
            }
        }

        while (i <= mid)
        {
            buffer[k++] = array[i++];
        }

        while (j <= right)
        {
            buffer[k++] = array[j++];
        }

        for (int idx = left; idx <= right; idx++)
        {
            array[idx] = buffer[idx];
        }
    }

    public static void Print(int[] array)
    {
        Console.WriteLine("[" + string.Join(", ", array) + "]");
    }
}