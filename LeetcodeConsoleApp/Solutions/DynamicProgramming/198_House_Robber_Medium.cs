namespace LeetcodeConsoleApp.Solutions.DynamicProgramming
{
    public class HouseRobber : ISolution
    {
        public void Run()
        {
            int[][] inputs = [
                [2, 7, 9, 3, 1],
                [1, 10, 1, 1, 22, 1]
                ];
            foreach (int[] input in inputs)
            {
                int result = Rob(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int Rob1(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return nums[0] > nums[1] ? nums[0] : nums[1];

            int sum1 = nums[0];
            int sum2 = nums[1];
            int current = nums[0] + nums[2];

            for (int i = 3; i < nums.Length; i++)
            {
                int temp = sum1 > sum2 ? sum1 + nums[i] : sum2 + nums[i];

                sum1 = sum2;
                sum2 = current;
                current = temp;
            }

            return current > sum2 ? current : sum2;
        }

        private static int Rob(int[] nums)
        {
            int max = nums[0];
            int previous = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                (max, previous) = (previous+ nums[i]> max ? previous + nums[i] : max, max);
            }

            return max;
        }
    }
}
