using System.Collections;

namespace LinkedListLib;

/// <summary>
/// Represents a singly linked list whose elements are of type <see cref="short"/>.
/// Elements are added to the end of the list.
/// Supports indexed access (read-only), removal by position, and <c>foreach</c> enumeration.
/// </summary>
public class ShortSinglyLinkedList : IEnumerable<short>
{
    private Node? _head;
    private int _count;

    /// <summary>
    /// Gets the number of elements currently in the list.
    /// </summary>
    public int Count => _count;

    /// <summary>
    /// Initializes a new empty instance of the <see cref="ShortSinglyLinkedList"/> class.
    /// </summary>
    public ShortSinglyLinkedList()
    {
        _head = null;
        _count = 0;
    }

    /// <summary>
    /// Appends a new element with the specified value to the end of the list.
    /// </summary>
    /// <param name="value">The <see cref="short"/> value to add.</param>
    public void Append(short value)
    {
        Node newNode = new Node(value);

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node current = _head;
            while (current.Next != null)
                current = current.Next;
            current.Next = newNode;
        }

        _count++;
    }

    /// <summary>
    /// Gets the element at the specified zero-based index (read-only).
    /// </summary>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <returns>The <see cref="short"/> value at the given index.</returns>
    /// <exception cref="IndexOutOfRangeException">
    /// Thrown when <paramref name="index"/> is less than zero or greater than or equal to <see cref="Count"/>.
    /// </exception>
    public short this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException($"index {index} is out of range.");

            Node current = _head!;
            for (int i = 0; i < index; i++)
                current = current.Next!;

            return current.Value;
        }
    }

    /// <summary>
    /// Removes the element at the specified zero-based index (counting from the head).
    /// </summary>
    /// <param name="index">The zero-based index of the element to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="index"/> is less than 0 or greater than or equal to <see cref="Count"/>.
    /// </exception>
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index),
                $"index {index} is out of range.");

        if (index == 0)
        {
            _head = _head!.Next;
        }
        else
        {
            Node current = _head!;
            for (int i = 0; i < index - 1; i++)
                current = current.Next!;

            current.Next = current.Next!.Next;
        }

        _count--;
    }

    /// <summary>
    /// Finds the first element in the list whose value is divisible by <paramref name="divisor"/>.
    /// </summary>
    /// <param name="divisor">The value to test divisibility against. Must not be zero.</param>
    /// <returns>
    /// The first <see cref="short"/> value divisible by <paramref name="divisor"/>,
    /// or <c>null</c> if no such element exists.
    /// </returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="divisor"/> is zero.</exception>
    public short? FindDivisibleBy(short divisor)
    {
        if (divisor == 0)
            throw new ArgumentException("divisor must not be zero.", nameof(divisor));

        Node? current = _head;
        while (current != null)
        {
            if (current.Value % divisor == 0)
                return current.Value;
            current = current.Next;
        }

        return null;
    }

    /// <summary>
    /// Replaces the values of all elements at even one-based positions (2, 4, 6, …)
    /// with zero. Positions are counted from the head.
    /// </summary>
    public void ReplaceEvenPositionsWithZero()
    {
        Node? current = _head;
        int position = 1;

        while (current != null)
        {
            if (position % 2 == 0)
                current.Value = 0;

            current = current.Next;
            position++;
        }
    }

    /// <summary>
    /// Creates and returns a new <see cref="ShortSinglyLinkedList"/> containing only those
    /// elements whose values are strictly greater than <paramref name="threshold"/>.
    /// The original list is not modified.
    /// </summary>
    /// <param name="threshold">The lower bound (exclusive) for element selection.</param>
    /// <returns>A new list with elements greater than <paramref name="threshold"/>.</returns>
    public ShortSinglyLinkedList GetGreaterThan(short threshold)
    {
        ShortSinglyLinkedList result = new ShortSinglyLinkedList();
        Node? current = _head;

        while (current != null)
        {
            if (current.Value > threshold)
                result.Append(current.Value);
            current = current.Next;
        }

        return result;
    }

    /// <summary>
    /// Removes all elements at odd one-based positions (1, 3, 5, …) from the list.
    /// Positions are counted from the head before any removals.
    /// After the operation the list contains only the originally even-positioned elements.
    /// </summary>
    public void RemoveOddPositions()
    {
        // Always remove the head (position 1 is odd).
        if (_head == null) return;

        _head = _head.Next;
        _count--;

        // Walk through remaining nodes: current is at an even-original position (keep it),
        // current.Next is at an odd-original position (remove it).
        Node? current = _head;
        while (current != null && current.Next != null)
        {
            current.Next = current.Next.Next;
            _count--;
            current = current.Next;
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates through the list from head to tail.
    /// </summary>
    /// <returns>An <see cref="IEnumerator{T}"/> of <see cref="short"/>.</returns>
    public IEnumerator<short> GetEnumerator()
    {
        Node? current = _head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
