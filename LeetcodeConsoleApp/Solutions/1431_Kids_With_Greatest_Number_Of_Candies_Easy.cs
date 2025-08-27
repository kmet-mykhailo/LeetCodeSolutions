namespace LeetcodeConsoleApp.Solutions
{
    public class KidsWithGreatestNumberOfCandies : ISolution
    {
        public void Run()
        {
            int[] candies1 = [2, 3, 5, 1, 3];
            int extraCandies1 = 3;
            int[] candies2 = [4, 2, 1, 1, 2];
            int extraCandies2 = 1;

            IList<bool> result1 = GetKidsWithCandies(candies1, extraCandies1);
            IList<bool> result2 = GetKidsWithCandies(candies2, extraCandies2);
            Console.WriteLine($"Result [{string.Join(",", result1)}]");
            Console.WriteLine($"Result [{string.Join(",", result2)}]");
        }

        public IList<bool> GetKidsWithCandies(int[] candies, int extraCandies)
        {
            int maxValue = 0;
            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] > maxValue)
                {
                    maxValue = candies[i];
                }
            }

            bool[] result = new bool[candies.Length];

            for (int i = 0; i < candies.Length; i++)
            {
                result[i] = candies[i] + extraCandies >= maxValue;
            }

            return result;
        }
    }
}
