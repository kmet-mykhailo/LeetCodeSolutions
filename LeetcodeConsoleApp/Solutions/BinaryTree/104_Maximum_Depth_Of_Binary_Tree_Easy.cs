using LeetcodeConsoleApp.Models;
using System.Collections.Generic;

namespace LeetcodeConsoleApp.Solutions.BinaryTree
{
    public class MaximumDepthOfBinaryTree : ISolution
    {
        public void Run()
        {
            int?[][] inputs = [
                //[3,  9,20,  8,11,15,7, 16,5,2,4,13,17,19,21],
                [3,9,20,null,null,15,7],
                [1,null,2],
                []
                ];
            foreach (int?[] input in inputs)
            {
                TreeNode inputNode = input.Length > 0 ? new(input) : null;
                int result = MaxDepth(inputNode);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int right = MaxDepth(root.right);
            int left = MaxDepth(root.left);

            return right > left ? right + 1 : left + 1;
        }

        private static int MaxDepth2(TreeNode root)
        {
            if (root == null) return 0;
            List<TreeNode> queue = [root];

            int count = 0;
            while (queue.Count > 0)
            {
                count++;
                List<TreeNode> newQueue = [];
                foreach (TreeNode node in queue)
                {
                    if (node.left != null)
                    {
                        newQueue.Add(node.left);
                    }

                    if (node.right != null)
                    {
                        newQueue.Add(node.right);
                    }
                }

                queue = newQueue;
            }

            return count;
        }

        private static int MaxDepth1(TreeNode root)
        {
            if(root==null) return 0;
            Queue<TreeNode> queue = [];

            if (root.left != null)
            {
                queue.Enqueue(root.left);
            }

            if (root.right != null)
            {
                queue.Enqueue(root.right);
            }

            int count = 1;
            while (queue.Count > 0)
            {
                count++;
                Queue<TreeNode> newQueue = [];
                foreach (TreeNode node in queue)
                {
                    if (node.left != null)
                    {
                        newQueue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        newQueue.Enqueue(node.right);
                    }
                }

                queue = newQueue;
            }

            return count;
        }
    }
}
