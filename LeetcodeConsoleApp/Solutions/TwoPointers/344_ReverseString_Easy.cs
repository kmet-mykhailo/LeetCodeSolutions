namespace LeetcodeConsoleApp.Solutions.TwoPointers;

public class ReverseStringSolution : ISolution {
    public void Run()
    {
        char[][] inputs = [['h','e','l','l','o']];
        foreach (var input in inputs)
        {
            ReverseString(input);
        }
    }
    
    public void ReverseString(char[] s) {
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            (s[j], s[i]) = (s[i], s[j]);
        }
        Console.WriteLine(s);
    }
}