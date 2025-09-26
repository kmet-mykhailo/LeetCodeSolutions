using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions.BinaryTree
{
    public class LowestCommonAncestorOfABinaryTree : ISolution
    {
        public void Run()
        {
            (int?[], int, int)[] inputs = [
                ([3,5,1,6,2,0,8,null,null,7,4], 5, 1),
                ([3, 5, 1, 6, 2, 0, 8, null, null, 7, 4], 5, 4),
                ];
            foreach ((int?[] root, int p, int q) in inputs)
            {
                TreeNode result = LowestCommonAncestor(new TreeNode(root), new TreeNode(p),  new TreeNode(q));
                Console.WriteLine($"Result {result.val}");
            }
        }

        private static TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;

            if (root.val == p.val || root.val == q.val) return root;

            TreeNode? left = LowestCommonAncestor2(root.left, p, q);
            TreeNode? righ = LowestCommonAncestor2(root.right, p, q);

            if (left != null && righ != null) return root;
            if (left != null) return left;

            return righ;
        }

        private static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root.val == p.val || root.val == q.val) return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            return left != null && right != null ? root : left ?? right;
        }

        private static TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (HasNode1(root.left, p) && HasNode1(root.left, q))
            {
                return LowestCommonAncestor1(root.left, p, q);
            }

            if (HasNode1(root.right, p) && HasNode1(root.right, q))
            {
                return LowestCommonAncestor1(root.right, p, q);
            }

            return root;
        }

        private static bool HasNode1(TreeNode node, TreeNode searchedValue)
        {
            if (node == null) return false;
            if (node.val == searchedValue.val) return true;
            return HasNode1(node.left, searchedValue) || HasNode1(node.right, searchedValue);
        }
    }
}
