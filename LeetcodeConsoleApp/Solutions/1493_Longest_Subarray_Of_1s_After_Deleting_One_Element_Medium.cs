namespace LeetcodeConsoleApp.Solutions
{
    public class LongestSubarrayOf1sAfterDeletingOneElement : ISolution
    {
        public void Run()
        {
            int[][] inputs = [
            [0, 1, 1, 1, 0, 1, 1, 0, 1],
            [1,1,1], 
            [1, 1, 0, 1],
            [1,1,0,1,0,0,1,0,1],
            [0,0,0], //0
            [0,0,1,1] // 2
            ];
            foreach (int[] input in inputs)
            {
                int result = LongestSubarray(input);
                Console.WriteLine($"Result {result}");
            }
        }


        private static int LongestSubarray(int[] nums)
        {
            int max = 0, zeroLeft = 1;

            for (int i = 0, fromIndex = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeroLeft--;
                }
                while (zeroLeft < 0)
                {
                    if (nums[fromIndex] == 0)
                    {
                        zeroLeft++;
                    }
                    fromIndex++;
                }
                int currentLength = i - fromIndex + 1;
                if (currentLength > max)
                {
                    max = currentLength;
                }
            }

            return max - 1;
        }

        private static int LongestSubarray1(int[] nums)
        {
            int fromIndex = 0, currentIndex = 0, max = 0, zeroLeft = 1;

            while (currentIndex < nums.Length)
            {
                if (nums[currentIndex] == 0)
                {
                    zeroLeft--;
                }
                while (zeroLeft < 0)
                {
                    if (nums[fromIndex] == 0)
                    {
                        zeroLeft++;
                    }
                    fromIndex++;
                }
                int currentLength = currentIndex - fromIndex + 1;
                if (currentLength > max)
                {
                    max = currentLength;
                }
                currentIndex++;
            }

            return max - 1;
        }
    }
}
