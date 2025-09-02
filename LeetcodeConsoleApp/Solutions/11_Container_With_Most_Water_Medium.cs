namespace LeetcodeConsoleApp.Solutions
{
    public class ContainerWithMostWater : ISolution
    {
        public void Run()
        {
            int[][] inputs = [
                [1, 8, 6, 2, 5, 4, 8, 3, 7],
                [42],
                [1, 1],
                [8, 7, 2, 1]
                ];
            foreach (var input in inputs)
            {
                var result = MaxArea(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int MaxArea(int[] height)
        {
            if (height.Length < 1) return 0;
            int minHeight;
            bool rightBigger;
            int currentSquare;
            int square = 0;
            for (int i = 0, j = height.Length - 1; i < j;)
            {
                rightBigger = height[i] < height[j];
                minHeight = rightBigger ? height[i] : height[j];
                currentSquare = minHeight * (j - i);
                if (currentSquare > square)
                {
                    square = currentSquare;
                }

                if (rightBigger)
                {
                    i++;
                }
                else
                {
                    j--;
                }

            }
            return square;
        }
    }
}
