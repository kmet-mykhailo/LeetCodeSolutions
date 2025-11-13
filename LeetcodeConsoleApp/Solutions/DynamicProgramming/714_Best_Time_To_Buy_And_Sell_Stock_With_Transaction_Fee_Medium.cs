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

        private static int MaxProfit2(int[] prices, int fee)
        {
            int profit = 0;
            int spentMoney = -prices[0];
            Console.WriteLine($"SpentMoney:{spentMoney}");
            Console.WriteLine($"Profit:{profit}");

            for (int i = 0; i < prices.Length; i++)
            {
                spentMoney = Math.Max(spentMoney, profit - prices[i]);
                Console.WriteLine($"SpentMoney:{spentMoney}");
                profit = Math.Max(profit, spentMoney + prices[i] - fee);
                Console.WriteLine($"Profit:{profit}");
            }
            return profit;
        }

        private static int MaxProfit1(int[] prices, int fee)
        {
            int result = 0;
            int[][] temp = new int[prices.Length -1][];
            int[] maxValues = new int[prices.Length - 1];
            for (int i = 0; i < prices.Length-1; i++)
            {
                temp[i] = new int[prices.Length - 1 - i];
                for (int j = 0; j < prices.Length - 1 - i; j++)
                {
                    temp[i][j] = prices[j+i+1] - prices[i];
                    if(temp[i][j] > maxValues[i])
                    {
                        maxValues[i] = temp[i][j];
                    }
                }
            }

            return default;
        }
    }
}
