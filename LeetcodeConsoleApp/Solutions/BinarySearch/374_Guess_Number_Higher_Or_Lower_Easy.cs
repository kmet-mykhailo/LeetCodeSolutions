namespace LeetcodeConsoleApp.Solutions.BinarySearch
{
    public class GuessNumberHigherOrLower : ISolution
    {
        private static int pick = 2; 
        public void Run()
        {
            int[] inputs = [ 2 ];
            foreach (var input in inputs)
            {
                var result = GuessNumber(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int GuessNumber(int n)
        {
            return GuessNumber(1, n);
        }

        private static int GuessNumber(int from, int to)
        {
            if (to - from == 1) return guess(from) == 0 ? from : to;
            int half = from + (to - from) / 2;
            int result = guess(half);
            if (result == -1) return GuessNumber(from, half);
            if (result == 1) return GuessNumber(half, to);
            return half;
        }

        private static int guess(int n)
        {
            if (n > pick) return -1;
            if(n < pick) return 1;
            return 0;
        }
    }
}
