namespace LeetcodeConsoleApp.Solutions
{
    public class FindPivotIndex : ISolution
    {
        public void Run()
        {
            int[][] inputs = [
                [0],
                [0, 0],
                [1, 7, 3, 6, 5, 6],
                [1,1,1,1,1,1,20,3,3],
                [1,1,1,1,20,2,2],
                [42],
                [2, 1, -1],
                [2, -1, 1],
                [2, -3, 3],
                [-1, 1, 2],
                [1, -1, 2],
                [-3, 3, -3, 3, 1],
            ];
            foreach (var input in inputs)
            {
                int result = PivotIndex(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int PivotIndex1(int[] nums)
        {
            int leftSum = 0;
            int rightSum = nums.Sum(x => x);

            for (int i = 0; i < nums.Length; i++)
            {
                rightSum -= nums[i];

                if (leftSum == rightSum)
                {
                    return i;
                }

                leftSum += nums[i];
            }

            return -1;
        }

        private static int PivotIndex3(int[] nums)
        {
            int[] sum = new int[nums.Length];

            int min = nums.Length;
            for (int i = 0, j = nums.Length - 1, sumLeft = 0, sumRight = 0; i < nums.Length; i++, j--)
            {
                sumLeft += nums[i];
                sum[i] += sumLeft;

                sumRight += nums[j];
                sum[j] -= sumRight;

                if (i >= j)
                {
                    if (sum[j] == 0 && j < min) min = j;
                    if (sum[i] == 0 && i < min) min = i;
                }
            }

            return min == nums.Length ? -1 : min;
        }

        private static int PivotIndex(int[] nums)
        {
            int leftSum = 0;
            int totalSum = 0;

            foreach (int num in nums)
            {
                totalSum += num;
            }

            for (int i = 0; i < nums.Length; i++)
            {

                if (leftSum == (totalSum - leftSum - nums[i]))
                {
                    return i;
                }

                leftSum += nums[i];
            }

            return -1;
        }

        private static int PivotIndex2(int[] nums)
        {
            int[] sumFromLeftToRight = new int[nums.Length + 1];

            sumFromLeftToRight[0] = 0;
            for (int i = 0, sum = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                sumFromLeftToRight[i + 1] = sum;
            }

            int lastSum = sumFromLeftToRight[sumFromLeftToRight.Length - 1];
            for (int i = 0, leftSum = 0; i < nums.Length; i++)
            {
                leftSum = sumFromLeftToRight[i];
                int rightSum = lastSum - sumFromLeftToRight[i + 1];

                if (leftSum == rightSum)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
