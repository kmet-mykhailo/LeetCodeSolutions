using System.Linq;

namespace LeetcodeConsoleApp.Solutions
{
    public class FindTheDifferenceOfTwoArrays : ISolution
    {
        public void Run()
        {
            (int[] nums1, int[] nums2)[] inputs = [( [1, 2, 3], [2, 4, 6]),
                ([1, 2, 3, 3], [1, 1, 2, 2])
                ];
            foreach (var input in inputs)
            {
                // TODO: Adjust input unpacking for multiple parameters
                IList<IList<int>> result = FindDifference(input.nums1, input.nums2);
                Console.WriteLine($"Result1 [{string.Join(",", result[0])}]");
                Console.WriteLine($"Result2 [{string.Join(",", result[1])}]");
            }
        }

        private static IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            Dictionary<int, bool> diff1 = [];
            HashSet<int> diff2 = [];
            foreach (var input in nums1)
            {
                if (diff1.ContainsKey(input)) continue;

                diff1.Add(input, true);
            }

            foreach (var input in nums2)
            {
                if (diff1.ContainsKey(input))
                {
                    diff1[input]= false;
                }
                else {
                    diff2.Add(input);
                }
            }

            return [[.. diff1.Where(x=>x.Value).Select(x=>x.Key)], [.. diff2]];
        }
    }
}
