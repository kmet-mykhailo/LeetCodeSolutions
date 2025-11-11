namespace LeetcodeConsoleApp.Solutions.DynamicProgramming
{
    public class LongestCommonSubsequenceSolution : ISolution
    {
        public void Run()
        {
            (string text1, string text2)[] inputs = [ ("abcde", "acer") ];
            foreach ((string text1, string text2) in inputs)
            {
                int result = LongestCommonSubsequence( text1, text2);
                Console.WriteLine(result);
            }
        }

        private static int LongestCommonSubsequence(string text1, string text2)
        {
            int currentValue = 0;
            int[] previosRow = new int[text1.Length + 1];

            for (int row = 1; row <= text2.Length; row++)
            {
                currentValue = 0;
                for (int col = 1; col <= text1.Length; col++)
                {
                    int temp = currentValue;
                    if (text1[col - 1] == text2[row - 1])
                    {
                        currentValue = previosRow[col - 1] + 1;
                    }
                    else
                    {
                        currentValue = currentValue > previosRow[col] ? currentValue : previosRow[col];
                    }
                    previosRow[col - 1] = temp;
                }
                previosRow[^1] = currentValue;
            }

            return currentValue;
        }
    }
}
