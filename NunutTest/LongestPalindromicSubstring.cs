using System.Collections;
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
        if (s.Length <= 1) return s;

        // Insert # between each char
        var reformattedString = $"#{string.Join('#', s.ToCharArray())}#";
        var maxPalindrome = reformattedString[..1];
        var maxPalindromeLength = 0;

        for (var k = 1; k < reformattedString.Length; k++)
        {
            var palindromeLength = maxPalindromeLength;
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

public class LongestPalindromicSubstringTest
{
    [TestCaseSource(typeof(TestCases))]
    public void LongestPalindromicSubstringSolution1Test(string input, string expected)
    {
        var sut = new LongestPalindromicSubstringSolution1();
        var output = sut.LongestPalindrome(input);
        output.Should().Be(expected);
    }

    [TestCaseSource(typeof(TestCases))]
    public void ManacherAlgorithmTest(string input, string expected)
    {
        var sut = new ManacherAlgorithm();
        var output = sut.LongestPalindrome(input);
        output.Should().Be(expected);
    }
}

public class TestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object[] { "babad", "bab" };
        yield return new object[] { "cbbd", "bb" };
        yield return new object[] { "abc1cba", "abc1cba" };
        yield return new object[] { "1qaabc1cbazxc", "abc1cba" };
    }
}