namespace LeetcodeConsoleApp.Solutions.BinarySearch
{
    public class KokoEatingBananas : ISolution
    {
        public void Run()
        {
            (int[] piles, int h)[] inputs = [
                ([3, 6, 7, 11], 8),
                ([1,1,1], 4),
                ([30,11,23,4,20], 5),
                ([30,11,23,4,20], 6),
                ([312884470], 312884469),
                ([805_306_368,805_306_368,805_306_368], 1000_000_000),
                ([831235932,437082868,576572631,529869153,55330371,511060323,581115062,931692072,600856556,519045509,504164418,431105822,580257183], 964065706)
            ];
            foreach ((int[] piles, int h) in inputs)
            {
                int result = MinEatingSpeed(piles, h);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int MinEatingSpeed(int[] piles, int h)
        {
            int max = 0;
            long amount = 0;
            foreach (int pile in piles)
            {
                max = max < pile ? pile : max;
                amount += pile;
            }

            if (piles.Length == h) return max;
            //if (h > max) return piles.Length;
            long from = amount % h == 0 ? amount / h : amount / h + 1;

            return MinEatingSpeed(piles, h, (int)from, max);
        }

        private static int MinEatingSpeed(int[] piles, int h, int from, int to)
        {
            if (from == to) return from;

            int middleSpeed = from + (to - from) / 2;
            int actualHours = 0;
            foreach (int pile in piles)
            {
                actualHours += pile % middleSpeed == 0 ? pile / middleSpeed : pile / middleSpeed + 1;
            }

            if (actualHours <= h)
                return MinEatingSpeed(piles, h, from, middleSpeed);
            else
                return MinEatingSpeed(piles, h, middleSpeed + 1, to);
        }
    }
}
