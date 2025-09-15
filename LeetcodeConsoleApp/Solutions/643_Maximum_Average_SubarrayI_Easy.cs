namespace LeetcodeConsoleApp.Solutions
{
    public class MaximumAverageSubarrayI : ISolution
    {
        public void Run()
        {
            (int[] nums, int k)[] inputs = [
                ([7], 1),
                ([2, 3, 5, 5, 4, -1, 1], 3)];
            foreach ((int[] nums, int k) in inputs)
            {
                double result = FindMaxAverage(nums, k);
                Console.WriteLine($"Result {result}");
            }
        }

        private static double FindMaxAverage(int[] nums, int k)
        {
            int sum = 0;
            for (int i = 0; i < k; i++) {
                sum += nums[i];
            }

            double biggestSum = sum;
            for (int i = k, j = 0; i < nums.Length; i++, j++)
            {
                sum = sum + nums[i] - nums[j];
                if (sum > biggestSum)
                {
                    biggestSum = sum;
                }
            }

            return biggestSum / k;
        }
    }
}
