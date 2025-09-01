namespace LeetcodeConsoleApp.Solutions
{
    public class IsSubsequenceSolution : ISolution
    {
        public void Run()
        {
            (string source, string target)[] inputs = [
                ("abc", "ahbgdc"), // true
                ("axc","ahbgdc"), // false
                ("acb","ahbgdc") // false
            ];

            foreach (var input in inputs)
            {
                bool result = IsSubsequence(input.source, input.target);
                Console.WriteLine($"Result {result}");
            }
        }

        private static bool IsSubsequence(string s, string t)
        {
            if (s.Length == 0) return true;
            if (t.Length == 0) return false;
            if (s == t) return true;

            for (int i = 0, j = 0; i < t.Length; i++)
            {
                if (t[i] == s[j])
                {
                    j++;
                    if (j == s.Length)
                        return true;
                }
            }

            return false;
        }
    }
}
