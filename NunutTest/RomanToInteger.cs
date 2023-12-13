using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeNUnitTest
{
    /// <summary>
    ///     https://leetcode.com/problems/roman-to-integer/
    /// </summary>
    public class RomanToInteger
    {
        private static readonly IDictionary<char, int> romanValueDic = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        private static readonly IDictionary<string, int> comboValueDic = new Dictionary<string, int>
        {
            { "IV", 4 },
            { "IX", 9 },
            { "XL", 40 },
            { "XC", 90 },
            { "CD", 400 },
            { "CM", 900 }
        };

        public int RomanToInt(string s)
        {
            var result = 0;
            for (var k = 0; k < s.Length; k++)
            {
                if (k < s.Length - 1)
                {
                    var comboValue = GetComboValue(s, k);
                    if (comboValue > 0)
                    {
                        result += comboValue;
                        k++;
                        continue;
                    }
                }

                if (romanValueDic.ContainsKey(s[k]))
                {
                    result += romanValueDic[s[k]];
                }
            }

            return result;
        }

        private static int GetComboValue(string s, int k)
        {
            var combo = s[k] + s[k + 1].ToString();
            return comboValueDic.ContainsKey(combo) ? comboValueDic[combo] : 0;
        }
    }

    public class RomanToIntegerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        public void Test(string roman, int expectedResult)
        {
            var convert = new RomanToInteger();
            var val = convert.RomanToInt(roman);
            val.Should().Be(expectedResult);
        }
    }
}