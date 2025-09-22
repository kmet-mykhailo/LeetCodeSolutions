using System;

namespace LeetcodeConsoleApp.Models
{
    internal class TreeNode
    {
        public int val;
        public TreeNode? left;
        public TreeNode? right;

        public TreeNode(int value = 0, TreeNode? leftChild = null, TreeNode? rightChild = null)
        {
            val = value;
            left = leftChild;
            right = rightChild;
        }

        public TreeNode(int?[] array)
        {
            val = array[0].Value;
            Queue<TreeNode?> queue = new();
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (i >= array.Length / 2)
                {
                    queue.Enqueue(array[i].HasValue ? new TreeNode(array[i].Value) : null);
                }
                else
                {
                    TreeNode rightNode = queue.Dequeue();
                    TreeNode leftNode = queue.Dequeue();
                    queue.Enqueue(array[i].HasValue ? new TreeNode(array[i].Value, leftNode, rightNode) : null);
                }
            }

            right = queue.Dequeue();
            left = queue.Dequeue();
        }
    }
}
