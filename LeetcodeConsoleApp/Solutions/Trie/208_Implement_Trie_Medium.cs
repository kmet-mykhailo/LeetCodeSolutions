
namespace LeetcodeConsoleApp.Solutions.Trie
{
    public class ImplementTrie : ISolution
    {
        public void Run()
        {
            Trie trie = new();
            trie.Insert("apple");

            bool result = trie.Search("apple");   // return True
            Console.WriteLine(result);

            result = trie.Search("app");     // return False
            Console.WriteLine(result);

            result = trie.StartsWith("app"); // return True
            Console.WriteLine(result);

            trie.Insert("app");
            result =  trie.Search("app");     // return True
            Console.WriteLine(result);
        }
    }

    public class Trie
    {
        private readonly Dictionary<char, Trie> childern = [];
        private bool IsLeaf = false;

        public Trie()
        {

        }

        public void Insert(string word)
        {
            Trie current = this;
            foreach(char c in word)
            {
                if (!current.childern.TryGetValue(c, out Trie? value))
                {
                    value = new Trie();
                    current.childern[c] = value;
                }

                current = value;
            }

            current.IsLeaf = true;
        }

        public bool Search(string word)
        {
            Trie current = this;
            foreach (char c in word)
            {
                if (!current.childern.TryGetValue(c, out Trie? value))
                {
                    return false;
                }

                current = value;
            }

            return current.IsLeaf;
        }

        public bool StartsWith(string prefix)
        {
            Trie current = this;
            foreach (char c in prefix)
            {
                if (!current.childern.TryGetValue(c, out Trie? value))
                {
                    return false;
                }

                current = value;
            }

            return true;
        }
    }
}
