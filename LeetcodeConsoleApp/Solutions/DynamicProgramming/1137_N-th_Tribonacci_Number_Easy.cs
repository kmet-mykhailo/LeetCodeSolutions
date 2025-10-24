namespace LeetcodeConsoleApp.Solutions.DynamicProgramming
{
    public class NthTribonacciNumber : ISolution
    {
        public void Run()
        {
            int[] inputs = [25];
            foreach (var input in inputs)
            {
                int result = Tribonacci(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int Tribonacci(int n)
        {
            if (n == 0) return 0;
            if (n < 3) return 1;
            int sum = 1;
            int[] digits = new int[n + 1];
            digits[1] = 1;
            digits[2] = 1;

            for (int i = 3; i <= n; i++)
            {
                sum += digits[i - 1];
                digits[i] = sum;
                sum -= digits[i - 3];
            }

            return digits[n];
        }
    }
}
