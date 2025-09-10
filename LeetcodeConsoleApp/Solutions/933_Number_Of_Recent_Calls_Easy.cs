namespace LeetcodeConsoleApp.Solutions
{
    public class NumberOfRecentCalls : ISolution
    {
        /// <summary>
        /// Both counters with array and with queue showed identical results on leetcode
        /// </summary>
        public void Run()
        {
            int[][] inputs = [
                [1, 100, 3001, 3002], // 1.2,3,3
                [1178,1483,1563,4054,4152] // 1,2,3,4,5
                ];

            foreach (var input in inputs)
            {

                Console.Write("Result ");
                RecentCounter counter = new();
                foreach (var value in input)
                {
                    int result = counter.Ping(value);
                    Console.Write($"{result} ");
                }

                Console.WriteLine();
            }
        }

        public class RecentCounterWithArray
        {
            private readonly int[] range = new int[10_000];
            private int leftIndex = 0;
            private int rightIndex = 0;

            public int Ping(int t)
            {
                range[rightIndex] = t;
                rightIndex++;
                int from = t - 3000;

                while (true)
                {
                    if (range[leftIndex] < from)
                    {
                        leftIndex++;
                    }
                    else
                    {
                        break;
                    }
                }

                return rightIndex - leftIndex;
            }
        }

        public class RecentCounter
        {
            private readonly Queue<int> queue = new(10_000);
            public RecentCounter()
            {

            }

            public int Ping(int t)
            {
                int from = t - 3000;
                queue.Enqueue(t);
                while (queue.Peek() < from)
                {
                    queue.Dequeue();
                }
                return queue.Count;
            }
        }
    }
}
