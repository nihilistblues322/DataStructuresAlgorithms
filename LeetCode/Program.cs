namespace LeetCode;

public class Program
{
    static void Main(string[] args)
    {
        int[] nums = [2, 7, 11, 15];
        int target = 9;

        var result = TwoSum(nums, target);
        PrintArray(result);
    }

    public static int[] TwoSum(int[] nums, int target)
    {
        // Словарь: число → его индекс
        var seenNumbers = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int currentNumber = nums[i];
            int needToFind = target - currentNumber; // Что нам нужно найти?

            // Проверяем: видели ли мы уже нужное число?
            if (seenNumbers.TryGetValue(needToFind, out var number))
            {
                // Нашли пару! Возвращаем индексы
                return [number, i];
            }

            // Запоминаем текущее число и его индекс
            seenNumbers[currentNumber] = i;
        }
 
        // Пара не найдена
        return [];
    }


    public static void PrintArray(int[] array)
    {
        if (array.Length == 0)
        {
            Console.WriteLine("[]");
            return;
        }

        Console.WriteLine($"[{string.Join(", ", array)}]");
    }
}