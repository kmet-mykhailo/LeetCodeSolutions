namespace LeetcodeConsoleApp.Solutions.Graphs
{
    public class KeysAndRooms : ISolution
    {
        public void Run()
        {
            int[][][] inputs = [
                [[1], [2], [3], []],
                [[1,3],[3,0,1],[2],[0]]
                ];
            foreach (int[][] input in inputs)
            {
                bool result = CanVisitAllRooms(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static bool CanVisitAllRooms1(IList<IList<int>> rooms)
        {
            HashSet<int> visited = [0];
            Queue<int> queue = new();
            queue.Enqueue(0);
            while (queue.Count > 0)
            {
                int roomNumber = queue.Dequeue();
                IList<int> keys = rooms[roomNumber];
                foreach (int key in keys)
                {
                    if (visited.Add(key))
                    {
                        queue.Enqueue(key);
                    }
                }
            }

            return visited.Count == rooms.Count;
        }

        private static bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            DFS(ref rooms, 0);
            foreach (IList<int> room in rooms)
            {
                if(room!=null) return false;
            }

            return true;
        }

        private static void DFS(ref IList<IList<int>> rooms, int key)
        {
            IList<int> keys = rooms[key];
            if (keys == null) return;

            rooms[key] = null;
            foreach (int roomKey in keys)
            {
                if (rooms[roomKey] != null)
                {
                    DFS(ref rooms, roomKey);
                }
            }
        }
    }
}
