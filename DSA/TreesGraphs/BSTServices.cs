using DSA.Common;

namespace DSA.TreesGraphs;

internal sealed class BSTServices : IBSTServices {
    /// <summary>
    ///     Builds a Binary Search Tree (BST) from an array of integers.
    /// </summary>
    /// <param name="nums">An array of integers to build the BST from.</param>
    /// <returns>The root node of the BST, or null if the input array is empty.</returns>
    public TreeNode? BuildBST(int[] nums) {
        if (nums.Length == 0)
            return default;

        var root = new TreeNode {
            Value = nums[0]
        };

        for (var i = 1; i < nums.Length; i++) {
            BuildBSTHelper(root, nums[i]);
        }

        return root;
    }

    /// <summary>
    ///     Gets the maximum depth of a binary tree.
    /// </summary>
    /// <param name="root">The root node of the tree.</param>
    /// <returns>The maximum depth of the tree.</returns>
    public int GetMaximumDepth(TreeNode? root) {
        return root == null ? 0 : Math.Max(GetMaximumDepth(root.Left), GetMaximumDepth(root.Right)) + 1;
    }

    public TreeNode? InvertTree(TreeNode? root) {
        if (root == null)
            return null;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Any()) {
            var current = queue.Dequeue();

            // Swap the left and right children
            (current.Left, current.Right) = (current.Right, current.Left);

            // Enqueue the children if they are not null
            if (current.Left != null) {
                queue.Enqueue(current.Left);
            }

            if (current.Right != null) {
                queue.Enqueue(current.Right);
            }
        }
        return root;
    }

    /// <summary>
    ///     Checks if two binary trees are the same.
    /// </summary>
    /// <param name="p">The root node of the first tree.</param>
    /// <param name="q">The root node of the second tree.</param>
    /// <returns>True if the trees are the same, false otherwise.</returns>
    public bool IsSameTree(TreeNode? p, TreeNode? q) {
        if (p == null && q == null)
            return true;

        if (p == null || q == null)
            return false;

        if (p.Value != q.Value) {
            return false;
        }

        return IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right);
    }

    public bool IsSymmetric(TreeNode? root) {
		return IsSameTree(root, InvertTree(root));
    }

    /// <summary>
    ///     Helper method to build a Binary Search Tree (BST).
    /// </summary>
    /// <param name="root">The root node of the tree.</param>
    /// <param name="n">The value to insert into the tree.</param>
    /// <returns>The root node of the tree after the value has been inserted.</returns>
    private static TreeNode BuildBSTHelper(TreeNode? root, int n) {
        if (root == null) {
            return new TreeNode { Value = n };
        }

        if (n < root.Value) {
            root.Left = BuildBSTHelper(root.Left, n);
        }
        else if (n > root.Value) {
            root.Right = BuildBSTHelper(root.Right, n);
        }

        return root;
    }
}