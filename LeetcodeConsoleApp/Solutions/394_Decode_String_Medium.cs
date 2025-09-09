namespace LeetcodeConsoleApp.Solutions
{
    public class DecodeStringSolution : ISolution
    {
        public void Run()
        {
            string[] inputs = [
                "qwerty15[a]3[b]",
                "3[a]2[bc]",
                "2[abc]3[cd]ef",
                "qwerty3[a2[bb]]",
                "100[misha]",
                "2[2[y]a2[b]]",
                "3[z]2[2[y]pq4[2[jk]e1[f]]]ef", // zzzyypqjkjkefjkjkefjkjkefjkjkefyypqjkjkefjkjkefjkjkefjkjkefef
                "3[a10[bc]]"
                ];
            foreach (var input in inputs)
            {
                string result = DecodeString(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static string DecodeString(string s)
        {
            List<char> result = [];
            int digits = 0;
            Stack<(int multiplier, List<char> range)> stack = [];

            for (int i = 0; i < s.Length; i++)
            {
                char currentCharacter = s[i];

                if (char.IsLetter(currentCharacter))
                {
                    if (stack.Count > 0)
                    {
                        (_, List<char> range) = stack.Peek();
                        range.Add(currentCharacter);
                    }
                    else
                    {
                        result.Add(currentCharacter);

                    }
                    continue;
                }

                if (char.IsDigit(currentCharacter))
                {
                    digits = digits * 10 + (currentCharacter - '0'); // append digits to get multiplier 
                    continue;
                }

                if (currentCharacter == '[')
                {
                    stack.Push((digits, new List<char>()));
                    digits = 0;
                    continue;
                }

                if (currentCharacter == ']')
                {
                    (int multiplier, List<char> range) = stack.Pop();

                    List<char> multipliedLetters = [];
                    for (int j = 0; j < multiplier; j++)
                    {
                        multipliedLetters.AddRange(range);
                    }

                    if (stack.Count > 0)
                    {
                        (_, List<char> nextRange) = stack.Peek();
                        nextRange.AddRange(multipliedLetters);
                    }
                    else
                    {
                        result.AddRange(multipliedLetters);
                    }

                    continue;
                }
            }

            return new string([.. result]);
        }
    }
}
