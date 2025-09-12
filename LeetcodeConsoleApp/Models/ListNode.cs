namespace LeetcodeConsoleApp.Models
{
    public class ListNode(int value, ListNode? nextNode = null)
    {
        public readonly int val = value;
        public readonly ListNode? next = nextNode;

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
