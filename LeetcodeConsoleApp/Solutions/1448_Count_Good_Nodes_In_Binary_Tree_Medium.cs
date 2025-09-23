using LeetcodeConsoleApp.Models;
using System.Xml.Linq;

namespace LeetcodeConsoleApp.Solutions
{
    public class CountGoodNodesInBinaryTree : ISolution
    {
        public void Run()
        {
            int?[][] inputs = [
                [3, 1, 4, 3, null, 1, 5],
                [3,3,null,4,2],
                [9,null,3,6,null]
            ];
            foreach (int?[] input in inputs)
            {
                int result = GoodNodes(new TreeNode(input));
                Console.WriteLine($"Result {result}");
            }
        }

        private static int GoodNodes(TreeNode root)
        {
            return GetGoodNodesCount(root, -10_001);
        }

        private static int GetGoodNodesCount(TreeNode node, int maxValue)
        {
            maxValue = node.val > maxValue ? node.val : maxValue;
            return (node.left != null ? GetGoodNodesCount(node.left, maxValue) : 0)
                + (node.right != null ? GetGoodNodesCount(node.right, maxValue) : 0)
                + (node.val == maxValue ? 1 : 0);
        }

        private static int GetGoodNodesCount1(TreeNode node, int parentValue)
        {
            int count = 0;
            int maxValue = parentValue;
            if (node.val >= parentValue)
            {
                maxValue = node.val;
                count++;
            }

            if (node.left != null)
            {
                count += GetGoodNodesCount1(node.left, maxValue);
            }

            if (node.right != null)
            {
                count += GetGoodNodesCount1(node.right, maxValue);
            }

            return count;
        }
    }
}
