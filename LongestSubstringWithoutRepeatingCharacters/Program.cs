using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        // https://leetcode.com/problems/longest-substring-without-repeating-characters/

        static void Main(string[] args)
        {
            int r = LengthOfLongestSubstring_sol3_slicingWindow_optimized("abcabcbb");
            Console.WriteLine(r);  // 3

            r = LengthOfLongestSubstring_sol3_slicingWindow_optimized("bbbbb");
            Console.WriteLine(r);  // 1

            r = LengthOfLongestSubstring_sol2_slicingWindow("pwwkew");
            Console.WriteLine(r);  // 3

            r = LengthOfLongestSubstring_sol3_slicingWindow_optimized("aab");
            Console.WriteLine(r);  // 2

        }

        public static int LengthOfLongestSubstring_sol1_bruteForce(string s)
        {
            int maxLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Length - i < maxLength)
                {
                    break;
                }
                HashSet<char> tmpDic = new HashSet<char>();
                for (int j = i; j < s.Length; j++)
                {
                    int subStringLength = j - i + 1;
                    if (tmpDic.Contains(s[j]) == false)
                    {
                        tmpDic.Add(s[j]);
                        if (maxLength < subStringLength)
                        {
                            maxLength = subStringLength;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return maxLength;
        }

        public static int LengthOfLongestSubstring_sol2_slicingWindow(string s)
        {
            HashSet<char> charDic = new HashSet<char>();

            int maxLength = 0, first = 0, second = 0;
            while (first < s.Length && second < s.Length)
            {
                if (!charDic.Contains(s[second]))
                {
                    charDic.Add(s[second]);
                    maxLength = Math.Max(maxLength, second - first + 1);
                    second++;
                }
                else
                {
                    charDic.Remove(s[first]);
                    first++;
                }
            }
            return maxLength;
        }

        public static int LengthOfLongestSubstring_sol3_slicingWindow_optimized(string s)
        {
            Dictionary<char, int> charIndexDic = new Dictionary<char, int>();
            int maxLength = 0;

            for (int i = 0, j = 0; j < s.Length; j++)
            {
                if (charIndexDic.ContainsKey(s[j]))
                {
                    i = Math.Max(charIndexDic[s[j]], i);

                }

                charIndexDic[s[j]] = j + 1;
                maxLength = Math.Max(maxLength, j - i + 1);
            }
            return maxLength;
        }

    }
}
