using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions.BinaryTree
{
    public class MaximumLevelSumOfABinaryTree : ISolution
    {
        public void Run()
        {
            int?[][] inputs = [
                [1, 7, 0, 7, -8, null, null],
                [989,null,10250,98693,-89388,null,null,null,-32127],
                [-100,-200,-300,-20,-5,-10,null],
                [1, 1,0, 7,-8,-7,9]
            ];
            foreach (int?[] input in inputs)
            {
                int result = MaxLevelSum(new TreeNode(input));
                Console.WriteLine($"Result {result}");
            }
        }

        private static int MaxLevelSum(TreeNode root)
        {
            IList<int> sums = [];
            sums.Add(root.val);
            DFS(root.left, ref sums, 1);
            DFS(root.right, ref sums, 1);

            int max = sums[0];
            int level = 1;
            for (int i=0; i<sums.Count; i++)
            {
                int sum = sums[i];
                if (sum > max)
                {
                    max = sum;
                    level = i+1;
                }                
            }

            return level;
        }

        private static void DFS(TreeNode node, ref IList<int> sums, int index)
        {
            if (node == null) return;
            if (sums.Count > index)
            {
                sums[index] += node.val;
            }
            else
            {
                sums.Add(node.val);
            }

            DFS(node.left, ref sums, index + 1);
            DFS(node.right, ref sums, index + 1);
        }


        private static int MaxLevelSum1(TreeNode root)
        {
            TreeNode[] array = new TreeNode[10_000];
            array[0] = root;
            return BFS(ref array,0, 1, 1).level;
        }

        private static (int sum, int level) BFS(ref TreeNode[] nodes, int index, int nextIndex, int level)
        {
            int sum = 0;
            int currentIndex = nextIndex;
            for (int i = index; i < nextIndex; i++)
            {
                sum += nodes[i].val;
                if (nodes[i].left != null)
                {
                    nodes[currentIndex] = nodes[i].left;
                    currentIndex++;
                }
                if (nodes[i].right != null)
                {
                    nodes[currentIndex] = nodes[i].right;
                    currentIndex++;
                }
            }

            if (currentIndex == nextIndex) return (sum, level);

            (int nextLevelSum, int nexLevel) nextLevelResult = BFS(ref nodes, nextIndex, currentIndex, level + 1);

            return sum >= nextLevelResult.nextLevelSum ? (sum, level) : nextLevelResult;
        }
    }
}
