namespace LeetcodeConsoleApp.Solutions
{
    internal class SingleNumber : ISolution
    {
        public void Run()
        {
            int[] nums1 = { 4, 1, 2, 1, 2 };
            int[] nums2 = {2, 2, 1};
            int[] nums3 = {1};
            int result1 = GetSingleNumber3(nums1);
            int result2 = GetSingleNumber3(nums2);
            int result3 = GetSingleNumber3(nums3);
            
            Console.WriteLine($"Result {result1}");
            Console.WriteLine($"Result {result2}");
            Console.WriteLine($"Result {result3}");

        }

        private static int GetSingleNumber(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];
                int lastIndex = Array.LastIndexOf(nums, nums[i]);
                if (i != lastIndex) continue;

                int firstIndex = Array.IndexOf(nums, nums[i]);
                if (i != firstIndex) continue;

                return nums[i];
            }

            return 0;
        }

        private static int GetSingleNumber2(int[] nums)
        {
            HashSet<int> set = [];
            for (int i = 0; i < nums.Length; i++)
            {
                if (set.Contains(nums[i]))
                {
                    set.Remove(nums[i]);
                }
                else
                {
                    set.Add(nums[i]);
                }
            }

            return set.Count > 0 ? set.First() : 0;
        }

        // a ^ a = 0
        // a ^ 0 = a
        // The expression x ^= y; is equivalent to x = x ^ y;
        private static int GetSingleNumber3(int[] nums)
        {
            int result=0;
            for (int i = 0; i < nums.Length; i++)
            {
                result ^= nums[i];
            }

            return result;
        }
    }
}
