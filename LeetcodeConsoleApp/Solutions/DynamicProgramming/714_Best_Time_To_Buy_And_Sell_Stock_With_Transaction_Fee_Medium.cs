namespace LeetcodeConsoleApp.Solutions.DynamicProgramming
{
    public class BestTimeToBuyAndSellStockWithTransactionFee : ISolution
    {
        public void Run()
        {
            (int[] prices, int fee)[] inputs = [ ([1, 3,2, 8, 4, 9], 2) ];
            foreach ((int[] prices, int fee) in inputs)
            {
                int result = MaxProfit(prices, fee);
                Console.WriteLine(result);
            }
        }

        private static int MaxProfit(int[] prices, int fee)
        {
            int minSpentMoney = prices[0];
            int maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                minSpentMoney = Math.Min(minSpentMoney, prices[i] - maxProfit);
                maxProfit = Math.Max(maxProfit, prices[i] - minSpentMoney - fee);
            }

            return maxProfit;
        }
    }
}
