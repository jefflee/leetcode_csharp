using FluentAssertions;
using NUnit.Framework;

namespace NunitTest;

/// <summary>
///     https://leetcode.com/problems/longest-palindromic-substring/description/
///     Solution1: Brute force approach. Compare direction is from two sides to middle.
/// </summary>
internal class LongestPalindromicSubstringSolution1
{
    public string LongestPalindrome(string s)
    {
        if (s.Length <= 1)
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

    private static bool IsPalindrome(string input)
    {
        for (var k = 0; k < input.Length / 2; k++)
        {
            if (input[k] != input[^(k + 1)])
            {
                return false;
            }
        }

        return true;
    }
}

/// <summary>
///     https://leetcode.com/problems/longest-palindromic-substring/solutions/4212564/beats-96-49-5-different-approaches-brute-force-eac-dp-ma-recursion/
///     https://medium.com/hoskiss-stand/manacher-299cf75db97e
/// </summary>
internal class ManacherAlgorithm
{
    public string LongestPalindrome(string s)
    {
        if (s.Length <= 1)
        {
            return s;
        }

        // Insert # between each char
        var reformatedString = $"#{string.Join('#', s.ToCharArray())}#";
        var maxPalindrome = reformatedString[..1];
        var dp = new int[reformatedString.Length];

        for (var k = 0; k < reformatedString.Length; k++)
        {
            var left = 1;
            var right = 1;
            while (reformatedString[k - left] == reformatedString[k + right])
            {
                dp[k]++;
            }
        }

        return reformatedString;
    }
}

public class LongestPalindromicSubstringTest
{
    [TestCase("babad", "bab")]
    [TestCase("cbbd", "bb")]
    [TestCase("abc1cba", "abc1cba")]
    [TestCase("1qaabc1cbazxc", "abc1cba")]
    public void LongestPalindromicSubstringSolution1Test(string input, string expected)
    {
        var sut = new LongestPalindromicSubstringSolution1();
        var output = sut.LongestPalindrome(input);
        output.Should().Be(expected);
    }

    [TestCase("babad", "bab")]
    public void ManacherAlgorithmTest(string input, string expected)
    {
        var sut = new ManacherAlgorithm();
        var output = sut.LongestPalindrome(input);
        output.Should().Be(expected);
    }
}