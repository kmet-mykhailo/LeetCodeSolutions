namespace LeetcodeConsoleApp.Solutions.DynamicProgramming
{
    public class EditDistance : ISolution
    {
        public void Run()
        {
            (string word1, string word2)[] inputs = [
                ("horse", "ros"),//3
                ("intention", "execution"), //5
                ("", "a"), //1
                ("a", "aa"), // 1
                ("a", "ab"), // 1
                ("plasma", "altruism"), // 6
                ("kitten", "sitting"), // 3
                ];
            foreach ((string word1, string word2) in inputs)
            {
                int result = MinDistance(word1, word2);
                Console.WriteLine(result);
            }
        }

        private static int MinDistance(string word1, string word2)
        {
            if (word1.Length == 0) return word2.Length;
            if (word1 == word2) return 0;

            int currentValue = 0;
            int[] previosRow = new int[word2.Length + 1];

            for (int i = 0; i < previosRow.Length; i++)
            {
                previosRow[i] = i;
            }

            for (int index1 = 0; index1 < word1.Length; index1++)
            {
                currentValue = index1 + 1;

                for (int index2 = 0; index2 < word2.Length; index2++)
                {
                    int temp = currentValue;
                    if (word1[index1] == word2[index2])
                    {
                        currentValue = previosRow[index2];
                    }
                    else
                    {
                        int min = currentValue < previosRow[index2] ? currentValue : previosRow[index2];
                        min = min < previosRow[index2 + 1] ? min : previosRow[index2 + 1];
                        currentValue = min + 1;
                    }
                    previosRow[index2] = temp;
                }

                previosRow[^1] = currentValue;
            }

            return currentValue;
        }
    }
}
