using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions
{
    public class MaximumTwinSumOfLinkedList : ISolution
    {
        public void Run()
        {
            ListNode[] inputs = [new ListNode([1, 3, 4, 5])];
            foreach (var input in inputs)
            {
                int result = PairSum(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int PairSum(ListNode head)
        {
            ListNode copy = head;
            ListNode twiceSpeedCopy = head;
            ListNode reversedFirstPart = null;
            while (twiceSpeedCopy != null)
            {
                twiceSpeedCopy = twiceSpeedCopy.next.next;
                ListNode temp = copy.next;
                copy.next = reversedFirstPart;
                reversedFirstPart = copy;
                copy = temp;
            }

            int biggestSum = 0;
            while (copy != null)
            {
                int sum = copy.val + reversedFirstPart.val;
                if (sum > biggestSum)
                {
                    biggestSum = sum;
                }
                copy = copy.next;
                reversedFirstPart = reversedFirstPart.next;
            }

            return biggestSum;
        }

        private static int PairSum1(ListNode head)
        {
            int[] array = new int[100_000];
            int index = 0;
            while (head != null)
            {
                array[index++] = head.val;
                head = head.next;
            }

            int biggestSum = 0;
            for (int i = 0, j = index - 1; i < j; i++, j--)
            {
                int sum = array[i] + array[j];
                if (sum > biggestSum)
                {
                    biggestSum = sum;
                }
            }

            return biggestSum;
        }

        private static int PairSum3(ListNode head)
        {
            int[] array = new int[100_000];
            ListNode twiceSpeedCopy = head;
            int index = 0;
            while (twiceSpeedCopy != null)
            {
                array[index++] = head.val;
                head = head.next;
                twiceSpeedCopy = twiceSpeedCopy.next.next;
            }

            int biggestSum = 0;
            for (int i = index - 1; i > -1; i--)
            {
                int sum = array[i] + head.val;
                if (sum > biggestSum)
                {
                    biggestSum = sum;
                }
                head = head.next;
            }

            return biggestSum;
        }

        private static int PairSum2(ListNode head)
        {
            ListNode copy = head;
            ListNode twiceSpeedCopy = head;
            Stack<int> reversedFirstPart = [];

            while (twiceSpeedCopy != null)
            {
                reversedFirstPart.Push(copy.val);
                copy = copy.next;
                twiceSpeedCopy = twiceSpeedCopy.next.next;
            }

            int biggestSum = 0;

            while (copy != null)
            {
                int sum = copy.val + reversedFirstPart.Pop();
                if (sum > biggestSum)
                {
                    biggestSum = sum;
                }

                copy = copy.next;
            }

            return biggestSum;
        }
    }
}
