namespace LeetcodeConsoleApp.Solutions.Heap
{
    public class SmallestInfiniteSet : ISolution
    {

        private readonly PriorityQueue<int, int> added = new();
        private int removed = 1;

        public SmallestInfiniteSet()
        {

        }

        public void Run()
        {
            //AddBack(2);
            //Console.WriteLine($"PopSmallest = {PopSmallest()}");
            //Console.WriteLine($"PopSmallest = {PopSmallest()}");
            //Console.WriteLine($"PopSmallest = {PopSmallest()}");
            //AddBack(1);
            //Console.WriteLine($"PopSmallest = {PopSmallest()}");
            //Console.WriteLine($"PopSmallest = {PopSmallest()}");
            //Console.WriteLine($"PopSmallest = {PopSmallest()}");

            Console.WriteLine($"PopSmallest = {PopSmallest()}");
            AddBack(1);
            AddBack(1);
            Console.WriteLine($"PopSmallest = {PopSmallest()}");
            AddBack(1);
            Console.WriteLine($"PopSmallest = {PopSmallest()}");
            Console.WriteLine($"PopSmallest = {PopSmallest()}");
            Console.WriteLine($"PopSmallest = {PopSmallest()}");
        }

        public int PopSmallest()
        {
            if (added.Count > 0)
            {
                int value = added.Dequeue();
                while (added.Count > 0 && added.Peek() == value)
                    added.Dequeue();
                return value;
            }
            else
            {
                removed++;
                return removed - 1;
            }
        }

        public void AddBack(int num)
        {
            if (num < removed)
            {
                added.Enqueue(num, num);
            }
        }
    }
}
