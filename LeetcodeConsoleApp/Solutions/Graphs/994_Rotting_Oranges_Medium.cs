
namespace LeetcodeConsoleApp.Solutions.Graphs
{
    public class RottingOranges : ISolution
    {
        public void Run()
        {
            int[][][] inputs = [
                [[2, 1, 1], [1, 1, 0], [0, 1, 1]],
                [[2,1,1],[0,1,1],[1,0,1]],
                [[0,2]],
            [[0,1]]
            ];
            foreach (var input in inputs)
            {
                int result = OrangesRotting(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int OrangesRotting(int[][] grid)
        {
            List<(int row, int column)> rottenCells = [];
            int freshCount = 0;

            for (int row = 0; row < grid.Length; row++)
            {
                for(int column = 0; column< grid[row].Length; column++ )
                {
                    if (grid[row][column] == 2)
                    {
                        rottenCells.Add((row, column));
                    }
                    else if( grid[row][column] == 1)
                    {
                        freshCount++;
                    }
                }
            }

            int count = 0;
            while (rottenCells.Count > 0 && freshCount>0)
            {
                count++;
                List<(int row, int column)> nextRottenCells = [];
                foreach ((int row, int column) in rottenCells)
                {
                    (int row, int column)[] nextCells = [(row + 1, column), (row, column + 1), (row - 1, column), (row, column - 1)];
                    foreach ((int row, int column) cell in nextCells)
                    {
                        if (cell.row>=0 && cell.column>=0 &&
                            cell.row< grid.Length && cell.column< grid[0].Length &&
                            grid[cell.row][cell.column] == 1)
                        {
                            grid[cell.row][cell.column] = 2;
                            nextRottenCells.Add((cell.row, cell.column));
                            freshCount--;
                        }
                    }
                }

                rottenCells = nextRottenCells;
            }

            return freshCount > 0 ? -1 : count;
        }

        private static int OrangesRotting1(int[][] grid)
        {
            List<(int row, int column)> rottenCells = [];
            HashSet<(int, int)> freshOranges = [];

            for (int row = 0; row < grid.Length; row++)
            {
                for (int column = 0; column < grid[row].Length; column++)
                {
                    if (grid[row][column] == 2)
                    {
                        rottenCells.Add((row, column));
                    }
                    else if (grid[row][column] == 1)
                    {
                        freshOranges.Add((row, column));
                    }
                }
            }

            if (freshOranges.Count == 0) return 0;

            int count = 0;
            while (rottenCells.Count > 0)
            {
                count++;
                List<(int row, int column)> nextRottenCells = [];
                foreach ((int row, int column) in rottenCells)
                {
                    (int row, int column)[] nextCells = [(row + 1, column), (row, column + 1), (row - 1, column), (row, column - 1)];
                    foreach ((int row, int column) cell in nextCells)
                    {
                        if (freshOranges.Remove((cell.row, cell.column)))
                        {
                            grid[cell.row][cell.column] = 2;
                            nextRottenCells.Add((cell.row, cell.column));
                        }
                    }
                }

                rottenCells = nextRottenCells;
            }

            return freshOranges.Count > 0 ? -1 : count - 1;
        }
    }
}
