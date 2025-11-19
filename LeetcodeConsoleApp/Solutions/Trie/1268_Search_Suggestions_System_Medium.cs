namespace LeetcodeConsoleApp.Solutions.Trie
{
    public class SearchSuggestionsSystem : ISolution
    {
        public void Run()
        {
            (string[] products, string searchWord)[] inputs = [
                (["mobile", "mouse", "moneypot", "monitor", "mousepad"], "mouse")];

            foreach ((string[] products, string searchWord) in inputs)
            {
                IList<IList<string>> result = SuggestedProducts(products, searchWord);
                string output = $"[{string.Join(",", result.Select(x => $"[{string.Join(",", x)}]"))}]";
                Console.WriteLine(output);
            }
        }

        private static IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            Array.Sort(products);
            IList<IList<string>> results = [];

            for (int searchIndex = 0; searchIndex < searchWord.Length; searchIndex++)
            {
                List<string> result = [];
                for (int productIndex = 0, insertedCount = 0; productIndex < products.Length; productIndex++)
                {
                    if (products[productIndex].Length > searchIndex)
                    {
                        if (products[productIndex][searchIndex] == searchWord[searchIndex])
                        {
                            if (insertedCount < 3)
                            {
                                result.Add(products[productIndex]);
                                insertedCount++;
                            }
                        }
                        else
                        {
                            products[productIndex] = string.Empty;
                        }
                    }
                }

                results.Add(result);
            }

            return results;
        }
    }
}
