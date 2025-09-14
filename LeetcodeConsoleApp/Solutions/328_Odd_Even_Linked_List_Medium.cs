using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions
{
    public class OddEvenLinkedList : ISolution
    {
        public void Run()
        {
            ListNode[] inputs = [
                new ListNode([1, 2, 3, 4, 5, 6, 7, 8, 9]),
                new ListNode([1, 2, 3, 4, 5, 6, 7, 8]),
            ];
            foreach (ListNode input in inputs)
            {
                Console.WriteLine($"Input {input}");
                ListNode result = OddEvenList(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode oddList = head;
            ListNode evenList = head.next;
            ListNode firstEvenNode = head.next;
            while (evenList?.next != null)
            {
                //Console.WriteLine($"Odd: {oddList.val}, even: {evenList?.val}");
                oddList.next = oddList.next.next;
                oddList = oddList.next;
                evenList.next = evenList.next.next;
                evenList = evenList.next;
            }
            oddList.next = firstEvenNode;

            return head;
        }
    }
}
