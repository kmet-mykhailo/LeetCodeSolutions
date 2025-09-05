using System.Diagnostics.Metrics;

namespace LeetcodeConsoleApp.Solutions
{
    public class DetermineIfTwoStringsAreClose : ISolution
    {
        public void Run()
        {
            // abc -> acb -> bca
            // cabbba -> caabbb -> baaccc -> abbccc
            (string word1, string word2)[] inputs = [
                //("cabbba","aabbss"), // false
                //("abc", "bca"), // true
                //("cabbba", "abbccc"), // true
                //("aaaabbbbccccc","aabbbbbbccccc"),
                //("aaabbbbccddeeeeefffff","aaaaabbcccdddeeeeffff"),
                //("aabbcccddd","abccccdddd"),
                ("xxxxxxxxxxxxxxxxxxx","zzzzzzzzzzzzzzzzzzz")
                ];
            foreach (var input in inputs)
            {
                bool result = CloseStrings(input.word1, input.word2);
                Console.WriteLine($"Result {result}");
            }
        }

        private static bool CloseStrings1(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;
            if (word1 == word2) return true;
            Dictionary<char, int> dictionary1 = [];
            Dictionary<char, int> dictionary2 = [];
            for (int i = 0; i < word1.Length; i++)
            {
                char letterWord1 = word1[i];
                char letterWord2 = word2[i];
                if (dictionary1.TryGetValue(letterWord1, out int value))
                {
                    dictionary1[letterWord1] = ++value;
                }
                else
                {
                    dictionary1.Add(letterWord1, 1);
                }
                if (dictionary2.TryGetValue(letterWord2, out int value2))
                {
                    dictionary2[letterWord2] = ++value2;
                }
                else
                {
                    dictionary2.Add(letterWord2, 1);
                }
            }
            if (dictionary1.Count != dictionary2.Count) return false;
            Dictionary<int, int> uniqueCounts = [];
            foreach (var input in dictionary1)
            {
                if (!dictionary2.ContainsKey(input.Key)) return false;
                int count1 = dictionary1[input.Key];
                if (uniqueCounts.TryGetValue(count1, out int value1))
                {
                    uniqueCounts[count1] = ++value1;
                }
                else
                {
                    uniqueCounts.Add(count1, 1);
                }
                int count2 = dictionary2[input.Key];
                if (uniqueCounts.TryGetValue(count2, out int value2))
                {
                    uniqueCounts[count2] = --value2;
                }
                else
                {
                    uniqueCounts.Add(count2, -1);
                }
            }
            return !uniqueCounts.Values.Any(x => x != 0);
        }

        private static bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;
            if (word1 == word2) return true;

            int[] dictionary1 = new int[26];
            int[] dictionary2 = new int[26];

            for (int i = 0; i < word1.Length; i++)
            {
                char letter1 = word1[i];
                char letter2 = word2[i];
                dictionary1[letter1 - 'a']++;
                dictionary2[letter2 - 'a']++;
            }

            for (int i = 0; i < dictionary1.Length; i++)
            {
                if ((dictionary1[i] == 0) != (dictionary2[i] == 0)) return false;
            }

            Array.Sort(dictionary1);
            Array.Sort(dictionary2);

            for (int i = 0; i < dictionary1.Length; i++)
            {
                if (dictionary1[i] != dictionary2[i]) return false;
            }

            return true;
        }
    }
}
