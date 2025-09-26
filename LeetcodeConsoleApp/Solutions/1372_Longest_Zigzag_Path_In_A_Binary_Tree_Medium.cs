using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions
{
    public class LongestZigZagPathInABinaryTree : ISolution
    {
        public void Run()
        {
            int?[][] inputs = [
                [1, null, 2, 1, 3, null, null, 4, 1, null, 1, null, null, null, 1],
                [1,1,1,null,1,null,null,1,1,null,1]
            ];
            foreach (int?[] input in inputs)
            {
                int result = LongestZigZag(new TreeNode(input));
                Console.WriteLine($"Result {result}");
            }
        }

        private static int LongestZigZag(TreeNode root)
        {
            if (root == null) return 0;

            int left = MoveLeft(root.left, 0);
            int right = MoveRight(root.right, 0);

            return left > right ? left : right;
        }

        private static int MoveLeft(TreeNode node, int count)
        {
            if (node == null) return count;
            int right = MoveRight(node.right, count + 1);
            int left = MoveLeft(node.left, 0);

            return left > right ? left : right;
        }

        private static int MoveRight(TreeNode node, int count)
        {
            if(node == null) return count;
            int left = MoveLeft(node.left, count + 1);
            int right = MoveRight(node.right, 0);

            return left > right ? left : right;
        }
    }
}
