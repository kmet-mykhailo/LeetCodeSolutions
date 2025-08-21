namespace LeetcodeConsoleApp.Models
{
    public class ListNode(int value, ListNode? nextNode = null)
    {
        public readonly int value = value;
        public readonly ListNode? nextNode = nextNode;

        public override string ToString()
        {
            if (nextNode == null)
            {
                return $"{value}";
            }

            return $"{value},{nextNode.ToString()}";
        }
    }
}
