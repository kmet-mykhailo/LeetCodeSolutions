namespace LeetcodeConsoleApp.Solutions
{
    public class IncreasingTripletSubsequence : ISolution
    {
        public void Run()
        {
            var nums1 = new int[] { 1, 2, 3, 4, 5 }; // true
            var nums2 = new int[] { 0, 5, 4, 6, 2 }; // true
            var nums3 = new int[] { 2, 1, 5, 0, 4, 6 }; // true
            var nums4 = new int[] { 20, 100, 10, 12, 5, 13 }; // true
            var nums5 = new int[] { 1, 5, 2, 3}; // true
            var nums6 = new int[] { 4, 5, 2, 3, 4}; // true
            var nums7 = new int[] { 4, 5, 2, 3, 1}; // false
            var inputs = new[] {
                nums1,
                nums2,
                nums3,
                nums4,
                nums5,
                nums6,
                nums7
            };

            foreach (int[] input in inputs)
            {
                bool result = GetIncreasingTriplet(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static bool GetIncreasingTriplet(int[] nums)
        {
            int first = nums[0];
            int second = Int32.MaxValue;
            for (int i = 1; i < nums.Length; i++)
            {
                int currentValue = nums[i];
                if (currentValue < first)
                {
                    first = currentValue;
                    continue;
                }

                if (currentValue < second && currentValue > first)
                {
                    second = currentValue;
                }

                if (first < second && second < currentValue) return true;
            }

            return false;
        }
    }
}
