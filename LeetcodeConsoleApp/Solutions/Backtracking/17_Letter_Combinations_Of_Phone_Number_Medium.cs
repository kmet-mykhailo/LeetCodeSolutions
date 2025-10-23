namespace LeetcodeConsoleApp.Solutions.Backtracking
{
    public class LetterCombinationsOfPhoneNumber : ISolution
    {

        private static readonly Dictionary<char, string> digitToCharacters = new() {
                { '2', "abc" },
                { '3', "def" },
                { '4', "ghi" },
                { '5', "jkl" },
                { '6', "mno" },
                { '7', "pqrs" },
                { '8', "tuv" },
                { '9', "wxyz" },
            };

        public void Run()
        {
            string[] inputs = ["79"];
            foreach (string input in inputs)
            {
                IList<string> result = LetterCombinations(input);
                Console.WriteLine($"Result  [{string.Join(", ", result)}]");
            }
        }

        private static IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            Backtrack(digits, "", result);

            return result;
        }

        static void Backtrack(string digits, string current, List<string> result)
        {
            if (current.Length == digits.Length)
            {
                result.Add(current);
                return;
            }

            foreach (char c in digitToCharacters[digits[current.Length]])
            {
                Backtrack(digits, current + c, result);
            }
        }
    }
}
