namespace LeetcodeConsoleApp.Solutions
{
    /// <summary>
    /// The approach with two while is the most efficient
    /// Visualization
    /// |||
    /// ||||||
    /// ||||||||
    ///    |||||
    ///    |||||||
    ///    |||||||||||
    ///        |||||||
    ///        |||||||||||
    ///        
    /// Algorithm:
    /// 
    /// while current index
    ///   expend
    ///     while from index
    ///       shrink
    /// </summary>
    public class MaxConsecutiveOnesIII : ISolution
    {
        public void Run()
        {
            (int[] nums, int k)[] inputs = [
                ([1,1, 0,0,0,0, 1,1, 0,0,0, 1,1,1, 0],2), //5
                ([1,1,  0,  1,1,  0,  1,1,  0,0,0,0,0,  1,1,1,  0],2), //8
                ([1,1,  0,  1,1,  0,  1,1,  0,0,0,0,  1,1,1,1,  0], 3), //9
                ([1,1,  0,  1,1,  0,  1,1,  0,0,0,  1,1,1,1,1,  0], 3), //10
                ([1,1,  0,  1,1,  0,0,  1,1,  0,0,0,  1,1,1,1,1,  0], 4), //11
                ([1,1,  0,  1,1,  0,0,  1,1,  0,0,0,  1,1,1,1,1], 4), //11
                ([1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], 2), // 6
                ([1,0,0,0,1,1,0,0,1,1,0,0,0,0,0,0,1,1,1,1,0,1,0,1,1,1,1,1,1,0,1,0,1,0,0,1,1,0,1,1], 8), // 25
                ([0, 0, 1, 1, 1, 0, 0],0), //3
                ([0, 0, 0,0, 0],0), // 0
                ([0, 0, 0,0, 0],3), // 3
                ([0,0,0,1], 4)//4
                ];
            foreach ((int[] nums, int k) in inputs)
            {
                int result = LongestOnes(nums, k);
                Console.WriteLine($"Result {result}");
            }
        }

        public int LongestOnes(int[] nums, int k)
        {
            int fromIndex = 0, currentIndex = 0, max = 0, zeroLeft = k;

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

            return max;
        }

        private static int LongestOnes2(int[] nums, int k)
        {
            Queue<int> streaks = [];
            int from = 0;
            while (from < nums.Length)
            {
                if (nums[from] == 1) break;
                from++;
            }

            int max = 0;
            int zeroLeft = k;
            int currentZeroStreakFirstIndex = 0;
            for (int i = from; i < nums.Length; i++)
            {
                int nextIndex = i + 1;

                // 11->0
                if (nums[i] == 1 && (nextIndex == nums.Length || nums[nextIndex] == 0))
                {
                    currentZeroStreakFirstIndex = nextIndex;
                    streaks.Enqueue(nextIndex);

                    int length = nextIndex - from;
                    length += zeroLeft;

                    if (length > max)
                    {
                        max = length;
                    }
                }

                //000->1
                if (nums[i] == 0 && (nextIndex == nums.Length || nums[nextIndex] == 1))
                {
                    int currentZeroStreak = nextIndex - currentZeroStreakFirstIndex;
                    if (currentZeroStreak > k)
                    {
                        zeroLeft = k;
                        from = nextIndex;
                    }
                    else
                    {
                        zeroLeft -= currentZeroStreak;
                        if (zeroLeft < 0)
                        {
                            while (zeroLeft < 0 && streaks.Count > 0)
                            {
                                int zeroStreakIndex = streaks.Dequeue();
                                int oneStreakIndex = streaks.Dequeue();
                                from = oneStreakIndex;
                                zeroLeft += oneStreakIndex - zeroStreakIndex;
                            }
                        }
                    }

                    streaks.Enqueue(nextIndex);
                }
            }

            max = max == 0 && nums.Length > 0 ? k : max;

            return max > nums.Length ? nums.Length : max;
        }

        private static int LongestOnes1(int[] nums, int k)
        {
            Queue<int> kIndeces = [];
            int max = 0, fromIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    if (kIndeces.Count != k)
                    {
                        kIndeces.Enqueue(i);
                    }
                    else if (kIndeces.Count > 0)
                    {
                        fromIndex = kIndeces.Dequeue() + 1;
                        kIndeces.Enqueue(i);
                    }
                    else
                    {
                        fromIndex = i + 1;
                    }
                }

                var length = i - fromIndex + 1;

                if (length > max)
                {
                    max = length;
                }
            }

            return max;
        }
    }
}
