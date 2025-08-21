namespace LeetcodeConsoleApp.Solutions.TasksNotFromLeetcode
{
    /// <summary>
    /// Task:
    /// Imagine you're trying to navigate a landscape represented by a **2D grid** (like a spreadsheet), where each square has a specific **height value** [1].
    ///
    /// Your goal is to figure out if it's possible to travel from a **starting point** (the top-left corner of the grid) to a **destination** (the bottom-right corner) [1].
    ///
    /// Here are the rules for moving:
    /// - You can only move to an **adjacent square** (up, down, left, or right – **no diagonal moves**) [1].
    /// - You have a special ability called "jump power" [1].
    /// - You can only move to a neighboring square if the **difference in height** between your current square and the next square is **less than or equal to your "jump power"** [1]. This applies whether you're going up or down.
    ///
    /// In other words:
    /// - The **2D matrix** is your "terrain height map" [1].
    /// - Finding a path is a **pathfinding problem** [2], similar to navigating a graph [2].
    /// - The question is: **Can a player reach the destination given the map and their jump power?** You need to implement a method `CanReach(map, jumpPower)` that returns a `bool` (true if possible, false if not) [1].
    /// </summary>
    public class PathfindingIn2dMatrix : ISolution
    {
        public void Run()
        {
            int jumpPower = 2;
            (int row, int column) initPosition = (0,0);
            (int row, int column) targetPosition = (2,3);

            int[,] map = {    
                {1, 2, 3, 4},
                {4, 5, 6, 4},
                {7, 8, 9, 4}
            };

            bool canReach = CanReach(map, initPosition, targetPosition, jumpPower);
            Console.WriteLine(canReach);
        }

        public static bool CanReach(int[,] map, (int row, int coulmn) initPosition, (int row, int column) targetPosition, int jumpPower)
        {
            if (map == null || map.GetLength(0) == 0 || map.GetLength(1) == 0)
            {
                return false; // Handle invalid map
            }

            int rowLength = map.GetLength(0);
            int columnLength = map.GetLength(1);

            // Check if the map is just a single cell
            if (rowLength == 1 && columnLength == 1)
            {
                return true;
            }

            // Keep track of visited cells to avoid cycles and redundant work
            bool[,] visited = new bool[rowLength, columnLength];

            // Use a queue for BFS
            Queue<(int, int)> queue = new();

            // Start at the top-left corner
            queue.Enqueue(initPosition);
            visited[0, 0] = true;

            while (queue.Any())
            {
                (int row, int column) = queue.Dequeue();
                int currentValue = map[row, column];
                Console.WriteLine($"Current {row}:{column}, value {currentValue}");

                // Check if we've reached the destination
                if (row == targetPosition.row && column == targetPosition.column)
                {
                    //Console.WriteLine(visited);
                    return true;
                }

                // Explore neighbors
                var fourPossibleDirections = new (int, int)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

                foreach ((int column, int row) direction in fourPossibleDirections)
                {
                    int nextRow = row + direction.row;
                    int nextColumn = column + direction.column;

                    bool isInBounds = nextRow >= 0 && nextRow < rowLength && nextColumn >= 0 && nextColumn < columnLength;
                    if (isInBounds && !visited[nextRow, nextColumn])
                    {
                        // Check if the height difference allows a jump
                        int nextValue = map[nextRow, nextColumn];
                        int heightDiff = Math.Abs(nextValue - currentValue);
                        if (heightDiff <= jumpPower)
                        {
                            visited[nextRow, nextColumn] = true;
                            (int row, int column) nextPosition = (nextRow, nextColumn);
                            queue.Enqueue(nextPosition);
                            Console.WriteLine($"Next {nextPosition.row}:{nextPosition.column}, value {nextValue}");
                            break;
                        }
                    }
                }
            }

            // If the queue becomes empty and we haven't reached the end,
            // it means the destination is unreachable.
            return false;
        }

    }
}
