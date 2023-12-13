using System.Collections;
using System.Collections.Generic;
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
        if (s.Length <= 1) return s;

        var maxPalindrome = s[0].ToString();
        for (var k = 0; k < s.Length; k++)
        for (var o = k + maxPalindrome.Length; o < s.Length; o++)
        {
            var subString = s[k..(o + 1)];
            if (IsPalindrome(subString) && subString.Length > maxPalindrome.Length) maxPalindrome = subString;
        }

        return maxPalindrome;
    }

    private static bool IsPalindrome(string input)
    {
        for (var k = 0; k < input.Length / 2; k++)
            if (input[k] != input[^(k + 1)])
                return false;

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

        // Insert # between each char, then the array length is odd.
        var reformattedString = $"#{string.Join('#', s.ToCharArray())}#";
        var maxPalindrome = reformattedString[..1];
        var maxPalindromeLength = 0;

        for (var k = 1; k < reformattedString.Length; k++)
        {
            var palindromeLength = 0;
            while (k - palindromeLength - 1 >= 0 && k + palindromeLength + 1 < reformattedString.Length &&
                   reformattedString[k - palindromeLength - 1] == reformattedString[k + palindromeLength + 1])
            {
                palindromeLength++;
            }

            // Compare with previous result
            if (palindromeLength > maxPalindromeLength)
            {
                maxPalindromeLength = palindromeLength;
                maxPalindrome = reformattedString[(k - maxPalindromeLength)..(k + maxPalindromeLength + 1)];
            }
        }

        return maxPalindrome.Replace("#", string.Empty);
    }
}

/// <summary>
///     https://leetcode.com/problems/longest-palindromic-substring/editorial/
///     https://leetcode.com/problems/longest-palindromic-substring/solutions/4212564/beats-96-49-5-different-approaches-brute-force-eac-dp-ma-recursion/
/// </summary>
internal class DynamicProgramming
{
    public string LongestPalindrome(string s)
    {
        var dp = new bool[s.Length, s.Length];
        var ans = new List<int> { 0, 0 };

        for (var k = 0; k < s.Length; k++)
        {
            // set s[k,k] to true, because substring s[k] is Palindrome
            dp[k, k] = true;

            // For string length is even.
            // Check s[k] s[k+1], if they are the same.
            if (k + 1 < s.Length && s[k] == s[k + 1])
            {
                dp[k, k + 1] = true;
                ans[0] = k;
                ans[1] = k + 1;
            }
        }

        // string from palindromeLength 2
        for (var palindromeLength = 2; palindromeLength < s.Length; palindromeLength++)
        {
            for (var i = 0; i < s.Length - palindromeLength; i++)
            {
                var j = i + palindromeLength;
                // The most importance of DP.
                // if the outer char is the same and its inner substring is Palindrome
                if (s[i] == s[j] && dp[i + 1, j - 1])
                {
                    dp[i, j] = true;
                    ans[0] = i;
                    ans[1] = j;
                }
            }
        }

        return s[ans[0]..(ans[1] + 1)];
    }
}

public class LongestPalindromicSubstringTest
{
    [TestCaseSource(typeof(TestCases))]
    public void LongestPalindromicSubstringSolution1Test(string input, string expected1, string? expected2)
    {
        var sut = new LongestPalindromicSubstringSolution1();
        var output = sut.LongestPalindrome(input);
        output.Should().BeOneOf(expected1, expected2);
    }

    [TestCaseSource(typeof(TestCases))]
    public void ManacherAlgorithmTest(string input, string expected1, string? expected2)
    {
        var sut = new ManacherAlgorithm();
        var output = sut.LongestPalindrome(input);
        output.Should().BeOneOf(expected1, expected2);
    }

    [TestCaseSource(typeof(TestCases))]
    public void DynamicProgrammingTest(string input, string expected1, string? expected2)
    {
        var sut = new DynamicProgramming();
        var output = sut.LongestPalindrome(input);
        output.Should().BeOneOf(expected1, expected2);
    }
}

public class TestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { "babad", "bab", "aba" };
        yield return new object[] { "cbbd", "bb", null };
        yield return new object[] { "aaaaa", "aaaaa", null };
        yield return new object[] { "abc1cba", "abc1cba", null };
        yield return new object[] { "1qaabc1cbazxc", "abc1cba", null };
    }
}