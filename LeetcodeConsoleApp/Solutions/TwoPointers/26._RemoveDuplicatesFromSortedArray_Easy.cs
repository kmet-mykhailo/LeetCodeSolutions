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
        var notDuplicatesIndex = 0;
        for(var i = 1; i < nums.Length; i++)
        {
            if (nums[notDuplicatesIndex] == nums[i]) continue;
            notDuplicatesIndex++;
            nums[notDuplicatesIndex] = nums[i];
        }

        return notDuplicatesIndex + 1;
    }
}