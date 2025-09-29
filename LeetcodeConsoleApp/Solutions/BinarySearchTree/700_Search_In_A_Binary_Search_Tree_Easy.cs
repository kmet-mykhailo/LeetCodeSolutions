using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions.BinarySearchTree
{
    public class SearchInABinarySearchTree : ISolution
    {
        public void Run()
        {
            (int?[] t, int val)[] inputs = [([4, 2, 7, 1, 3], 3)];
            foreach ((int?[] t, int val) in inputs)
            {
                TreeNode result = SearchBST(new TreeNode(t), val);
                Console.WriteLine(result == null ? "[]" : result);
            }
        }

        private static TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;
            if (root.val == val) return root;

            return root.val > val ? SearchBST(root.left, val) : SearchBST(root.right, val);
        }
    }
}
