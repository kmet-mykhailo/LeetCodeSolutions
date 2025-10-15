
namespace LeetcodeConsoleApp.Solutions.Heap
{
    public class TotalCostToHireKWorkers : ISolution
    {
        public void Run()
        {
            (int[] costs, int k, int candidates)[] inputs = [
                //([17, 12, 10, 2, 7, 2, 11, 20, 8], 3, 4),
                //([31,25,72,79,74,65,84,91,18,59,27,9,81,33,17,58], 11, 2),
                ([17,12,2,200,8], 1, 3),
                ([18,64,12,21,21,78,36,58,88,58,99,26,92,91,53,10,24,25,20,92,73,63,51,65,87,6,17,32,14,42,46,65,43,9,75], 13, 23),
                ];
            foreach ((int[] costs, int k, int candidates) in inputs)
            {
                long result = TotalCost(costs, k, candidates);
                Console.WriteLine($"Result {result}");
            }
        }

        private static long TotalCost(int[] costs, int k, int candidates)
        {
            long sum = 0;            

            if (candidates * 2 >= costs.Length)
            {
                PriorityQueue<int, (int, int)> priorityQueue = new();
                for (int i = 0; i < costs.Length; i++)
                {
                    priorityQueue.Enqueue(costs[i], (costs[i], i));
                }

                for (int i = 0; i < k; i++)
                {
                    sum += priorityQueue.Dequeue();
                }
            }
            else
            {
                PriorityQueue<(int, int), (int, int)> priorityQueue = new();
                int leftIndex = 0, rightIndex = costs.Length - 1;
                for (; leftIndex < candidates; leftIndex++, rightIndex--)
                {
                    priorityQueue.Enqueue((costs[leftIndex], leftIndex), (costs[leftIndex], leftIndex));
                    if (leftIndex != rightIndex)
                    {
                        priorityQueue.Enqueue((costs[rightIndex], rightIndex), (costs[rightIndex], rightIndex));
                    }
                }

                bool indexesNotOverlapped = leftIndex <= rightIndex;
                for (int i = 0; i < k; i++)
                {
                    (int value, int index) = priorityQueue.Dequeue();
                    sum += value;
                    if (indexesNotOverlapped)
                    {
                        if (index < leftIndex)
                        {
                            priorityQueue.Enqueue((costs[leftIndex], leftIndex), (costs[leftIndex], leftIndex));
                            leftIndex++;
                        }
                        else
                        {
                            priorityQueue.Enqueue((costs[rightIndex], rightIndex), (costs[rightIndex], rightIndex));
                            rightIndex--;
                        }

                        indexesNotOverlapped= leftIndex <= rightIndex;
                    }
                }
            }

            return sum;
        }
    }
}
