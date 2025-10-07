namespace LeetcodeConsoleApp.Solutions.Graphs
{
    public class EvaluateDivision : ISolution
    {
        public void Run()
        {
            (IList<IList<string>> equations, double[] values, IList<IList<string>> queries)[] inputs =
                [
                    ([["a", "b"], ["b", "c"]], [2.0, 3.0], 
                    [["a", "c"], ["b", "a"], ["a", "e"], ["a", "a"], ["x", "x"]]),
                ];
            foreach ((IList<IList<string>> equations, double[] values, IList<IList<string>> queries) in inputs)
            {
                double[] result = CalcEquation(equations, values, queries);
                Console.WriteLine($"Result [{string.Join(", ", result)}]");
            }
        }

        private static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            Dictionary<string, Dictionary<string, double>> lookup = [];

            for (int i = 0; i< equations.Count; i++)
            {
                string dividend = equations[i][0];
                string divisor = equations[i][1];

                if (!lookup.ContainsKey(dividend)) lookup[dividend] = [];
                lookup[dividend][divisor] = values[i];


                if (!lookup.ContainsKey(divisor)) lookup[divisor] = [];
                lookup[divisor][dividend] = 1/ values[i];
            }

            double[] result = new double[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                result[i] = Dfs(queries[i][0], queries[i][1], lookup, []);
            }

            return result;
        }

        private static double Dfs(string x, string y, Dictionary<string, Dictionary<string, double>> lookup, HashSet<string> visited)
        {
            if (lookup.ContainsKey(x) == false || visited.Add(x) ==false ) return -1;
            if (x == y) return 1;

            foreach (var item in lookup[x])
            {
                double value = Dfs(item.Key, y, lookup, visited);
                if (value != -1) return item.Value * value;
            }

            return -1;
        }
    }
}
