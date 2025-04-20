namespace Queue;

using System;

public interface IQueue<T>
{
    void Enqueue(T item);
    T Dequeue();
    T Peek();
    int Count { get; }
}

public sealed class RingBufferQueue<T> : IQueue<T>
{
    private const int DefaultCapacity = 4;
    private T[] _array;
    private int _head;
    private int _tail;
    private int _count;

    public RingBufferQueue(int initialCapacity = DefaultCapacity)
    {
        if (initialCapacity < 0)
            throw new ArgumentOutOfRangeException(nameof(initialCapacity),
                "Initial capacity cannot be negative.");

        _array = new T[initialCapacity];
        _head = 0;
        _tail = 0;
        _count = 0;
    }

    public int Count => _count;

    public void Enqueue(T item)
    {
        if (_count == _array.Length)
            Resize(_array.Length == 0 ? DefaultCapacity : _array.Length * 2);

        _array[_tail] = item;
        _tail = (_tail + 1) % _array.Length;
        _count++;
    }

    public T Dequeue()
    {
        if (_count == 0)
            throw new InvalidOperationException("Cannot dequeue from an empty queue.");

        T removed = _array[_head]!;
        _array[_head] = default!;
        _head = (_head + 1) % _array.Length;
        _count--;
        return removed;
    }

    public T Peek()
    {
        if (_count == 0)
            throw new InvalidOperationException("Cannot peek into an empty queue.");

        return _array[_head]!;
    }

    private void Resize(int newCapacity)
    {
        Console.WriteLine($"Resizing queue from {_array.Length} to {newCapacity}.");

        var newArray = new T[newCapacity];
        if (_count > 0)
        {
            if (_head < _tail)
            {
                Array.Copy(_array, _head, newArray, 0, _count);
            }
            else
            {
                int rightSegment = _array.Length - _head;
                Array.Copy(_array, _head, newArray, 0, rightSegment);
                Array.Copy(_array, 0, newArray, rightSegment, _tail);
            }
        }

        _array = newArray;
        _head = 0;
        _tail = _count % newCapacity;
    }
}