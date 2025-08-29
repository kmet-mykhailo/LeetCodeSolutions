namespace LeetcodeConsoleApp.Solutions
{
    public class ProductOfArrayExceptSelf : ISolution
    {
        public void Run()
        {
            int[][] inputs = [
                [1,2,3,4],
                [ 2, 4, 3, 5 ],
                [ 1, 1, 0, -3, 3 ]
            ];
            foreach (int[] input in inputs)
            {
                int[] result = GetProductExceptSelf(input);
                Console.WriteLine($"Result '{string.Join(',', result)}'");
            }
        }

        // input:           2        4      3       5
        // forward compute: 2        8      24      120
        // back compute:    120      60     15      5
        // computation:     back[-1] 15*2   8*5     forward[-1]
        // output:          60       30     40      24
        public int[] GetProductExceptSelf(int[] nums)
        {
            int[] forward = new int[nums.Length - 1];
            int[] back = new int[nums.Length - 1];
            int forwardTemp = 1;
            int backTemp = 1;

            for (int i = 0, j = back.Length - 1; i < forward.Length; i++, j--)
            {
                backTemp = backTemp * nums[j + 1];
                back[j] = backTemp;
                forwardTemp = forwardTemp * nums[i];
                forward[i] = forwardTemp;
            }

            nums[0] = back[0];
            nums[nums.Length - 1] = forward[forward.Length - 1];

            for (int i = 1; i < forward.Length; i++)
            {
                nums[i] = forward[i-1] * back[i];
            }

            return nums;
        }
    }
}
