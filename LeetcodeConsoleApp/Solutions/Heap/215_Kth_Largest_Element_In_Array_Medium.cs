namespace LeetcodeConsoleApp.Solutions.Heap
{
    public class KthLargestElementInArray : ISolution
    {
        public void Run()
        {
            (int[] nums, int k)[] inputs = [ ([3, 2, 3, 1, 2, 4, 5, 5, 6], 4) ];
            foreach ((int[] nums, int k) in inputs)
            {
                int result = FindKthLargest(nums, k);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (priorityQueue.Count < k)
                {
                    priorityQueue.Enqueue(nums[i], -nums[i]);
                }

            }

            for (int i = 0; i < k - 1; i++)
            {
                priorityQueue.Dequeue();
            }

            return priorityQueue.Peek();
        }
    }
}
