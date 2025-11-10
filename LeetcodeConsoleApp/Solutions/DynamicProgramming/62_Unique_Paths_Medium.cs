namespace LeetcodeConsoleApp.Solutions.DynamicProgramming
{
    public class UniquePathsSolution : ISolution
    {
        public void Run()
        {
            (int m, int n)[] inputs = [(3, 7)];
            foreach ((int m, int n) in inputs)
            {
                int result = UniquePaths(m, n);
                Console.WriteLine(result);
            }
        }

        private static int UniquePaths(int m, int n)
        {
            if(n == 1 || m==1) return 1;
            if (n == 2) return m;
            if (m == 2) return n;

            int[] temp = new int[n];
            int previousValue = 1;

            for (int i = 0; i < n; i++)
            {
                temp[i] = i + 1;
            }

            for (int j = 2; j < m; j++)
            {
                for (int i = 1; i < n; i++)
                {
                    temp[i] = temp[i] + previousValue;
                    previousValue = temp[i];
                }
                previousValue = 1;
            }

            return temp[^1];
        }
    }
}
