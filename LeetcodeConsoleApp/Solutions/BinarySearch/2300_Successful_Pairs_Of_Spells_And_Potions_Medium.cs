namespace LeetcodeConsoleApp.Solutions.BinarySearch
{
    public class SuccessfulPairsOfSpellsAndPotions : ISolution
    {
        public void Run()
        {
            (int[] spells, int[] potions, long success)[] inputs = [
                ([5, 1, 3], [1, 2, 3, 4, 5], 7), // 4 0 3
                //([1,2,3,4,5,6,7],[1,2,3,4,5,6,7],25), // 0 0 0 1 3 3 4
                //(Enumerable.Repeat(100_000, 100_000).ToArray(), Enumerable.Repeat(100_000, 100_000).ToArray(), 10_000_000_000 )
            ];

            foreach ((int[] spells, int[] potions, long success) in inputs)
            {
                //potions[^1] = 1;
                var result = SuccessfulPairs(spells, potions, success);
                Console.WriteLine($"{string.Join(", ", result)}");
            }
        }

        private static int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            Array.Sort(potions);
            Dictionary<int, int> prevResults = [];

            int[] results = new int[spells.Length];
            for (int i = 0; i < spells.Length; i++)
            {
                if (prevResults.TryGetValue(spells[i], out int value))
                {
                    results[i] = value;
                }
                else
                {
                    results[i] = potions.Length - FindIndex((success + spells[i] - 1) / spells[i], potions, 0, potions.Length - 1);
                    prevResults[spells[i]] = results[i];
                }
            }

            return results;
        }

        private static int[] SuccessfulPairs3(int[] spells, int[] potions, long success)
        {
            PriorityQueue<long, (long, int)> queue = new();

            for (var i = 0; i < potions.Length; i++)
            {
                long neededSpellCost = success % potions[i] == 0
                    ? success / potions[i]
                    : success / potions[i] + 1;

                queue.Enqueue(long.MaxValue, (neededSpellCost, -1));
            }

            for (int i = 0; i < spells.Length; i++)
            {
                queue.Enqueue(i, (spells[i], 1));
            }


            int[] results = new int[spells.Length];
            int value = 0;

            while (queue.Count > 0)
            {
                queue.TryDequeue(out long index, out (long, int) priority);


                if (index == long.MaxValue)
                {
                    value++;
                }
                else
                {
                    results[index] = value;
                }
            }

            return results;
        }

        private static int FindIndex1(long potionToFind, int[] potions, int from, int to)
        {
            Console.WriteLine($"potionToFind = {potionToFind}, from = {from}, to = {to}");
            if (potions[from] >= potionToFind)
            {
                return from;
            }

            if (potions[to] < potionToFind)
            {
                return to + 1;
            }

            int guess = from + (to - from) / 2;

            if (potions[guess] < potionToFind)
            {
                from = guess + 1;
            }
            else
            {
                to = guess - 1;
            }

            return FindIndex1(potionToFind, potions, from, to);
        }

        private static int FindIndex(long potionToFind, int[] potions, int from, int to)
        {
            if (potions[from] >= potionToFind) return from;
            if (potions[to] < potionToFind) return to + 1;

            while (from < to)
            {
                int guess = from + (to - from) / 2;

                if (potions[guess] < potionToFind)
                {
                    from = guess + 1;
                }
                else
                {
                    to = guess;
                }
            }

            return from;
        }

        private static int FindIndex2(long potionToFind, int[] potions, int from, int to)
        {
            Console.WriteLine($"potionToFind = {potionToFind}, from = {from}, to = {to}");
            if (from == to) return from;

            int guess = from + (to - from) / 2;

            if (potions[guess] < potionToFind)
            {
                from = guess + 1;
            }
            else
            {
                to = guess;
            }

            return FindIndex2(potionToFind, potions, from, to);
        }
    }
}
