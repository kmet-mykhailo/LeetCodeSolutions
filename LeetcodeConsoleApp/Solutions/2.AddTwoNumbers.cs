using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions
{ 
    public class AddTwoNumbersSolution : ISolution
    {

        public void Run()
        {
            //243 + 567 = 708
            ListNode list1 = new(2, new ListNode(4, new ListNode(3)));
            ListNode list2 = new(5, new ListNode(6, new ListNode(4)));
            ListNode result1 = AddTwoNumbers(list1, list2);

            Console.WriteLine("Result: " + result1.ToString());

            ListNode list3 = new(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            ListNode list4 = new(9, new ListNode(9, new ListNode(9, new ListNode(9))));
            ListNode result2 = AddTwoNumbers(list3, list4);

            Console.WriteLine("Result: " + result2.ToString());

            ListNode list5 = new(9, new ListNode(9, new ListNode(1)));
            ListNode list6 = new(1);
            ListNode result3 = AddTwoNumbers(list5, list6);

            Console.WriteLine("Result: " + result3.ToString());
        }

        
        public ListNode AddTwoNumbers(ListNode listNode1, ListNode listNode2, bool addOne = false)
        {

            // todo: implement without recursion (with while loop)
            if (listNode1 == null && listNode2 == null)
            {
                return addOne? new ListNode(1): null;
            }

            int value1 = listNode1 != null ? listNode1.value : 0;
            int value2 = listNode2 != null ? listNode2.value : 0;
            int value = value1 + value2 + (addOne ? 1 : 0);

            if (value >= 10)
            {
                value -= 10;
                return new ListNode(value, AddTwoNumbers(listNode1?.nextNode, listNode2?.nextNode, true));
            }

            return new ListNode(value, AddTwoNumbers(listNode1?.nextNode, listNode2?.nextNode));
        }
    }
}
