namespace HashTable;

public class Test
{
    public static bool ItemInCommon(int[] array1, int[] array2)
    {
        return (from i in array1 from j in array2 where i == j select i).Any();
    }

    public static bool ItemInHash(int[] array1, int[] array2)
    {
        var hashSet = new Dictionary<int, bool>();

        foreach (var i in array1)
        {
            hashSet.Add(i, true);
        }

        foreach (var j in array2)
        {
            if (hashSet.ContainsKey(j)) return true;
        }

        return false;
    }

    public int[] TwoSum(int[] nums, int target)
    {
        var numToIndex = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (numToIndex.TryGetValue(complement, out var value))
            {
                return [value, i];
            }

            numToIndex[nums[i]] = i;
        }

        return [];
    }
}