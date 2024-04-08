using DSA.Common;

namespace DSA.TreesGraphs;

public interface IBSTServices {
    TreeNode? BuildBST(int[] nums);

    int GetMaximumDepth(TreeNode? root);

    int GetMinimumDifference(TreeNode root);

    TreeNode? InvertTree(TreeNode? root);

    bool IsSameTree(TreeNode? p, TreeNode? q);

    bool IsSymmetric(TreeNode? root);

    bool IsValidBST(TreeNode root);

    double RangeSumBST(TreeNode root, int low, int high);

    TreeNode? Search(int n, TreeNode? root);
}