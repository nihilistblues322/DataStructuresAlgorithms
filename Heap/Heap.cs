namespace Heap;

public class Heap
{
    private List<int> _heap;

    public Heap()
    {
        _heap = [];
    }

    public List<int> GetHeap()
    {
        return [.._heap];
    }

    private int LeftChild(int parentIndex)
    {
        return 2 * parentIndex + 1;
    }

    private int RightChild(int parentIndex)
    {
        return 2 * parentIndex + 2;
    }

    private int Parent(int childIndex)
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

    #region print

    public void PrintHeap()
    {
        Console.WriteLine("\n╔══════════════════════════════════╗");
        Console.WriteLine("║         Heap Structure           ║");
        Console.WriteLine("╠══════════════════════════════════╣");

        if (_heap.Count == 0)
        {
            Console.WriteLine("║         (empty heap)             ║");
            Console.WriteLine("╚══════════════════════════════════╝");
            return;
        }

        int level = 0;
        int itemsInLevel = 1;
        int count = 0;

        for (int i = 0; i < _heap.Count; i++)
        {
            if (count == 0)
            {
                Console.Write($"║ Level {level}: ");
            }

            Console.Write($"{_heap[i]} ".PadRight(3));

            count++;
            if (count == itemsInLevel)
            {
                Console.WriteLine();
                level++;
                itemsInLevel *= 2;
                count = 0;
            }
        }

        if (count > 0)
        {
            Console.WriteLine();
        }

        Console.WriteLine("╚══════════════════════════════════╝");
        Console.WriteLine($"➤ Total elements: {_heap.Count}");
    }

    #endregion
}