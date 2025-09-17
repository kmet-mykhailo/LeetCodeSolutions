namespace LeetcodeConsoleApp.Solutions
{
    public class MaximumNumberOfVowelsInSubstring : ISolution
    {
        public void Run()
        {
            (string s, int k)[] inputs = [
                ("leetcode",3),
                ("abciiidef", 3),
                ("emkzcblopdxxtbxnxkevjqumgtivb", 5)
                ];
            foreach ((string s, int k) in inputs)
            {
                int result = MaxVowels(s, k);
                Console.WriteLine($"Result {result}");
            }
        }

        private static int MaxVowels(string s, int k)
        {
            int max = 0;
            int vowelCount = 0;

            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];
                bool isVowel = ((0x208222 >> (currentChar & 0x1f)) & 1) == 1;
                if (isVowel)
                {
                    vowelCount++;
                }

                if (i >= k)
                {
                    currentChar = s[i - k];
                    isVowel = ((0x208222 >> (currentChar & 0x1f)) & 1) == 1;
                    if (isVowel)
                    {
                        vowelCount--;
                    }
                }

                if (vowelCount == k) { return k; }

                if (vowelCount > max)
                {
                    max = vowelCount;
                }
            }

            return max;
        }

        private static int MaxVowels3(string s, int k)
        {
            int max = 0;
            for (int i = 0; i < k; i++)
            {
                char currentChar = s[i];
                bool isVowel = (currentChar == 'a' || currentChar == 'e' || currentChar == 'i' || currentChar == 'o' || currentChar == 'u');
                if (isVowel)
                {
                    max++;
                }
            }

            if (max == k) { return k; }

            int vowelCount = max;
            for (int i = k; i < s.Length; i++)
            {
                char firstChar = s[i - k];
                bool isVowel = (firstChar == 'a' || firstChar == 'e' || firstChar == 'i' || firstChar == 'o' || firstChar == 'u');
                if (isVowel)
                {
                    vowelCount--;
                }

                char currentChar = s[i];
                isVowel = (currentChar == 'a' || currentChar == 'e' || currentChar == 'i' || currentChar == 'o' || currentChar == 'u');
                if (isVowel)
                {
                    vowelCount++;
                }

                if (vowelCount == k) { return k; }

                if (vowelCount > max)
                {
                    max = vowelCount;
                }
            }

            return max;
        }

        private static int MaxVowels1(string s, int k)
        {
            HashSet<char> vowelSet = ['a', 'e', 'i', 'o', 'u'];
            int max = 0;
            for(int i = 0; i < k;i++)
            {
                bool isVowel = vowelSet.Contains(s[i]);
                if (isVowel)
                {
                    max++;
                }
            }

            if (max == k) { return k; }

            int vowelCount = max;
            for (int i = k; i < s.Length; i++)
            {                
                bool isVowel = vowelSet.Contains(s[i-k]);
                if (isVowel)
                {
                    vowelCount--;
                }

                isVowel = vowelSet.Contains(s[i]);
                if (isVowel)
                {
                    vowelCount++;
                }

                if(vowelCount == k) { return k; }

                if(vowelCount> max)
                {
                    max = vowelCount;
                }
            }

            return max;
        }
    }
}
