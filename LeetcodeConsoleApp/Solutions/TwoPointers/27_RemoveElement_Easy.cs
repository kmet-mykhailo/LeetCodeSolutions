namespace LeetcodeConsoleApp.Solutions.TwoPointers;

public class RemoveElementSolution: ISolution
{
    public void Run()
    {
        (int[] nums, int val)[] inputs = [
            // ([4, 5, 6, 3, 4], 3),
            // ([3, 3, 4, 5, 6], 3),
            //([3,2,2,3], 3),
            ([0,1,2,2,3,0,4,2], 2)
        ];

        foreach (var input in inputs)
        {
            var result = RemoveElement(input.nums, input.val);
            Console.WriteLine($"result: {result}");
        }
    }
    
    public int RemoveElement(int[] nums, int val)
    {
        var notValueIndex = 0;
        foreach (var number in nums)
        {
            if (number == val) continue;
            nums[notValueIndex] = number;
            notValueIndex++;
        }

        foreach (var num in nums)
        {
            Console.Write(num);
        }
        
        Console.WriteLine();

        return notValueIndex;
    }
}