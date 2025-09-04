namespace LeetcodeConsoleApp.Solutions
{
    public class FindTheHighestAltitude : ISolution
    {
        public void Run()
        {
            int[][] inputs = [
                [-5, 1, 5, 0, -7], //1
                [-4,-3,-2,-1,4,3,2]// 0
            ];
            foreach (var input in inputs)
            {
                int result = LargestAltitude(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int LargestAltitude(int[] gain)
        {
            int currentAltitude = 0;
            int maxAltitude = 0;
            for (int i = 0; i < gain.Length; i++)
            { 
                currentAltitude = currentAltitude+ gain[i];

                if(currentAltitude > maxAltitude)
                {
                    maxAltitude = currentAltitude;
                }
            }
            return maxAltitude;
        }
    }
}
