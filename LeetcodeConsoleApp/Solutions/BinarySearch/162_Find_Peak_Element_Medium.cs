namespace LeetcodeConsoleApp.Solutions.BinarySearch
{
    public class FindPeakElementSolution : ISolution
    {
        public void Run()
        {
            int[][] inputs = [
                [1],
                [1, 2, 1, 3, 5, 6, 4], 
                [1, 2, 3, 1]
            ];
            foreach (var input in inputs)
            {
                int result = FindPeakElement(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int FindPeakElement(int[] nums)
        {
            return FindPeakElement(nums, 0, nums.Length - 1);
        }

        private static int FindPeakElement(int[] nums, int from, int to)
        {
            if (from == to) return from;

            int middle = from + (to - from + 1) / 2;
            if (nums[middle - 1] > nums[middle]) return FindPeakElement(nums, from, middle - 1);
            else return FindPeakElement(nums, middle, to);
        }
    }
}
