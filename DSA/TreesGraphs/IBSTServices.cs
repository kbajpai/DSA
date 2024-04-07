using DSA.Common;

namespace DSA.TreesGraphs;

public interface IBSTServices {
    TreeNode? BuildBST(int[] nums);

    int GetMaximumDepth(TreeNode? root);

    TreeNode? InvertTree(TreeNode? root);

    bool IsSameTree(TreeNode? p, TreeNode? q);

    bool IsSymmetric(TreeNode? root);
}