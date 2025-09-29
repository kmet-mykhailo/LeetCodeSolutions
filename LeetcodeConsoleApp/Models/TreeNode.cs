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

        /// [5, 2,3, 6,7,8,9, 1,4,11,22,45,67,88,99]
        /// [5, 2,n, 6,7,     1,4,11,22]
        /// [5, n,3,     n,9,                 88,99]
        public TreeNode(int?[] array)
        {
            val = array[0].Value;
            if (array.Length == 1) return;

            left = array[1].HasValue ? new TreeNode(array[1].Value) : null;
            right = array[2].HasValue? new TreeNode(array[2].Value): null;

            Queue<TreeNode> queue = new();
            if (left != null) { queue.Enqueue(left); }
            if (right != null) { queue.Enqueue(right); }

            for (int i = 4; i <= array.Length; i+=2)
            {
                TreeNode node = queue.Dequeue();
                int? value = array[i - 1];
                if (value.HasValue)
                {
                    node.left = new TreeNode(value.Value);
                    queue.Enqueue(node.left);
                }

                if (i == array.Length) return;

                value = array[i];
                if (value.HasValue)
                {
                    node.right = new TreeNode(value.Value);
                    queue.Enqueue(node.right);
                }
            }
        }


        public int?[] ToArray()
        {
            return [val, left?.val, right?.val];
        }

        public override string ToString()
        {
            return $"[ {string.Join(',', ToArray())} ]";
        }
    }
}
