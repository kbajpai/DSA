namespace DSA.Common;

/// <summary>
///     Represents a node in a doubly linked list.
/// </summary>
public class ListNode(int a) {
    /// <summary>
    ///     Gets or sets the previous node in the linked list.
    /// </summary>
    public ListNode? Prev { get; set; } = null;

    /// <summary>
    ///     Gets or sets the value of the node.
    /// </summary>
    public int Val { get; set; } = a;

    /// <summary>
    ///     Gets or sets the next node in the linked list.
    /// </summary>
    public ListNode? Next { get; set; } = null;
}