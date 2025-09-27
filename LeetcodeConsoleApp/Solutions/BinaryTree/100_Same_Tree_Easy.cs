using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions.BinaryTree
{
    public class SameTree : ISolution
    {
        public void Run()
        {
            (int?[] p, int?[] q)[] inputs = [
                ([1, 2, 3], [1, 2, 3]),
                ([1,2,1], [1,1,2])
                ];
            foreach ((int?[] p, int?[] q) in inputs)
            {
                bool result = IsSameTree(new TreeNode(p), new TreeNode(q));
                Console.WriteLine($"Result {result}");
            }
        }

        private static bool IsSameTree(TreeNode p, TreeNode q)
        {
            return (p == null && q == null)
                || (p!=null && q!=null && p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right));           
        }
    }
}
