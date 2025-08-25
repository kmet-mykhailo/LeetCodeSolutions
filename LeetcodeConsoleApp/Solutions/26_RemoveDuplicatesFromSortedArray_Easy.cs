namespace LeetcodeConsoleApp.Solutions
{
    public class RemoveDuplicatesFromSortedArray : ISolution
    {

        public void Run()
        {
            var nums1 = new int[] { 1, 1, 2 };
            var nums2 = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            var inputs = new[] { nums1, nums2 };

            foreach (int[] input in inputs)
            {
                int amount = RemoveDuplicates(input);
                DisplayResults(amount, input);
            }
        }

        private static int RemoveDuplicates(int[] nums)
        {
            int resultIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    nums[resultIndex++] = nums[i];
                }
            }

            return resultIndex;
        }

        private static void DisplayResults(int amount, int[] array)
        {
            Console.WriteLine("[{0}] amount {1}", string.Join(", ", array), amount);
        }   

    }
}
