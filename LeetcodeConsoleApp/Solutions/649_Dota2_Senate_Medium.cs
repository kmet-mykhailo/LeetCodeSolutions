namespace LeetcodeConsoleApp.Solutions
{
    public class Dota2Senate : ISolution
    {
        public void Run()
        {
            string[] inputs = [
                "RRR",
                "D",
                "RD",
                "RDD",
                "DDDRRRRR",
                "DRDRR"
                ];
            foreach (var input in inputs)
            {
                string result = PredictPartyVictory(input);
                Console.WriteLine($"Result {result}");
            }
        }

        private static string PredictPartyVictory(string senate)
        {
            Queue<char> queue = new();
            int bannedRadiantCount = 0;
            int bannedDireCount = 0;

            foreach (char senator in senate)
            {
                if (senator == 'R')
                {
                    if (bannedRadiantCount > 0)
                    {
                        bannedRadiantCount--;
                    }
                    else
                    {
                        queue.Enqueue(senator);
                        bannedDireCount++;
                    }
                }
                else
                {
                    if (bannedDireCount > 0)
                    {
                        bannedDireCount--;
                    }
                    else
                    {
                        queue.Enqueue(senator);
                        bannedRadiantCount++;
                    }
                }
            }

            while (true)
            {
                if (bannedRadiantCount >= queue.Count) { return "Dire"; }
                if (bannedDireCount >= queue.Count) { return "Radiant"; }

                char senator = queue.Dequeue();
                if (queue.Count == 0)
                {
                    return senator == 'R' ? "Radiant" : "Dire";
                }

                if (senator == 'R')
                {
                    if (bannedRadiantCount > 0)
                    {
                        bannedRadiantCount--;
                    }
                    else
                    {
                        queue.Enqueue(senator);
                        bannedDireCount++;
                    }
                }
                else
                {
                    if (bannedDireCount > 0)
                    {
                        bannedDireCount--;
                    }
                    else
                    {
                        queue.Enqueue(senator);
                        bannedRadiantCount++;
                    }
                }
            }
        }
    }
}
