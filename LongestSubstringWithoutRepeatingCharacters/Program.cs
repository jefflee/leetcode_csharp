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
            int r = LengthOfLongestSubstring_sol2_slicingWindow("abcabcbb");
            Console.WriteLine(r);  // 3

            r = LengthOfLongestSubstring_sol2_slicingWindow("bbbbb");
            Console.WriteLine(r);  // 1

            r = LengthOfLongestSubstring_sol2_slicingWindow("pwwkew");
            Console.WriteLine(r);  // 3

            r = LengthOfLongestSubstring_sol2_slicingWindow("aab");
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

        // There is another solution 3.
    }
}
