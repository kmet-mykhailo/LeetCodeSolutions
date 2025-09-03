using System.Linq;

namespace LeetcodeConsoleApp.Solutions
{
    public class MaxNumberOfKSumPairs : ISolution
    {
        public void Run()
        {
            (int[] nums, int sum)[] inputs = [
                ([1, 2, 3, 4], 5 ),
                ([3, 1, 3, 4, 3], 6),
                ([1, 2, 3, 3, 5], 6)

                ];
            foreach (var input in inputs)
            {
                int result = MaxOperations(input.nums, input.sum);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int MaxOperations(int[] nums, int k)
        {
            if (k < 2 || nums.Length < 2) return 0;

            Dictionary<int, int> output = [];
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int currentValue = nums[i];

                if (currentValue >= k)
                {
                   continue;
                }

                if (output.TryGetValue(currentValue, out int value) && value > 0)
                {
                    output[currentValue] = --value;
                    count++;
                }
                else
                {
                    var revertedValue = k - currentValue;
                    if (output.ContainsKey(revertedValue))
                    {
                        output[revertedValue]++;
                    }
                    else
                    {
                        output.Add(revertedValue, 1);
                    }
                }
            }
            return count;
        }

        private static int MaxOperations2(int[] nums, int k)
        {
            int count = 0;

            Array.Sort(nums);
            int firstValue, lastValue, sum;
            for (int i = 0, j= nums.Length-1; i < j;)
            {
                firstValue = nums[i];
                lastValue = nums[j];
                sum = lastValue + firstValue;
                if(sum== k)
                {
                    count++;
                    i++;
                    j--;
                    continue;
                }

                if(sum< k)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }

            return count;
        }
    }
}
