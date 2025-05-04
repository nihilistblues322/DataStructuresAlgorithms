namespace Heap;

public class Heap
{
    private readonly List<int> _heap = [];


    private static int LeftChild(int parentIndex)
    {
        return 2 * parentIndex + 1;
    }

    private static int RightChild(int parentIndex)
    {
        return 2 * parentIndex + 2;
    }

    private static int Parent(int childIndex)
    {
        return (childIndex - 1) / 2;
    }

    private void Swap(int firstIndex, int secondIndex)
    {
        (_heap[firstIndex], _heap[secondIndex]) = (_heap[secondIndex], _heap[firstIndex]);
    }

    public void Insert(int value)
    {
        _heap.Add(value);
        int currentIndex = _heap.Count - 1;

        while (currentIndex > 0 && _heap[currentIndex] > _heap[Parent(currentIndex)])
        {
            Swap(currentIndex, Parent(currentIndex));
            currentIndex = Parent(currentIndex);
        }
    }

    public int Remove()
    {
        if (_heap.Count == 0)
            throw new InvalidOperationException("Heap is empty.");

        int maxValue = _heap[0];
        int lastIndex = _heap.Count - 1;

        if (_heap.Count == 1)
        {
            _heap.RemoveAt(0);
            return maxValue;
        }

        _heap[0] = _heap[lastIndex];
        _heap.RemoveAt(lastIndex);

        SinkDown(0);

        return maxValue;
    }

    private void SinkDown(int index)
    {
        int maxIndex = index;

        while (true)
        {
            int leftIndex = LeftChild(index);
            int rightIndex = RightChild(index);

            if (leftIndex < _heap.Count && _heap[leftIndex] > _heap[maxIndex])
            {
                maxIndex = leftIndex;
            }

            if (rightIndex < _heap.Count && _heap[rightIndex] > _heap[maxIndex])
            {
                maxIndex = rightIndex;
            }

            if (maxIndex != index)
            {
                Swap(index, maxIndex);
                index = maxIndex;
            }
            else
            {
                return;
            }
        }
    }


    #region print

    public void PrintArray()
    {
        Console.WriteLine("\nHeap array: [" + string.Join(", ", _heap) + "]");
    }


    public void PrintHeap()
    {
        Console.WriteLine("\n╔════════════════════════════════════════════╗");
        Console.WriteLine("║               Heap Structure               ║");
        Console.WriteLine("╠════════════════════════════════════════════╣");

        if (_heap.Count == 0)
        {
            Console.WriteLine("║              (empty heap)                  ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            return;
        }

        int level = 0;
        int index = 0;
        int itemsInLevel = 1;

        while (index < _heap.Count)
        {
            Console.Write($"║ Level {level}: ");

            int countInThisLevel = 0;
            while (countInThisLevel < itemsInLevel && index < _heap.Count)
            {
                string indicator = "";

                int parentIndex = Parent(index);

                if (index == 0)
                {
                    indicator = "";
                }
                else if (index == LeftChild(parentIndex))
                {
                    indicator = "(L)";
                }
                else if (index == RightChild(parentIndex))
                {
                    indicator = "(R)";
                }

                Console.Write($"{_heap[index]}{indicator} ".PadRight(8));
                index++;
                countInThisLevel++;
            }

            Console.WriteLine();
            level++;
            itemsInLevel *= 2;
        }

        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.WriteLine($"➤ Total elements: {_heap.Count}");
    }

    #endregion
}