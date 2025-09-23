using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions
{
    public class LeafSimilarTrees : ISolution
    {
        public void Run()
        {
            (int?[] array1, int?[] array2)[] inputs = [
                ([3, 5, 1, 6, 2, 9, 8, null, null, 7, 4], [3,5,1,6,7,4,2,null,null,null,null,null,null,9,8]),
                ([3,5,1,6,2,9,8,null,null,7,14],[3,5,1,6,71,4,2,null,null,null,null,null,null,9,8])
                ];

            foreach ((int?[] array1, int?[] array2) in inputs)
            {
                bool result = LeafSimilar(new TreeNode(array1), new TreeNode(array2));
                Console.WriteLine($"Result {result}");

            }
        }

        private static bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            int[] array1 = new int[200];
            int[] array2 = new int[200];
            int index1 = 0;
            int index2 = 0;
            GetLeaves(root1, array1, ref index1);
            GetLeaves(root2, array2, ref index2);

            for (int i = 0; i <= index1; i++)
            {                
                if(array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static void GetLeaves(TreeNode node, int[] queue, ref int index)
        {
            if (node.left == null && node.right == null)
            {
                queue[index] = node.val;
                index++;
            }
            else
            {
                if (node.left != null) GetLeaves(node.left, queue, ref index);
                if (node.right != null) GetLeaves(node.right, queue, ref index);
            }
        }


        private static bool LeafSimilar1(TreeNode root1, TreeNode root2)
        {
            Queue<int> queue1 = [];
            Queue<int> queue2 = [];
            GetLeafs1(root1, queue1);
            GetLeafs1(root2, queue2);
            
            return queue1.SequenceEqual(queue2);
        }

        private static void GetLeafs1(TreeNode node, Queue<int> queue)
        {
            if (node.left == null && node.right == null)
            {
                queue.Enqueue(node.val);
            }
            else
            {
                if (node.left != null) GetLeafs1(node.left, queue);
                if (node.right != null) GetLeafs1(node.right, queue);
            }
        }
        
    }
}
