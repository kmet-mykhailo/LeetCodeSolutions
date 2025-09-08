namespace LeetcodeConsoleApp.Solutions
{
    public class AsteroidCollisionSolution : ISolution
    {
        public void Run()
        {
            int[][] inputs = [
                [-2,-1,1,2],
                [5, 10, -5],
                [8, -8],
                [10, 2, -5],
                [1,-2,-2,-2],
                [-2,-2,1,-2],
                [-2,1,-1,-2],
                [1,-1,-2,-2]
            ];
            foreach (int[] input in inputs)
            {
                int[] result = AsteroidCollision(input);
                Console.WriteLine($"Result [{string.Join(',', result)}]");
            }
        }

        private static int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = [];
            stack.Push(asteroids[0]);

            for (int i = 1; i < asteroids.Length; i++)
            {
                int currentElement = asteroids[i];
                int lastElement = stack.Peek();

                while (true)
                {
                    if (currentElement > 0 || lastElement < 0)
                    {
                        stack.Push(currentElement);
                        break;
                    }

                    int difference = currentElement + lastElement;

                    if (difference > 0)
                    {
                        break;
                    }

                    if (difference == 0)
                    {
                        stack.Pop();
                        if (stack.Count == 0 && i < asteroids.Length - 1)
                        {
                            i++;
                            stack.Push(asteroids[i]);
                        }
                        break;
                    }
                    else
                    {
                        stack.Pop();
                        if (stack.Count == 0)
                        {
                            stack.Push(asteroids[i]);
                            break;
                        }
                        lastElement = stack.Peek();
                    }
                }
            }

            int[] result = new int[stack.Count];
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                result[i] = stack.Pop();
            }
            return result;
        }
    }
}
