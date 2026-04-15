namespace LinkedListLib;

/// <summary>
/// Represents a single node in a singly linked list of <see cref="short"/> values.
/// </summary>
public class Node
{
    /// <summary>
    /// Gets or sets the value stored in this node.
    /// </summary>
    public short Value { get; set; }

    /// <summary>
    /// Gets or sets the reference to the next node in the list.
    /// <c>null</c> if this is the last node.
    /// </summary>
    public Node? Next { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Node"/> class with the specified value.
    /// </summary>
    /// <param name="value">The <see cref="short"/> value to store in this node.</param>
    public Node(short value)
    {
        Value = value;
        Next = null;
    }
}
