namespace LeetcodeConsoleApp.Solutions.Graphs
{
    public class NumberOfProvinces : ISolution
    {
        public void Run()
        {
            int[][][] inputs = [
                [
                    [1,1,0],
                    [1,1,0],
                    [0,0,1]
                ],
                [
                     [1,0,0,0],
                     [0,1,0,0],
                     [0,0,1,0],
                     [0,0,0,1],
                 ],
                [
                  // 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5
                    [1,1,0,0,0,0,0,1,0,0,0,0,0,0,0],// 1 | 2,  8
                    [1,1,0,0,0,0,0,0,0,0,0,0,0,0,0],// 2 | 1
                    [0,0,1,0,0,0,0,0,0,0,0,0,0,0,0],// 3 |
                    [0,0,0,1,0,1,1,0,0,0,0,0,0,0,0],// 4 | 6,  7
                    [0,0,0,0,1,0,0,0,0,1,1,0,0,0,0],// 5 | 10, 11
                    [0,0,0,1,0,1,0,0,0,0,1,0,0,0,0],// 6 | 4,  11
                    [0,0,0,1,0,0,1,0,1,0,0,0,0,1,0],// 7 | 7,  9,  14
                    [1,0,0,0,0,0,0,1,1,0,0,0,0,0,0],// 8 | 1,  9
                    [0,0,0,0,0,0,1,1,1,0,0,0,0,1,0],// 9 | 7,  8,  14
                    [0,0,0,0,1,0,0,0,0,1,0,1,0,0,1],// 0 | 5,  12, 15
                    [0,0,0,0,1,1,0,0,0,0,1,1,0,0,0],// 1 | 5,  6,  12
                    [0,0,0,0,0,0,0,0,0,1,1,1,0,0,0],// 2 | 10, 11
                    [0,0,0,0,0,0,0,0,0,0,0,0,1,0,0],// 3 | 
                    [0,0,0,0,0,0,1,0,1,0,0,0,0,1,0],// 4 | 7,  9
                    [0,0,0,0,0,0,0,0,0,1,0,0,0,0,1] // 5 | 10
                 ],

                ];
            foreach (int[][] input in inputs)
            {
                int result = FindCircleNum(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int FindCircleNum(int[][] isConnected)
        {
            int numberOfProvinces = 0;
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (isConnected[i] != null)
                {
                    numberOfProvinces++;
                    DFS(isConnected, i);
                }
            }

            return numberOfProvinces;
        }

        private static void DFS(int[][] isConnected, int rowIndex)
        {
            int[] currentRow = isConnected[rowIndex];
            isConnected[rowIndex] = null;
            for (int columnIndex = 0; columnIndex < isConnected.Length; columnIndex++)
            {
                if (rowIndex != columnIndex && currentRow[columnIndex] == 1 && isConnected[columnIndex] != null)
                {
                    DFS(isConnected, columnIndex);
                }
            }
        }

        private static int FindCircleNum2(int[][] isConnected)
        {
            int numberOfProvinces = 0;
            bool[] visited = new bool[isConnected.Length];

            for (int i = 0; i < isConnected.Length; i++)
            {
                if (visited[i]== false)
                {
                    numberOfProvinces++;
                    DFS2(isConnected, i, visited);
                }
            }

            return numberOfProvinces;
        }

        private static void DFS2(int[][] isConnected, int rowIndex, bool[] visited)
        {
            visited[rowIndex] = true;
            for (int columnIndex = 0; columnIndex < isConnected.Length; columnIndex++)
            {
                if (rowIndex != columnIndex && isConnected[rowIndex][columnIndex] == 1 && visited[columnIndex]==false)
                {
                    DFS2(isConnected, columnIndex, visited);
                }
            }
        }

        private static int FindCircleNum1(int[][] isConnected)
        {
            int numberOfProvinces = 0;
            HashSet<int> visited = [];

            for (int i = 0; i < isConnected.Length; i++)
            {
                if (visited.Add(i))
                {
                    numberOfProvinces++;
                    DFS1(isConnected, i, ref visited);
                }
            }

            return numberOfProvinces;
        }

        private static void DFS1(int[][] isConnected, int rowIndex, ref HashSet<int> visited)
        {
            for (int columnIndex = 0; columnIndex < isConnected.Length; columnIndex++)
            {
                if (rowIndex!= columnIndex && isConnected[rowIndex][columnIndex] == 1 && visited.Add(columnIndex))
                {
                    DFS1(isConnected, columnIndex, ref visited);
                }
            }
        }
    }
}
