using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelSpellchecker
{
    // https://leetcode.com/problems/vowel-spellchecker/solution/
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordlist = new[] { "KiTe", "kite", "hare", "Hare", "Hare" };
            string[] queries = new[] { "kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto" };
            string[] r = Spellchecker(wordlist, queries);
            Console.WriteLine(r);
        }

        public static string[] Spellchecker(string[] wordlist, string[] queries)
        {
            HashSet<string> wordEqual = new HashSet<string>();
            Dictionary<string, string> wordSmallCase = new Dictionary<string, string>();
            Dictionary<string, string> wordDeVowel = new Dictionary<string, string>();

            foreach (string word in wordlist)
            {
                wordEqual.Add(word);

                string lowerWord = word.ToLower();
                if (wordSmallCase.ContainsKey(lowerWord) == false)
                {
                    wordSmallCase.Add(lowerWord, word);
                }

                string deVowelWord = DeVowel(word);
                if (wordDeVowel.ContainsKey(deVowelWord) == false)
                {
                    wordDeVowel.Add(deVowelWord, word);
                }
            }

            string[] result = new string[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = Match(wordEqual, wordSmallCase, wordDeVowel, queries[i]);
            }

            return result;
        }

        public static string Match(HashSet<string> wordEqual, Dictionary<string, string> wordSmallCase,
            Dictionary<string, string> wordDeVowel, string query)
        {
            if (wordEqual.Contains(query))
            {
                return query;
            }

            string lower = query.ToLower();
            if (wordSmallCase.ContainsKey(lower))
            {
                return wordSmallCase[lower];
            }

            string deVowel = DeVowel(query);
            if (wordDeVowel.ContainsKey(deVowel))
            {
                return wordDeVowel[deVowel];
            }

            return "";
        }

        public static string DeVowel(string word)
        {
            StringBuilder s = new StringBuilder();
            foreach (char c in word)
            {
                if (IsVowel(c) == true)
                {
                    continue;
                }

                s.Append(c);
            }

            return s.ToString();
        }

        public static bool IsVowel(char c)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' ||
                c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
            {
                return true;
            }

            return false;
        }
    }
}
