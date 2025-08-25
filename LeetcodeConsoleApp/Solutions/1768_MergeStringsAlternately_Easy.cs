using System.Text;

namespace LeetcodeConsoleApp.Solutions
{
    public class MergeStringsAlternately : ISolution
    {
        public void Run()
        {
            string word1 = "qwerty135678";
            string word2 = "qwerty24";
            string merged = MergeAlternately3(word1, word2);
            Console.WriteLine(merged);
        }

        private static string MergeAlternately(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1)) return word2;
            if (string.IsNullOrEmpty(word2)) return word1;

            var merged = new StringBuilder();
            IEnumerable<char> test1 = word1;
            IEnumerable<char> test2 = word2;
            
            var maxLength = word1.Length > word2.Length ? word1.Length : word2.Length;
            for (int i = 0; i <= maxLength; i++)
            {
                if (word1.Length - 1 >= i)
                {
                    merged.Append(word1[i]);
                }

                if (word2.Length - 1 >= i)
                {
                    merged.Append(word2[i]);
                }
            }

            return merged.ToString();
        }

        private static string MergeAlternately3(string word1, string word2)
        {
            var merged = new StringBuilder(word1.Length + word2.Length);

            var minLength = word1.Length < word2.Length ? word1.Length : word2.Length;
            for (int i = 0; i < minLength; i++)
            {
                merged.Append(word1[i]).Append(word2[i]);
            }

            merged.Append(word1.Substring(minLength)).Append(word2.Substring(minLength));

            return merged.ToString();
        }


        private static string MergeAlternately2(string word1, string word2)
        {
            char[] merged = new char[word1.Length + word2.Length];
            IEnumerable<char> test1 = word1;
            IEnumerable<char> test2 = word2;

            var maxLength = word1.Length > word2.Length ? word1.Length : word2.Length;
            for (int i = 0, j=0; i <= maxLength; i++)
            {
                if (word1.Length - 1 >= i)
                {
                    merged[j] = word1[i];
                    j++;
                }

                if (word2.Length - 1 >= i)
                {
                    merged[j] = word2[i];
                    j++;
                }
            }

            return new string(merged);
        }
    }
}
