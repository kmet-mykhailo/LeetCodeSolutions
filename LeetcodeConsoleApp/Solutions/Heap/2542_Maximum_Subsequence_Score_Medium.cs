namespace LeetcodeConsoleApp.Solutions.Heap
{
    public class MaximumSubsequenceScore : ISolution
    {
        public void Run()
        {
            (int[] nums1, int[] nums2, int k)[] inputs = [ 
                //([1, 3, 3, 2], [2, 1, 3, 4], 3),
                //([4,2,3,1,1], [7,5,10,9,6], 1),
                ([1,4], [3,1], 2),
                ];
            foreach ((int[] nums1, int[] nums2, int k) in inputs)
            {
                long result = MaxScore(nums1, nums2, k);
                Console.WriteLine($"Result {result}");

            }
        }

        private static long MaxScore(int[] nums1, int[] nums2, int k)
        {
            long max = 0;

            List<(int min, int num1Value)> match = [];
            for (int i = 0; i < nums1.Length; i++)
            {
                match.Add((nums2[i], nums1[i]));
            }

            match = match.OrderByDescending(x => x.min).ToList();

            PriorityQueue<int, int> priorityQueue = new();

            long sum = 0;
            foreach((int min, int num1Value) in match)
            {
                sum += num1Value;
                priorityQueue.Enqueue(num1Value, num1Value);

                if (priorityQueue.Count > k)
                {
                    sum -= priorityQueue.Dequeue();
                }

                if (priorityQueue.Count == k)
                {
                    max = min * sum > max ? min * sum : max;
                }
            }

            return max;
        }
    }
}
