using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions.BinaryTree
{
    public class BinaryTreeRightSideView : ISolution
    {
        public void Run()
        {
            int?[][] inputs = [[1, 2, 3, 4, null, null, null, 5]];
            foreach (var input in inputs)
            {
                IList<int> result = RightSideView(new TreeNode(input));
                Console.WriteLine($"Result [{string.Join(',', result)}]");
            }
        }

        private static IList<int> RightSideView(TreeNode root)
        {
            if (root == null) return [];
            IList<int> result = new List<int>(100)
            {
                root.val
            };

            DFS(root.right, result, 1);
            DFS(root.left, result, 1);

            return result;
        }

        private static void DFS(TreeNode node, IList<int> result, int index)
        {
            if (node == null) return;
            if (result.Count <= index)
            {
                result.Add(node.val);
            }

            index++;
            DFS(node.right, result, index);
            DFS(node.left, result, index);
        }

        private static IList<int> RightSideView1(TreeNode root)
        {
            if (root == null) return [];
            IList<int> result = new List<int>(100)
            {
                root.val
            };

            IEnumerable<TreeNode> levelNodes = GetNextLevelNodes([root]);
            while (levelNodes.Any())
            {
                result.Add(levelNodes.First().val);
                levelNodes = GetNextLevelNodes(levelNodes);
            }
            return result;
        }

        private static IList<TreeNode> GetNextLevelNodes1(IList<TreeNode> nodes)
        {
            IList<TreeNode> list = [];
            foreach (TreeNode node in nodes)
            {
                if (node.right != null) list.Add(node.right);
                if (node.left != null) list.Add(node.left);
            }
            return list;
        }

        private static IEnumerable<TreeNode> GetNextLevelNodes(IEnumerable<TreeNode> nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.right != null) yield return node.right;
                if (node.left != null) yield return node.left;
            }
        }
    }
}
