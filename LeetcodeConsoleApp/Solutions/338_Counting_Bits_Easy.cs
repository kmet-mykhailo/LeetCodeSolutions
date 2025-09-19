namespace LeetcodeConsoleApp.Solutions
{
    public class CountingBits : ISolution
    {
        public void Run()
        {
            int[] inputs = [
                15// '0,1,1,2,1,2,2,3,1,2,2,3,2,3,3,4'
                ];
            foreach (int input in inputs)
            {
                int[] result = CountBits(input);
                Console.WriteLine($"Result '{string.Join(',', result)}'");
            }
        }

        private static int[] CountBits(int n)
        {
            int[] results = new int[n + 1];
            results[0] = 0;
            bool isOdd = true;

            for (int i = 1; i <= n; i++)
            {
                results[i] = isOdd ? results[i - 1] + 1 : results[i / 2];
                isOdd = !isOdd;
            }

            return results;
        }

        private static int[] CountBits2(int n)
        {
            int[] results = new int[n + 1];
            results[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                int bitsCount = 1;
                int value = i;
                while (value != 1)
                {
                    if (value % 2 == 1)
                    {
                        bitsCount++;
                    }
                    else
                    {
                        bitsCount += results[value/2] -1;
                        break;
                    }

                    value /= 2;
                }

                results[i] = bitsCount;
            }

            return results;
        }

        private static int[] CountBits1(int n)
        {
            int[] result = new int[n+1];
            result[0] = 0;
            for (int i = 1; i < result.Length; i++)
            {
                int bitsCount = 1;
                int value = i;
                while (value != 1)
                {
                    if (value % 2 == 1)
                    {
                        bitsCount++;
                    }

                    value /= 2;
                }

                result[i] = bitsCount;
            }

            return result;
        }
    }
}
