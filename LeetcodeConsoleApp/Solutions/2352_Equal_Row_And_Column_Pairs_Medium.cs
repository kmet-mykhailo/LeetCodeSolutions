namespace LeetcodeConsoleApp.Solutions
{
    public class EqualRowAndColumnPairs : ISolution
    {
        public void Run()
        {
            List<int[][]> inputs = [
                [
                [3, 2, 1],
                [1, 7, 6],
                [2, 7, 7]
                ],
                [
                [3, 1, 2, 2],
                [1, 4, 4, 5],
                [2, 4, 2, 2],
                [2, 4, 2, 2]
                ],
                [
                [3,1,2,2],
                [1,4,4,4],
                [2,4,2,2],
                [2,5,2,2]
                ]
                ];

            foreach (var input in inputs)
            {
                var result = EqualPairs(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int EqualPairs1(int[][] grid)
        {
            int count = 0;

            bool?[][] temp = new bool?[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                int[] row = grid[i];

                for (int j = 0; j < row.Length; j++)
                {
                    int rowValue = row[j];

                    for (int k = 0; k < row.Length; k++)
                    {
                        int columnValue = grid[k][i];

                        if (temp[k] == null)
                        {
                            temp[k] = new bool?[row.Length];
                        }

                        if (temp[k][j] == null)
                        {
                            temp[k][j] = columnValue == rowValue;
                        }
                        else
                        {
                            temp[k][j] &= columnValue == rowValue;
                        }
                    }
                }
            }

            for (int i = 0; i < temp.Length; i++)
            {
                bool?[] row = temp[i];
                for (int j = 0; j < row.Length; j++)
                {
                    if (temp[i][j] == true) count++;
                }
            }

            return count;
        }

        private static int EqualPairs(int[][] grid)
        {
            int count = 0;

            int[] rowHashes = new int[grid.Length];
            int[][] columns = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                int[] row = grid[i];
                rowHashes[i] = GetArrayHashCode(row);

                for (int j = 0; j < row.Length; j++)
                {
                    if (columns[j] == null)
                    {
                        columns[j] = new int[grid.Length];
                    }
                    columns[j][i] = row[j];
                }
            }

            foreach (int[] column in columns)
            {
                int columnHash = GetArrayHashCode(column);
                foreach (int rowHash in rowHashes)
                {
                    if (rowHash == columnHash) count++;
                }
            }

            return count;
        }

        private static int EqualPairs3(int[][] grid)
        {
            int count = 0;
            Dictionary<string,int> rowHashes = [];
            Dictionary<string,int> columnHashes = [];
            for (int i = 0; i < grid.Length; i++)
            {
                int[] row = grid[i];
                var hash = string.Join(',', row);

                if (rowHashes.TryGetValue(hash, out int value))
                {
                    rowHashes[hash] = ++value;
                }
                else
                {
                    rowHashes.Add(hash, 1);
                }

                int[] column = new int[grid.Length];
                for (int j = 0; j < row.Length; j++)
                {
                    column[j] = grid[j][i];
                }

                string columnHash = string.Join(',', column);

                if (columnHashes.TryGetValue(columnHash, out int value2))
                {
                    columnHashes[columnHash] = ++value2;
                }
                else
                {
                    columnHashes.Add(columnHash, 1);
                }
            }

            foreach (string hash in rowHashes.Keys)
            {
                if (columnHashes.TryGetValue(hash, out int value2))
                {
                    count+= columnHashes[hash]* rowHashes[hash];
                }
            }

            return count;
        }

        public static int GetArrayHashCode(int[] numbers)
        {
            int hash = numbers.Length;
            foreach (int val in numbers)
            {
                hash = unchecked(hash * 314159 + val);
            }
            return hash;
        }
    }
}
