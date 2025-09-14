namespace LeetcodeConsoleApp.Models
{
    public class ListNode
    {
        public readonly int val;
        public ListNode? next;

        public ListNode(int value, ListNode? nextNode = null)
        {
            val = value;
            next = nextNode;
        }

        public ListNode(int[] array)
        {
            ListNode list = new(array[^1]);
            for (int i = array.Length - 2; i > 0; i--)
            {

                list = new(array[i], list);

            }
            next = list;
            val = array[0];
        }

        public override string ToString()
        {
            if (next == null)
            {
                return $"{val}";
            }

            return $"{val},{next}";
        }
    }
}
