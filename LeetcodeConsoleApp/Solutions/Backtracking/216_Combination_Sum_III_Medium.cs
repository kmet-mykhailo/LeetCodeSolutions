namespace LeetcodeConsoleApp.Solutions.Backtracking
{
    public class CombinationSumIII : ISolution
    {
                public void Run()
        {
            (int k, int n)[] inputs = [
                //(2,5),
                (3,7),
                (3,9),
                (2,18),
                ];
            foreach ((int k, int n) in inputs)
            {
                IList<IList<int>> result = CombinationSum(k,n);
                foreach (IList<int> resultArray in result)
                {
                    Console.WriteLine($"[{string.Join(",", resultArray)}]");
                }
            }
        }

        private static IList<IList<int>> CombinationSum(int k, int n)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Backtrack(k, n, 1, new List<int>(), 0, result);
            return result;
        }

        static void Backtrack(int k, int n, int index, List<int> current, int sum, IList<IList<int>> result)
        {
            //Console.WriteLine($"[{string.Join(",", current)}], sum = {sum}");
            if (current.Count == k && sum == n)
            {
                result.Add([.. current]);
                return;
            }
            
            for (int i = index; i < 10; i++)
            {
                if (sum > n) break;
                current.Add(i);
                Backtrack(k, n, i + 1, current, sum + i, result);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
