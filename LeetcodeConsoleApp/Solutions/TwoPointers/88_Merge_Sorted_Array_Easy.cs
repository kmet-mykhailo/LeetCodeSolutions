namespace LeetcodeConsoleApp.Solutions.TwoPointers;

public sealed class MergeSortedArray : ISolution
{
    public void Run()
    {
        (int[] nums1, int m, int[] nums2, int n)[] inputs =
        [
             ([1,2,3,0,0,0], 3, [2,5,6], 3),
             ([0], 0, [1],1),
             ([1], 1, [],0)
        ];
        
        foreach (var input in inputs)
        {
            Merge(input.nums1, input.m, input.nums2, input.n);
        }
    }

    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        for (int i = nums1.Length-1, index1 = m-1, index2 = n-1 ; index2 >= 0 ; i--)
        {
            nums1[i] = index1 >= 0 && nums1[index1] > nums2[index2]
                ? nums1[i] = nums1[index1--]
                : nums1[i] = nums2[index2--];
        }
        
        Console.WriteLine(string.Join(',', nums1));
    }

    public void MergeWithWhile(int[] nums1, int m, int[] nums2, int n)
    {
        int index1 = m-1;
        int index2 = n-1;
        int i = m + n - 1;

        while(index2 >= 0)
        {
            if(index1 >=0 && nums1[index1] > nums2[index2])
                nums1[i--] = nums1[index1--];
            else
                nums1[i--]= nums2[index2--];
        }
        Console.WriteLine(string.Join(',', nums1));
    }

    public void Merge1(int[] nums1, int m, int[] nums2, int n)
    {
        for (int i = nums1.Length-1, index1 = m-1, index2 = n-1 ; i >= 0 ; i--)
        {
            if (index2>=0 && (index1<0 || nums2[index2] >= nums1[index1]))
            {
                nums1[i] = nums2[index2];
                index2--;
                continue;
            }
            if(index1>=0 && (index2<0 || nums1[index1] >= nums2[index2]))
            {
                nums1[i] = nums1[index1];
                index1--;
            }
        }
        
        Console.WriteLine(string.Join(',', nums1));
    }
}