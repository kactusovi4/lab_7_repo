using LinkedListLib;

/// <summary>
/// Entry point for the Lab 7 demonstration application.
/// Shows all operations of <see cref="ShortSinglyLinkedList"/>.
/// </summary>
class Program
{
    /// <summary>
    /// Prints all elements of <paramref name="list"/> to the console on one line,
    /// preceded by <paramref name="label"/>.
    /// </summary>
    /// <param name="list">The list to print.</param>
    /// <param name="label">A descriptive label shown before the elements.</param>
    static void PrintList(ShortSinglyLinkedList list, string label)
    {
        Console.Write($"{label}: [");
        bool first = true;
        foreach (short value in list)
        {
            if (!first) Console.Write(", ");
            Console.Write(value);
            first = false;
        }
        Console.WriteLine($"]  (count = {list.Count})");
    }

    /// <summary>
    /// Application entry point. Demonstrates all four variant-6 operations
    /// as well as the general-purpose features (indexer, <c>RemoveAt</c>, <c>foreach</c>).
    /// </summary>
    static void Main()
    {
        Console.WriteLine("lab 7 var 6");

        Console.WriteLine("\n--- list ---");
        ShortSinglyLinkedList linkedList = new ShortSinglyLinkedList();
        short[] values = { 2, 14, 9, 28, 1 };
        foreach (short v in values) linkedList.Append(v);
        PrintList(linkedList, "list");

        short divisor = 7;
        short? found = linkedList.FindDivisibleBy(divisor);
        Console.WriteLine($"first element divisible by {divisor}: " +
                          (found.HasValue ? found.Value.ToString() : "not found"));

        linkedList.ReplaceEvenPositionsWithZero();
        PrintList(linkedList, "after replacing even positions with 0");

        short threshold = 5;
        PrintList(linkedList.GetGreaterThan(threshold), $"elements > {threshold}");

        linkedList.RemoveOddPositions();
        PrintList(linkedList, "after removing odd positions");

    }
}
