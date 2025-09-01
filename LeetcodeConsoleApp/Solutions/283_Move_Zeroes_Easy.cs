namespace LeetcodeConsoleApp.Solutions
{
    public class MoveZeroesSolution : ISolution
    {
        public void Run()
        {
            int[][] inputs = [[0, 1, 2, 3], [42], [0]];
            foreach (var input in inputs)
            {
                MoveZeroes(input);
            }
        }

        private static void MoveZeroes(int[] nums)
        {
            int shift = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int currentValue = nums[i];
                if (currentValue == 0)
                {
                    shift++;
                    continue;
                }

                if (shift > 0)
                {
                    nums[i-shift] = currentValue;
                }
            }

            for (int i = nums.Length - shift ; i < nums.Length; i++) {
                nums[i] = 0;
            }
        }
    }
}
