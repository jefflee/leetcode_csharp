using System;
using System.Collections.Generic;

namespace LongestSubstringWithoutRepeatingCharacters
{
    internal class Program
    {
        // https://leetcode.com/problems/longest-substring-without-repeating-characters/
        // 3. Longest Substring Without Repeating Characters

        private static void Main(string[] args)
        {
            var r = LengthOfLongestSubstring_sol3_slicingWindow_optimized("abcabcbb");
            Console.WriteLine(r); // 3

            r = LengthOfLongestSubstring_sol3_slicingWindow_optimized("bbbbb");
            Console.WriteLine(r); // 1

            r = LengthOfLongestSubstring_sol2_slidingWindow("pwwkew");
            Console.WriteLine(r); // 3

            r = LengthOfLongestSubstring_sol3_slicingWindow_optimized("aab");
            Console.WriteLine(r); // 2
        }

        public static int LengthOfLongestSubstring_sol1_bruteForce(string s)
        {
            var maxLength = 0;
            // For each i, I need to find the longest substring without repeating characters.
            // There is a waste of time here, because I don't need to start from j = i + 1 next time.
            // The next sliding window improve this.
            for (var i = 0; i < s.Length; i++)
            {
                if (s.Length - i < maxLength)
                {
                    break;
                }

                var tmpDic = new HashSet<char>();
                for (var j = i; j < s.Length; j++)
                {
                    var subStringLength = j - i + 1;
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

        public static int LengthOfLongestSubstring_sol2_slidingWindow(string s)
        {
            var charDic = new HashSet<char>();

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
                    // If s[second] matched, just move first to first=first+1 and try next round.
                    charDic.Remove(s[first]);
                    first++;
                }
            }

            return maxLength;
        }

        /// <summary>
        ///     The difference between sol2 and sol3 is that the first index increase 1 for the next round.
        ///     The sol3 stored the index of all characters. So, the first index can start from the "previous matched character
        ///     index + 1"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring_sol3_slicingWindow_optimized(string s)
        {
            // The idea is to use a dictionary to store the index of each character.
            var charIndexDic = new Dictionary<char, int>();
            var maxLength = 0;

            for (int i = 0, j = 0; j < s.Length; j++)
            {
                if (charIndexDic.ContainsKey(s[j]))
                {
                    // if char matched, I don't need to start from i + 1 next time.
                    // I can start i from the index of the matched char + 1.
                    i = Math.Max(charIndexDic[s[j]], i);
                }

                charIndexDic[s[j]] = j + 1;
                maxLength = Math.Max(maxLength, j - i + 1);
            }

            return maxLength;
        }
    }
}