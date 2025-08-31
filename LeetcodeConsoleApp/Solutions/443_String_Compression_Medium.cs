namespace LeetcodeConsoleApp.Solutions
{
    public class StringCompressionSolution : ISolution
    {
        public void Run()
        {
            var chars = new char[] { 'a', 'b', 'c'};
            var charsA = new char[] { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' };
            var charsB = new char[] { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a'};
            var chars1 = new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c' };
            var chars2 = new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b' };
            var inputs = new[] { chars, charsA, charsB, chars1, chars2 };

            foreach (char[] input in inputs)
            {
                int result = Compress(input);
                Console.WriteLine($"Result {result}, {new string(input[..result])}");
            }
        }

        private static int Compress(char[] chars)
        {
            char currentChar = chars[0];
            int currentCount = 1;
            int newIndex = 1;
            for (int i = 1; i < chars.Length; i++)
            {
                var indexedChar = chars[i];
                if (indexedChar == currentChar)
                {
                    currentCount++;
                }

                if (currentCount > 1 && (indexedChar != currentChar || i == chars.Length - 1))
                {
                    foreach (char c in currentCount.ToString())
                    {
                        chars[newIndex] = c;
                        newIndex++;
                    }
                }

                if (indexedChar != currentChar)
                {
                    currentChar = indexedChar;
                    chars[newIndex] = indexedChar;
                    newIndex++;
                    currentCount = 1;
                }
            }

            return newIndex;
        }
    }
}
