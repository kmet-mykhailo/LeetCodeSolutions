namespace LeetcodeConsoleApp.Solutions.TwoPointers;

public class TwoSumInputArraySorted : ISolution {
    public void Run()
    {
        (int[] numbers, int target)[] inputs =
        [
            ([2,7,11,15], 9), // [1, 2]
            ([0,0,3,4], 0), //[1, 2]
            ([2,3,4], 6) //[1, 2]
        ];

        foreach ((int[] numbers, int target) in inputs)
        {
            var result = TwoSum(numbers, target);
            Console.WriteLine("[{0}]", string.Join(", ", result));
        }
    }
    
    public int[] TwoSum(int[] numbers, int target)
    {
        int leftIndex = 0, rightIndex = numbers.Length - 1;
        while (numbers[leftIndex] + numbers[rightIndex] != target)
        {
            if (numbers[rightIndex] + numbers[leftIndex] < target)
            {
                leftIndex++;
            }
            else
            {
                rightIndex--;
            }
        }
        return [leftIndex + 1, rightIndex + 1];
    }
}