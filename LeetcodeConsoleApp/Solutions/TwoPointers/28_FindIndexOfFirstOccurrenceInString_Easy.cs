namespace LeetcodeConsoleApp.Solutions.TwoPointers;

public class FindIndexOfFirstOccurrenceInString: ISolution {

    public void Run()
    {
        (string haystack, string needle)[] inputs =
        [
            ("a","a"),
            ("mississippi", "issip"),
            ("mississippi", "pi"),
            ("leetcode", "tc"),
            ("sadbutsad","sad")
        ];

        foreach (var input in inputs)
        {
            var result = StrStr(input.haystack, input.needle);
            Console.WriteLine($"result is {result}");
        }
    }
    
    public int StrStr(string haystack, string needle)
    {
        if (haystack.Length < needle.Length) return -1;
        for (int i = 0,j = 0; i < haystack.Length; i++)
        {
            if (haystack[i] != needle[j])
            {
                if (j != 0)
                {
                    i -= j;
                }
                j = 0;
                continue;
            }

            j++;

            if (j == needle.Length)
            {
                return i-(needle.Length-1);
            }
        }

        return -1;
    }
}
