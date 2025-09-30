using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions.BinarySearchTree
{
    public class DeleteNodeInBST : ISolution
    {
        public void Run()
        {
            (int?[] root, int key)[] inputs = [
                ([5, 3, 6, 2, 4, null, 7], 3),
            ([50,30,70,null,40,60,80], 50),
            ([2,1,3,null,null,null,5,4,6], 3),
            ([2,1],2),
            ([20,10,50,null,15,40,null,12,null,null,45], 20)
            ];
            foreach ((int?[] root, int key) in inputs)
            {
                TreeNode result = DeleteNode(new TreeNode(root), key);
                Console.WriteLine(result);
            }
        }

        private static TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val == key)
            {
                if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }
                else // find min from right subtree
                {
                    TreeNode temp = root.right;
                    while(temp.left != null)
                    {
                        temp = temp.left;
                    }
                    root.val = temp.val;
                    root.right = DeleteNode(root.right, temp.val);
                }                
            }

            if( root.val > key)
            {
                root.left = DeleteNode(root.left, key);
            }
            else
            {
                root.right = DeleteNode(root.right, key);
            }

            return root;
        }

        private static void FindAndReplace( ref TreeNode root, int key)
        {
            if (root == null) return;
            if(root.val == key)
            {
                if (root.left == null && root.right == null)
                {
                    root = null;
                }
                else if (root.right != null && root.right.left == null)
                {
                    TreeNode temp = root.left;
                    root = root.right;
                    root.left = temp;
                }
                else if (root.right == null && root.left != null)
                {
                    root = root.left;
                }
                else if (root.right != null)
                {
                    root.val = FindMinLeaf(ref root.right, ref root);
                }

                return;
            }

            if(root.val>key) FindAndReplace(ref root.left, key);
            else FindAndReplace(ref root.right, key);
        }

        private static int FindMinLeaf(ref TreeNode node, ref TreeNode parentNode)
        {
            if (node.left == null)
            {
                int value = node.val;
                if (node.right != null)
                {
                    parentNode.left = node.right;
                }
                else
                {
                    node = null;
                }

                return value;
            }
            else
            {
                return FindMinLeaf(ref node.left, ref node);
            }
        }
    }
}
