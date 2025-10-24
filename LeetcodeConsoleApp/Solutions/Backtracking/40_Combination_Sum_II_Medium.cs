namespace LeetcodeConsoleApp.Solutions.Backtracking
{
    public class CombinationSumII : ISolution
    {
        public void Run()
        {
            (int[] candidates, int target)[] inputs = [
                //([10, 1, 2, 7, 6, 1, 5], 8),
                ([2,5,2,1,2], 5)
                ];
            foreach ((int[] candidates, int target) in inputs)
            {
                IList<IList<int>> result = CombinationSum2(candidates, target);
                foreach (IList<int> resultArray in result)
                {
                    Console.WriteLine($"[{string.Join(",", resultArray)}]");
                }
            }
        }

        private static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> results = new List<IList<int>>();
            Array.Sort(candidates);
            Backtrack(candidates, 0, target, 0, [], results);
            return results;
        }

        private static void Backtrack(int[] candidates, int startIndex, int target, int currentSum, IList<int> current, IList<IList<int>> results)
        {
            if (currentSum == target)
            {
                results.Add(new List<int>(current));
                return;
            }

            if (currentSum > target) return;

            for (int i = startIndex; i < candidates.Length; i++)
            {
                if ((i > startIndex && candidates[i] == candidates[i - 1])) continue;

                if (currentSum + candidates[i] > target) break;

                current.Add(candidates[i]);
                Backtrack(candidates, i + 1, target, currentSum + candidates[i], current, results);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
