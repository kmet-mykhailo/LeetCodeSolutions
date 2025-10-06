namespace LeetcodeConsoleApp.Solutions.Graphs
{
    public class ReorderRoutesToMakeAllPathsLeadToTheCityZero : ISolution
    {
        public void Run()
        {
            (int n, int[][] connections)[] inputs = [
                (6, [[0, 1], [1, 3], [2, 3], [4, 0], [4, 5]]),
                (5, [[1,0],[1,2],[3,2],[3,4]]),
                (6, [[4,5],[0,1],[1,3],[2,3],[4,0]])
            ];
            foreach ((int n, int[][] connections) in inputs)
            {
                int result = MinReorder(n, connections);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int Dfs(int start,
            Dictionary<int, List<(int city, bool isForward)>> cities,
            int count)
        {
            List<(int city, bool isForward)> neighbours = cities[start];
            if (neighbours == null) return 0;
            cities[start] = null;
            foreach ((int city, bool isForward) in neighbours)
            {
                if (cities[city] == null) continue;

                if (!isForward)
                {
                    count++;
                }
                count = Dfs(city, cities, count);
            }
            return count;
        }

        private static int MinReorder(int n, int[][] connections)
        {           
            Dictionary<int, List<(int city, bool isForward)>> cities = [];
            foreach (int[] conn in connections)
            {
                int fromCity = conn[1];
                int toCity = conn[0];
                if (cities.TryGetValue(fromCity, out List<(int city, bool isForward)>? valueFrom))
                {
                    valueFrom.Add((toCity, true));
                }
                else
                {
                    cities.Add(fromCity, [(toCity, true)]);
                }

                if (cities.TryGetValue(toCity, out List<(int city, bool isForward)>? valueTo))
                {
                    valueTo.Add((fromCity, false));
                }
                else
                {
                    cities.Add(toCity, [(fromCity, false)]);
                }
            }

            return Dfs(0, cities,0);
        }

    }
}
