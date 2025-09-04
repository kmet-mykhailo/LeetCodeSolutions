namespace LeetcodeConsoleApp.Solutions
{
    public class UniqueNumberOfOccurrences : ISolution
    {
        public void Run()
        {
            int[][] inputs = [[1, 2, 2, 1, 1, 3, 4,4,4,4], [1, 2]];
            foreach (var input in inputs)
            {
                bool result = UniqueOccurrences(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static bool UniqueOccurrences(int[] arr)
        {
            Dictionary<int, int> result = [];
            for (int i = 0; i < arr.Length; i++)
            {
                if (result.TryGetValue(arr[i], out int value))
                {
                    result[arr[i]] = ++value;
                }
                else
                {
                    result.Add(arr[i], 1);
                }
            }

            HashSet<int> unique = [];

            foreach (var item in result)
            {
                if (!unique.Add(item.Value)) return false;
            }

            return true;
        }
    }
}
