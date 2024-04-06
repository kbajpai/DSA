using DSA.Common;

namespace DSA.TreesGraphs;

internal sealed class BSTServices : IBSTServices {
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

    private static TreeNode? BuildBSTHelper(TreeNode? root, int n) {
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