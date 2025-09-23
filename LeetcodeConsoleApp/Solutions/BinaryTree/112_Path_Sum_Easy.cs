using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions.BinaryTree
{
    public class PathSum : ISolution
    {
        public void Run()
        {
            (int?[], int)[] inputs = [
                ([5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1], 22),
                ([1,2,3], 5)];
            foreach ((int?[] array, int targetSum) in inputs)
            {
                bool result = HasPathSum(new TreeNode(array), targetSum);
                Console.WriteLine($"Result {result}");
            }
        }

        private static bool HasPathSum(TreeNode root, int targetSum)
        {
            if(root==null) return false;

            targetSum -= root.val;
            if (root.left == null && root.right == null) return targetSum == 0;

            return HasPathSum(root.left, targetSum) || HasPathSum(root.right, targetSum);
        }
    }
}
