namespace LeetcodeConsoleApp.Solutions
{
    public class TwoSum : ISolution
    {
        public void Run()
        {
            (int[], int) input1 = ([2, 7, 11, 15], 9);
            (int[], int) input2 = ([3, 2, 4], 6);
            (int[], int) input3 = ([3, 3], 6);
            (int[] numberArray, int target)  = ([3, 3, 4, 5, 6, 7, 7, 5, 5, 6, 6, 4, 2, 5, 7, 2, 5, 2], 100);

            Func<int[], int, (int[], int, double, string)> strategy = RunWithHashMap; // RunBrutForce, RunBrutForceEnhanced, RunWithHashMap, RunWithHashMapEnhanced

            foreach (var input in new[] { input1, input2, input3 })
            {
                Check(strategy, input);
            }

            var worsCase = strategy(numberArray, target);
            Display(worsCase);
        }

        static void Check(Func<int[], int, (int[], int, double, string)> function, (int[] numberArray, int target) input)
        {
            (int[] indexes, int iterationCount, double iterationCountByFormula, string formula) = function(input.numberArray, input.target);
            DisplayResults(indexes, formula);
        }

        static (int[], int, double, string) RunWithHashMapEnhanced(int[] numberArray, int target)
        {
            const string formula = "n"; // Formula for the number of iterations in a single loop
            int n = numberArray.Length;
            double iterationCountByFormula = n; // n
            Dictionary<int, int> map = [];
            int iterationCount = 0;
            for (int i = 0; i < numberArray.Length; i++)
            {
                iterationCount++;
                int complement = target - numberArray[i];
                if (map.TryGetValue(complement, out int index))
                {
                    return ([index, i], iterationCount, iterationCountByFormula, formula);
                }
                map[numberArray[i]] = i;
            }
            return ([-1, -1], iterationCount, iterationCountByFormula, formula); // Return -1, -1 if no solution found
        }
        static (int[], int, double, string) RunWithHashMap(int[] numberArray, int target)
        {
            const string formula = "n"; // Formula for the number of iterations in a single loop
            int n = numberArray.Length;
            double iterationCountByFormula = n; // n
            Dictionary<int, int> map = [];

            for (int i = 0; i < numberArray.Length; i++)
            {
                map[numberArray[i]] = i; // Store the index of each number
            }

            int iterationCount = 0;
            for (int i = 0; i < numberArray.Length; i++)
            {
                iterationCount++;
                int complement = target - numberArray[i];
                if (map.TryGetValue(complement, out int index) && index != i)
                {
                    return ([i, index], iterationCount, iterationCountByFormula, formula);
                }
            }
            return ([-1, -1], iterationCount, iterationCountByFormula, formula); // Return -1, -1 if no solution found
        }
        static (int[], int, double, string) RunBrutForceEnhanced(int[] numberArray, int target)
        {
            const string formula = "(n^2 - n) / 2"; // Formula for the number of iterations in a nested loop where the second loop starts from i + 1
            int n = numberArray.Length;
            double iterationCountByFormula = (Math.Pow(n, 2) - n) / 2; // (n^2 - n) / 2

            int iterationCount = 0;
            for (int i = 0; i < numberArray.Length; i++)
            {
                for (int j = i + 1; j < numberArray.Length; j++)
                {
                    iterationCount++;
                    if (numberArray[i] + numberArray[j] == target)
                    {
                        return ([i, j], iterationCount, iterationCountByFormula, formula);
                    }
                }
            }
            return ([-1, -1], iterationCount, iterationCountByFormula, formula); // Return -1, -1 if no solution found

        }
        static (int[], int, double, string) RunBrutForce(int[] numberArray, int target)
        {
            const string formula = "n^2"; // Formula for the number of iterations in a nested loop
            int n = numberArray.Length;
            double iterationCountByFormula = Math.Pow(n, 2); // n^2
            int iterationCount = 0;
            for (int i = 0; i < numberArray.Length; i++)
            {
                for (int j = 0; j < numberArray.Length; j++)
                {
                    iterationCount++;
                    if (i != j && numberArray[i] + numberArray[j] == target)
                    {
                        return ([i, j], iterationCount, iterationCountByFormula, formula);
                    }
                }
            }
            return ([-1, -1], iterationCount, iterationCountByFormula, formula); // Return -1, -1 if no solution found
        }

        static void DisplayResults(int[] indexes, string formula)
        {
            Console.WriteLine("[{0}] Formula {1}", string.Join(", ", indexes), formula);
        }

        static void Display((int[], int iterationCount, double iterationCountByFormula, string) result)
        {
            Console.Write("Amount of checks: ");
            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(result.iterationCount);
            Console.ForegroundColor = defaultColor;
            Console.Write(" expected value: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(result.iterationCountByFormula);
            Console.ForegroundColor = defaultColor;
            Console.WriteLine();
        }
    }
}
