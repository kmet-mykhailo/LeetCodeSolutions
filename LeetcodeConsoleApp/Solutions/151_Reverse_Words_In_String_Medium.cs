using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeConsoleApp.Solutions
{
    public class ReverseWordsInString : ISolution
    {
        public void Run()
        {
            string[] inputs = [
                "",
                "the sky is blue",
                "  hello world  ",
                "a good   example",
                "test"
                ];
            foreach (string input in inputs)
            {
                string result = GetReverseWords(input);
                Console.WriteLine($"Result '{result}'");
            }
        }

        private static string GetReverseWords1(string s)
        {
            List<char> wordCharList = new List<char>();
            Stack<string> result = [];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    wordCharList.Add(s[i]);
                    if (i == s.Length - 1 && wordCharList.Count > 0)
                    {
                        result.Push(new string(wordCharList.ToArray()));
                    }
                }
                else
                {
                    if (wordCharList.Count > 0)
                    {
                        result.Push(new string(wordCharList.ToArray()));
                        wordCharList = new List<char>();
                    }
                }
            }

            return string.Join(' ', result);
        }

        private static string GetReverseWords2(string s)
        {
            Stack<string> result = [];
            foreach (string input in s.Split(' '))
            {
                if (input != string.Empty)
                {
                    result.Push(input);
                }
            }

            return string.Join(' ', result);
        }

        private static string GetReverseWords3(string s)
        {
            List<char> word = new List<char>();
            var sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    word.Add(s[i]);

                    if (i == s.Length - 1 && word.Count > 0)
                    {

                        sb.Insert(0, new string(word.ToArray()) + (sb.Length == 0 ? string.Empty : " "));
                    }
                }
                else
                {
                    if (word.Count > 0)
                    {
                        sb.Insert(0, new string(word.ToArray()) + (sb.Length == 0 ? string.Empty : " "));
                        word = new List<char>();
                    }
                }
            }

            return sb.ToString();
        }

        private static string GetReverseWords4(string s)
        {
            List<char> wordCharList = new List<char>();
            Stack<string> result = [];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    wordCharList.Add(s[i]);
                    if (i == s.Length - 1 && wordCharList.Count > 0)
                    {
                        result.Push(new string(wordCharList.ToArray()));
                    }
                }
                else
                {
                    if (wordCharList.Count > 0)
                    {
                        result.Push(new string(wordCharList.ToArray()));
                        wordCharList = new List<char>();
                    }
                }
            }
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                sb.Append(s[i]);
                if (i != s.Length - 1)
                {
                    sb.Append(" ");
                }
            }


            return string.Join(' ', result);
        }

        private static string GetReverseWords5(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 0) return s;
            string[] result = s.Split(' ');

            string temp;
            for (int i = 0, j = result.Length - 1; i < j;)
            {
                var temp1 = result[i];
                var temp2 = result[j];
                if (result[i].Length == 0)
                {
                    i++; 
                    continue;
                }
                if (result[j].Length == 0)
                {
                    j--;
                    continue;
                }

                temp = result[i];
                result[i] = result[j];
                result[j] = temp;
                i++;
                j--;
            }

            return string.Join(' ', result.Where(x=>x.Length!=0));
        }

        private static string GetReverseWords(string s)
        {
            s = s.Trim();
            string[] words = s.Split(' ' , StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }
    }
}
