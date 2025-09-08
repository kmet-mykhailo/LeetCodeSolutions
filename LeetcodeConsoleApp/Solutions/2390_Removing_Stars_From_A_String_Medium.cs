namespace LeetcodeConsoleApp.Solutions
{
    public class RemovingStarsFromAString : ISolution
    {
        public void Run()
        {
            string[] inputs = ["mishaaa**kmee*t", "solution********" ];
            foreach (string input in inputs)
            {
                string result = RemoveStars(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static string RemoveStars(string s)
        {
            int starCount = 0;
            Stack<char> stack = new();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char c = s[i];
                if (c == '*')
                {
                    starCount++;
                }
                else
                {
                    if (starCount == 0)
                    {
                        stack.Push(c);
                    }
                    else
                    {

                        starCount--;
                    }
                }
            }

            return new string([.. stack]);
        }
    }
}
