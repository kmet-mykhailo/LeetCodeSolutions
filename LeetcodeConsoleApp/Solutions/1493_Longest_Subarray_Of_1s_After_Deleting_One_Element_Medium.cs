namespace LeetcodeConsoleApp.Solutions
{
    public class LongestSubarrayOf1sAfterDeletingOneElement : ISolution
    {
        public void Run()
        {
            int[][] inputs = [ [0, 1], [42] ];
            foreach (var input in inputs)
            {
                var result = LongestSubarray(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int LongestSubarray(int[] nums)
        {
            // TODO: Implement solution here
            return default(int);
        }
    }
}
