namespace LeetcodeConsoleApp.Solutions.TwoPointers;

public class RemoveDuplicatesFromSortedArray2 : ISolution {
    public void Run()
    {
        int[][] inputs = [
            [1,1,2,2],
            [0,0,1,1,1,1,2,3,3]
        ];
        foreach (var input in inputs)
        {
            var result = RemoveDuplicates(input);
            Console.WriteLine($"result: {result}");
        }
    }
    
    public int RemoveDuplicates(int[] nums)
    {
        if(nums.Length < 3) return nums.Length;
        
        var firstIndex = 1;
        for (var i = 2; i < nums.Length; i++)
        {
            if (nums[firstIndex] != nums[i] || nums[firstIndex - 1] != nums[firstIndex])
            {
                firstIndex ++;
                nums[firstIndex] = nums[i];
            }
        }
        
        return firstIndex + 1;
    }
}