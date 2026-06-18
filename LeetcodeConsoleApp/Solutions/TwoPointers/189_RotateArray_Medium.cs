namespace LeetcodeConsoleApp.Solutions.TwoPointers;

public class RotateArray : ISolution
{
    public void Run()
    {
        (int[] nums, int k)[] inputs = [
            //([1, 2, 3, 4, 5, 6, 7, 8, 9], 3), // should be [7, 8, 9, 1, 2, 3, 4, 5, 6]
            //([1, 2, 3, 4, 5, 6, 7, 8, 9], 4), // should be [6, 7, 8, 9 1, 2, 3, 4, 5]
            //([1, 2, 3, 4, 5, 6, 7, 8, 9], 6), // should be [4, 5, 6, 7, 8, 9, 1, 2, 3]
            //([1, 2, 3, 4, 5, 6, 7, 8, 9], 7) // should be [ 3, 4, 5, 6, 7, 8, 9, 1, 2,]
            //([1, 2, 3, 4, 5, 6, 7, 8, 9], 5), // should be [ 5, 6, 7, 8, 9, 1, 2, 3, 4]
            ([1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27], 38),
            //    [17,18,19,20,21,22,23,24,25,26,27, 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16]
            //([1,2,3,4,5,6,7], 3), // should be [5,6,7,1,2,3,4]
            //([-1,-100,3,99], 2), // should be [3,99,-1,-100]
            //([1, 2, 3, 4, 5, 6, 7], 2) // should be [6, 7, 1, 2, 3, 4, 5]
        ];
        foreach (var input in inputs)
        {
            Rotate(input.nums, input.k);
        }
    }
            
    public void Rotate(int[] nums, int k)
    {
        k %= nums.Length;
        Revert(nums, 0, nums.Length - 1);
        Revert(nums, 0, k - 1 );
        Revert(nums, k , nums.Length - 1);
        foreach (var num in nums)
        {
            Console.Write($"{num},");
        }
    }

    private static void Revert(int[] nums, int from, int to)
    {
        for (; from < to; from++, to--)
        {
            (nums[from], nums[to]) = (nums[to], nums[from]);
        }
    }
}
