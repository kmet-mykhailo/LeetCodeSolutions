using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions.BinaryTree
{
    public class PathSumII : ISolution
    {
        public void Run()
        {
            (int?[], int)[] inputs = [
                ([5,   4,8,  11,null,13,4,  7,2,null,null,null,null,5,1], 22),
                //([1,2,3],22)
                ];
            foreach ((int?[] array, int targetSum) in inputs)
            {
                IList<IList<int>> result = PathSum(new TreeNode(array), targetSum);
                foreach (IList<int> list in result)
                {
                    Console.WriteLine($"Result [{string.Join(',', list)}]");
                }
            }
        }

        private static IList<IList<int>> PathSumInternal1(TreeNode root, int targetSum, int index)
        {
            if (root == null) return null;

            targetSum -= root.val;

            if (root.left == null && root.right == null)
            {
                if (targetSum == 0)
                {
                    int[] list = new int[index+1];
                    list[^1] = root.val;
                    return [list];
                }
                return null;
            }

            IList<IList<int>> leftBranch = PathSumInternal1(root.left, targetSum, index+1);
            IList<IList<int>> rightBranch = PathSumInternal1(root.right, targetSum, index + 1);

            if (leftBranch == null && rightBranch == null) return null;

            IList<IList<int>> result = [];

            if(leftBranch != null)
            {
                foreach (int[] item in leftBranch)
                {
                    item[index] = root.val;
                    result.Add(item);
                }
            }

            if (rightBranch != null)
            {
                foreach (int[] item in rightBranch)
                {
                    item[index] = root.val;
                    result.Add(item);
                }
            }

            return result;
        }

        private static IList<IList<int>> PathSum1(TreeNode root, int targetSum)
        {
            var result = PathSumInternal1(root, targetSum, 0);
            return result ?? [];
        }

        private static IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            IList<IList<int>> result = [];
            if (root != null)
            {
                PathSumInternal(root, targetSum, [], result);
            }
            return result;
        }

        private static void PathSumInternal(TreeNode root, int targetSum, IList<int> currentList, IList<IList<int>> allLists)
        {
            currentList.Add(root.val);
            targetSum -= root.val;

            if (root.left == null && root.right == null && targetSum == 0)
            {
                allLists.Add(new List<int>(currentList));
                return;
            }

            if (root.left != null)
            {
                PathSumInternal(root.left, targetSum, currentList, allLists);
                currentList.RemoveAt(currentList.Count - 1);
            }

            if (root.right != null)
            {
                PathSumInternal(root.right, targetSum, currentList, allLists);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }
    }
}
