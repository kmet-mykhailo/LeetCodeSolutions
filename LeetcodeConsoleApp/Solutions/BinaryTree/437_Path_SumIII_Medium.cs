using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions.BinaryTree
{
    public class PathSumIII : ISolution
    {
        public void Run()
        {
            (int?[], int)[] inputs = [
                //([10, 5, -3, 3, 2, null, 11, 3, -2, null, 1], 8),
                //([5, 4,8, 11,null,13,4, 7,2,null,null,null, null,5, 1], 22),
                //([1], 0),
                //([-2,null,-3],-2),
                //([-2,null,-3], -3),
                //([0,1,1],0),
                //([1000000000, 1000000000,null, 294967296,null, 1000000000,null, 1000000000,null, 1000000000],0),
                //([5,  null,3,  /*6,7,*/8,9,  /*1,4,11,22,*/45,67,88,99],0),
                ([10,5,-3,3,2,null,11,3,-2,null,1],8),
                ([5,   4,8,  11,null,13,4,   7,2,null,null,5,1], 22)
                ];
            foreach (var input in inputs)
            {
                //TreeNode temp = new TreeNode(input.Item1);
                int result = PathSum(new TreeNode(input.Item1), input.Item2);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int PathSum1(TreeNode root, int targetSum)
        {
            int count = 0;
            if (root != null)
            {
                PathSumInternal1(root, targetSum, [], ref count);
            }
            return count;
        }

        private static void PathSumInternal1(TreeNode root, long currentSum, IList<int> branch, ref int count)
        {
            currentSum -= root.val;
            if (currentSum == 0)
            {
                count++;
            }

            long temp = currentSum;
            int index = 0;
            while (index < branch.Count)
            {
                temp += branch[index];

                if (temp == 0)
                {
                    count++;
                }
                index++;
            }


            branch.Add(root.val);

            if (root.left != null)
            {
                PathSumInternal1(root.left, currentSum, branch, ref count);
                branch.RemoveAt(branch.Count - 1);
            }

            if (root.right != null)
            {
                PathSumInternal1(root.right, currentSum, branch, ref count);
                branch.RemoveAt(branch.Count - 1);
            }
        }

        private static int PathSum(TreeNode root, int targetSum)
        {
            if (root == null) return 0;

            return PathSumInternal(root, targetSum) + PathSum(root.left, targetSum) + PathSum(root.right, targetSum);
        }

        private static int PathSumInternal(TreeNode root, long targetSum)
        {
            int count = targetSum == root.val ? 1 : 0;
            if (root.left != null) count += PathSumInternal(root.left, targetSum - root.val);
            if (root.right != null) count += PathSumInternal(root.right, targetSum - root.val);
            return count;
        }
    }
}
