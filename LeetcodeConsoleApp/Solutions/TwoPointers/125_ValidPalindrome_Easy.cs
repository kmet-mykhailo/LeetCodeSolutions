namespace LeetcodeConsoleApp.Solutions.TwoPointers;

public class ValidPalindrome: ISolution {
    public void Run()
    {
        string[] inputs = [
            //"A man, a plan, a canal: Panama",
            "0P"
        ];
        foreach (var input in inputs)
        {
            bool result = IsPalindrome(input);
            Console.WriteLine(result);
        }
    }
    
    public bool IsPalindrome(string s)
    {
        int index1 = 0;
        int index2 = s.Length - 1;

        while (index1 < index2)
        {
            if (!char.IsLetterOrDigit(s[index1]))
            {
                index1++;
                continue;
            }

            if (!char.IsLetterOrDigit(s[index2]))
            {
                index2--;
                continue;   
            }

            if (char.ToUpperInvariant(s[index1]) != char.ToUpperInvariant(s[index2]))
            {
                return false;
            }
            
            index1++;
            index2--;
        }
        
        return index1 == index2;
    }
}