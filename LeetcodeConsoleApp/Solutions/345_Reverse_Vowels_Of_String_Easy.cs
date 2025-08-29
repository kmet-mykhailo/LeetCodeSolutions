namespace LeetcodeConsoleApp.Solutions
{
    public class ReverseVowelsOfString : ISolution
    {
        public void Run()
        {
            string[] inputs = ["", "leetcode", "ISolution"];
            foreach (string input in inputs)
            {
                string result = GetReverseVowels(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static string GetReverseVowels(string s)
        {
            char[] allVowels = ['a', 'e', 'i', 'o', 'u'];
            Stack<char> foundVowels = [];

            foreach (char letter in s)
            {
                if (allVowels.Contains(Char.ToLower(letter)))
                {
                    foundVowels.Push(letter);
                }
            }

            char[] result = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                result[i] = allVowels.Contains(Char.ToLower(s[i])) ? foundVowels.Pop() : s[i];
            }

            return new string(result);
        }
    }
}
