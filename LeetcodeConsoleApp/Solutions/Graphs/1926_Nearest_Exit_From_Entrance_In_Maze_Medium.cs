namespace LeetcodeConsoleApp.Solutions.Graphs
{
    public class NearestExitFromEntranceInMaze : ISolution
    {
        public void Run()
        {
            (char[][] maze, int[] entrance)[] inputs = [
                ([['+', '+', '.', '+'], ['.', '.', '.', '+'], ['+', '+', '+', '.']], [1, 2]),
                ([['+','+','+'],['.','.','.'],['+','+','+']], [1,0]),
                ([
                    ['+','.','+','+','+','+','+'],
                    ['+','.','+','.','.','.','+'],
                    ['+','.','+','.','+','.','+'],
                    ['+','.','.','.','+','.','+'],
                    ['+','+','+','+','+','.','+']
                    ], [0,1]),
                    ([['.', '.']], [0,1])
            ];
            foreach ((char[][] maze, int[] entrance) in inputs)
            {
                int result = NearestExit(maze, entrance);
                Console.WriteLine($"Result {result}");

            }
        }

        private static int NearestExit(char[][] maze, int[] entrance)
        {
            int[][] directions = [[-1, 0], [1, 0], [0, -1], [0, 1]];
            maze[entrance[0]][entrance[1]] = '+';

            (int row, int column)[] queue = new (int row, int column)[maze.Length * maze[0].Length];
            queue[0] = (entrance[0], entrance[1]);
            int queueEndIndex = 1;
            int queueIndex = 0;

            int count = 1;
            while (queueIndex < queueEndIndex)
            {
                int currentNextIndex = queueEndIndex;
                for (; queueIndex < currentNextIndex; queueIndex++)
                {
                    foreach (int[] direction in directions)
                    {
                        int row = queue[queueIndex].row + direction[0];
                        int column = queue[queueIndex].column + direction[1];

                        if (row >= 0 && column >= 0 && row < maze.Length && column < maze[0].Length && maze[row][column] == '.')
                        {
                            if (row == 0 || column == 0 || row == maze.Length - 1 || column == maze[0].Length - 1) return count;

                            queue[queueEndIndex] = (row, column);
                            queueEndIndex++;
                            maze[row][column] = '+';
                        }
                    }
                }
                count++;
            }

            return -1;
        }
    }
}
