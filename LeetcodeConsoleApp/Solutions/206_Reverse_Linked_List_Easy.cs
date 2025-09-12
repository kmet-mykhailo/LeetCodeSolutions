using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions
{
    public class ReverseLinkedList : ISolution
    {
        public void Run()
        {
            ListNode[] inputs = [
                new ListNode(1, new ListNode(2,new ListNode(3)))
                ];
            foreach (ListNode input in inputs)
            {
                Console.WriteLine($"Input {input}");
                ListNode? result = ReverseList(input);
                Console.WriteLine($"Output {result}");
            }
        }

        private static ListNode? ReverseList(ListNode head)
        {
            if (head == null) return null;

            ListNode previousNode = new(head.val);
            head = head.next;

            while (head != null)
            {
                previousNode = new ListNode(head.val, previousNode);               
                head = head.next;
            }

            return previousNode;
        }
    }
}
