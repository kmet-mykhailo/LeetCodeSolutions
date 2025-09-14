using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions
{
    public class DeleteTheMiddleNodeOfLinkedList : ISolution
    {
        public void Run()
        {            
            int[][] inputs = [
                [1, 3, 4, 7, 1, 2, 6],
                [1, 2, 3],
                [1, 2, 3, 4],
                [2, 1]
                ];
            foreach (var input in inputs)
            {
                ListNode linkedList = new(input);
                Console.WriteLine($"Input {linkedList}");

                ListNode result = DeleteMiddle(linkedList);
                Console.WriteLine($"Result {result}");
            }
        }

        private static ListNode DeleteMiddle(ListNode head)
        {
            if (head.next == null) return null;
            if (head.next.next == null)
            {
                head.next = null;
                return head;
            }

            ListNode firstList = head.next.next;
            ListNode secondList = head;
            int count = 0;
            while (true)
            {
                if (firstList == null ||firstList.next == null)
                {
                    break;
                }

                firstList = firstList.next.next;
                secondList = secondList.next;
                count++;
            }

            secondList.next = secondList.next.next;

            return head;
        }



        private static ListNode DeleteMiddleq(ListNode head)
        {
            ListNode list = head;
            int count = 0;
            while (true)
            {
                if (list == null)
                {
                    break;
                }
                list = list.next;
                count++;
            }

            if (count == 2)
            {
                head.next = null;
                return head;
            }

            if (count == 1) return null;

            int indexToRemove = count / 2;

            list = head;
            ListNode? nodeBefore = null;

            for (int i = 0; i <= indexToRemove +1 ; i++)
            {
                if (list == null)
                {
                    break;
                }

                if (i == indexToRemove - 1)
                {
                    nodeBefore = list;
                }

                if(i == indexToRemove + 1)
                {
                    nodeBefore.next = list;
                }

                list = list.next;
            }

            return head;
        }


        private static ListNode DeleteMiddle2(ListNode head)
        {
            ListNode list = head;
            ListNode[] array = new ListNode[100_000];
            array[0] = list;
            int count = 0;
            while (true)
            {
                if (list == null)
                {
                    break;
                }
                list = list.next;
                count++;
                array[count] = list;
            }

            if (count == 2)
            {
                head.next = null;
                return head;
            }

            if (count == 1) return null;

            int indexToRemove = count / 2;

            array[indexToRemove - 1].next = array[indexToRemove + 1];
            return head;
        }
    }
}
