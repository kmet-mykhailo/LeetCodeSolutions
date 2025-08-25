using LeetcodeConsoleApp.Models;

namespace LeetcodeConsoleApp.Solutions
{
    public class MergeTwoSortedLists : ISolution
    {
        public void Run()
        {
            ListNode? list1 = new(1, new ListNode(2, new ListNode(4)));
            ListNode? list2 = new(1, new ListNode(3, new ListNode(4)));
            ListNode? mergedList = Merge(list1, list2);
            //DisplayResults(mergedList);
        }



        private static ListNode? Merge(ListNode? listNode1, ListNode? listNode2)
        {
            if (listNode1 == null && listNode2 == null)
            {
                return null;
            }

            if (listNode1 == null)
            {
                return listNode2;
            }

            if (listNode2 == null)
            {
                return listNode1;
            }

            int value;
            if (listNode1.value < listNode2.value)
            {
                value = listNode1.value;
                listNode1 = listNode1.nextNode;
            }
            else
            {
                value = listNode2.value;
                listNode2 = listNode2.nextNode;
            }
            return new ListNode(value, Merge(listNode1, listNode2));
        }
    }
}
