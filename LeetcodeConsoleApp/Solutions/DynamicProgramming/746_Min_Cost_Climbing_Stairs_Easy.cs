namespace LeetcodeConsoleApp.Solutions.DynamicProgramming
{
    public class MinCostClimbingStairsSolution : ISolution
    {
        public void Run()
        {
            int[][] inputs = [[1, 100, 1, 1, 1, 100, 1, 1, 100, 1], [10, 15, 20]];
            foreach (int[] input in inputs)
            {
                int result = MinCostClimbingStairs(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int MinCostClimbingStairs(int[] cost)
        {
            int previous = cost[0];
            int current = cost[1];
            int next;

            for (int i = 2; i < cost.Length; i++)
            {
                next = (previous < current ? previous : current) + cost[i];
                previous = current;
                current = next;
            }

            return previous < current ? previous : current;
        }


    }
}
