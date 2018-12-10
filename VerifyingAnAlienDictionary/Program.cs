using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerifyingAnAlienDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "hello", "leetcode" };
            string order = "hlabcdefgijkmnopqrstuvwxyz";
            Console.WriteLine(IsAlienSorted(words, order)); // Expected true

            words = new string[] { "word", "world", "row" };
            order = "worldabcefghijkmnpqstuvxyz";
            Console.WriteLine(IsAlienSorted(words, order)); // Expected false

            words = new string[] { "apple", "app" };
            order = "abcdefghijklmnopqrstuvwxyz";
            Console.WriteLine(IsAlienSorted(words, order)); // Expected false

            words = new string[] { "kuvp", "q" };
            order = "ngxlkthsjuoqcpavbfdermiywz";
            Console.WriteLine(IsAlienSorted(words, order));  // Expected true

            Console.ReadLine();
        }

        public static bool IsAlienSorted(String[] words, String order)
        {
            int[] dict = new int[26];
            for (int i = 0; i < dict.Length; i++)
            {
                int idx = order[i] - 'a';
                dict[idx] = i;
            }
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (compare(words[i], words[i + 1], dict) > 0) return false;
            }

            return true;
        }

        private static int compare(String word1, String word2, int[] dict)
        {
            int L1 = word1.Length;
            int L2 = word2.Length;
            int min = Math.Min(L1, L2);
            for (int i = 0; i < min; i++)
            {
                int c1 = word1[i] - 'a';
                int c2 = word2[i] - 'a';
                if (c1 != c2)
                    return dict[c1] - dict[c2];
            }
            return L1 == min ? -1 : 1;
        }

        public static bool IsAlienSorted_sol1(string[] words, string order)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int k = 0; k < order.Length; k++)
            {
                dic[order[k].ToString()] = k + 1;
            }

            for (int i = 0; i < words.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                if (Compare_sol1(words[i - 1], words[i], dic) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static int Compare_sol1(string w1, string w2, Dictionary<string, int> orderDic)
        {
            for (int k = 0; k < w1.Length; k++)
            {
                if (k >= w2.Length)
                {
                    return -1;
                }
                if (w1[k] == w2[k])
                {
                    continue;
                }
                if (orderDic[w1[k].ToString()] < orderDic[w2[k].ToString()])
                {
                    return 1;
                }
                if (orderDic[w1[k].ToString()] > orderDic[w2[k].ToString()])
                {
                    return -1;
                }

            }

            if (w2.Length > w1.Length)
            {
                return 1;
            }
            return 0;
        }

    }
}
