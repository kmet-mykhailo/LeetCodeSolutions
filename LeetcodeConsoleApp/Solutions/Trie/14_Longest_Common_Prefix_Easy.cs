namespace LeetcodeConsoleApp.Solutions.Trie
{
    public class LongestCommonPrefixSolution : ISolution
    {
        public void Run()
        {
            string[][] inputs = [
                ["two", "two"], // two
                ["flower", "flow", "flight"], // fl
                ["","b"],
                ["ab","a"],
                ["c","acc","ccc"]
                ];

            foreach (string[] input in inputs)
            {
                string result = LongestCommonPrefix(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static string LongestCommonPrefix1(string[] strs)
        {
            if (strs.Length == 0) return string.Empty;
            if (strs.Length == 1) return strs[0];

            string prefix = strs[0];
            int length = prefix.Length;

            for (int wordIndex = 1; wordIndex < strs.Length; wordIndex++)
            {
                if (length == 0) return string.Empty;

                if (strs[wordIndex].Length < length)
                {
                    length = strs[wordIndex].Length;
                }

                for (int charIndex = 0; charIndex < length; charIndex++)
                {
                    if (prefix[charIndex] != strs[wordIndex][charIndex])
                    {
                        length = charIndex;
                        break;
                    }
                }
            }

            return prefix.Substring(0, length);
        }

        private static string LongestCommonPrefix2(string[] strs)
        {
            if (strs.Length == 0) return string.Empty;
            if (strs.Length == 1) return strs[0];

            Array.Sort(strs, (x, y) => x.Length.CompareTo(y.Length));
            int length = strs[0].Length;
            for (int i = 0; i < strs[0].Length; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    //Console.WriteLine($"{strs[0][i]} - {strs[j][i]}, index {i}" );
                    if (strs[j][i] != strs[0][i])
                        return i == 0 ? "" : strs[0].Substring(0, i);
                }
            }

            return strs[0];
        }

        private static string LongestCommonPrefix(string[] strs)
        {
            for (int i = 0; i < strs[0].Length; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i == strs[j].Length || strs[j][i] != strs[0][i])
                        return strs[j].Substring(0, i);
                }
            }
            return strs[0];
        }
    }
}
