namespace MergeSort;

public static class MergeSort
{
    public static int[] MergeSorting(int[] array)
    {
        if (array.Length <= 1) return array;
        
        int middle = array.Length / 2;
        int[] left = array.Take(middle).ToArray();
        int[] right = array.Skip(middle).ToArray();

        left = MergeSorting(left);
        right = MergeSorting(right);

        return Merge(left, right);
    }

    private static int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];
        int i = 0, j = 0, index = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                result[index] = left[i];
                i++;
            }
            else
            {
                result[index] = right[j];
                j++;
            }

            index++;
        }

        while (i < left.Length)
        {
            result[index] = left[i];
            i++;
            index++;
        }

        while (j < right.Length)
        {
            result[index] = right[j];
            j++;
            index++;
        }

        return result;
    }

    public static void Print(int[] array)
    {
        Console.WriteLine("[" + string.Join(", ", array) + "]");
    }
}