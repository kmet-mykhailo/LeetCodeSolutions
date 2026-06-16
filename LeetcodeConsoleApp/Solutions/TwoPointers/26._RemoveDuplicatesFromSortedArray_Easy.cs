namespace LeetcodeConsoleApp.Solutions.TwoPointers;

public class RemoveDuplicatesFromSortedArray : ISolution {
    public void Run()
    {
        int[][] inputs = [[1,1,2], [0,0,1,1,1,2,2,3,3,4]];

        foreach (var input in inputs)
        {
            var result = RemoveDuplicates(input);
            Console.WriteLine($"result: {result}");
        }
        
    }
    
    public int RemoveDuplicates(int[] nums) {
        int i1 = 0;
        for(int i2 = 1; i2< nums.Length; i2++)
        {
            if(nums[i1]!=nums[i2])
            {
                i1++;
                nums[i1] = nums[i2];
            }
        }

        return i1 + 1;
    }
}