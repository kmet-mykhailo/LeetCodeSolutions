namespace LeetcodeConsoleApp.Solutions.Backtracking
{
    public class CombinationSumSolution : ISolution
    {
        public void Run()
        {
            (int[] candidates, int target)[] inputs = [ ([2, 3, 6, 7], 7)];
            foreach ((int[] candidates, int target) in inputs)
            {
                IList<IList<int>> result = CombinationSum(candidates, target);
                foreach (IList<int> resultArray in result)
                {
                    Console.WriteLine($"[{string.Join(",", resultArray)}]");
                }
            }
        }

        private static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = [];
            Backtrack(candidates, 0, target, [], 0, result);
            return result;
        }

        static void Backtrack(int[] candidates, int startIndex, int target, List<int> current, int sum, IList<IList<int>> result)
        {
            if (sum > target || candidates.Length == startIndex) return;
            if (sum == target)
            {
                result.Add([.. current]);
                return;
            }

            current.Add(candidates[startIndex]);
            Backtrack(candidates, startIndex, target, current, sum + candidates[startIndex], result);
            current.RemoveAt(current.Count - 1);
            Backtrack(candidates, startIndex + 1, target, current, sum, result);
        }
    }
}
