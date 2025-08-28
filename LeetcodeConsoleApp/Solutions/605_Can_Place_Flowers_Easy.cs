namespace LeetcodeConsoleApp.Solutions
{
    public class CanPlaceFlowers : ISolution
    {
        public void Run()
        {
            (int[] flowerbed, int newFlowersLength)[] inputs = [
                ([1],0), // true
                ([0],1), // true
                ([1, 0, 1, 0, 0, 0, 0, 1], 2), // false
                ([1, 0, 0, 0, 0, 1], 2), // false
                ([1, 0, 0, 0, 0, 0, 1], 2), // true
                ([0, 0, 0, 0, 1, 1], 2), // true
                ([1, 1, 0, 0, 0, 0], 2)// true
                ];

            foreach ((int[] flowerbed, int newFlowersLength) in inputs)
            {
                bool result = GetCanPlaceFlowers(flowerbed, newFlowersLength);
                Console.WriteLine($"Result {result}");
            }
        }

        public bool GetCanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n == 0) return true;
            if (n == 1 && flowerbed.Length == 1 && flowerbed[0] == 0) return true;

            for (int i = 0, inRow = 1; i < flowerbed.Length; i++, inRow++)
            {
                if (flowerbed[i] == 1)
                {
                    inRow = 0;
                    continue;
                }

                if (inRow == 3)
                {
                    inRow = 1;
                    n--;
                }

                if (inRow == 2 && (i == 1 || i == flowerbed.Length - 1))
                {
                    inRow = 1;
                    n--;
                }

                if (n == 0) return true;
            }
            return false;
        }
    }
}
