using FluentAssertions;
using NUnit.Framework;

namespace NunitTest;

/// <summary>
///     https://leetcode.com/problems/longest-palindromic-substring/description/
/// </summary>
internal class LongestPalindromicSubstring
{
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }

        if (s.Length == 1)
        {
            return s;
        }

        var maxPalindrome = s[0].ToString();
        for (var k = 0; k < s.Length; k++)
        {
            for (var o = k + maxPalindrome.Length; o < s.Length; o++)
            {
                var subString = s[k..(o + 1)];
                if (IsPalindrome(subString) && subString.Length > maxPalindrome.Length)
                {
                    maxPalindrome = subString;
                }
            }
        }

        return maxPalindrome;
    }

    private bool IsPalindrome(string input)
    {
        for (var k = 0; k < input.Length / 2; k++)
        {
            var leftChar = input[k];
            var rightChar = input[^(k + 1)];
            if (leftChar != rightChar)
            {
                return false;
            }
        }

        return true;
    }
}

public class LongestPalindromicSubstringTest
{
    [TestCase("babad", "bab")]
    [TestCase("cbbd", "bb")]
    [TestCase("abc1cba", "abc1cba")]
    [TestCase("1qaabc1cbazxc", "abc1cba")]
    public void Test(string input, string expected)
    {
        var sut = new LongestPalindromicSubstring();
        var output = sut.LongestPalindrome(input);
        output.Should().Be(expected);
    }
}