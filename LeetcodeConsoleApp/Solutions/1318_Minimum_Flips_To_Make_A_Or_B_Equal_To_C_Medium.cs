using System.Collections;

namespace LeetcodeConsoleApp.Solutions
{
    public class MinimumFlipsToMakeAORBEqualToC : ISolution
    {
        public void Run()
        {
            (int a, int b, int c)[] inputs = [ (
                2, // 010
                6, // 110
                5  // 101
                ), // output - 3
            (4,2,7), // output -  1
            (1,2,3) // output -  0
            ];
            foreach ((int a, int b, int c) in inputs)
            {
                // TODO: Adjust input unpacking for multiple parameters
                int result = MinFlips(a,b,c);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int MinFlips(int a, int b, int c)
        {
            int d = a | b;
            int count = 0;
            for (int i = 0; i < 32; i++)
            {
                int bitD = ((d >> i) & 1);
                int bitC = ((c >> i) & 1);
                if (bitD != bitC)
                {
                    if (bitC == 1)
                    {
                        count++;
                    }
                    else
                    {

                        if (((a >> i) & 1) == 1)
                        {
                            count++;
                        }

                        if (((b >> i) & 1) == 1)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private static int MinFlips1(int a, int b, int c)
        {

            BitArray bitArrayA = new(BitConverter.GetBytes(a));
            BitArray bitArrayB= new(BitConverter.GetBytes(b));
            BitArray bitArrayC = new(BitConverter.GetBytes(c));
            BitArray bitArrayD = new(BitConverter.GetBytes(a|b));

            int count = 0;
            for(int i = 0;i<32;i++)
            {
                bool bitD = bitArrayD[i];
                bool bitC = bitArrayC[i];
                if(bitD != bitC)
                {
                    if (bitC)
                    {
                        count++;
                    }
                    else
                    {

                        if (bitArrayB[i])
                        {
                            count++;
                        }

                        if (bitArrayA[i])
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }
    }
}
