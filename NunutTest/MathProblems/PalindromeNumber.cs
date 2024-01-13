using System.Collections;

namespace LeetCodeNUnitTest.MathProblems;

/// <summary>
///     https://leetcode.com/problems/palindrome-number/description/
///     9. Palindrome Number
/// </summary>
internal class PalindromeNumberSolution
{
    public bool IsPalindrome(int x)
    {
        var input = x.ToString();
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
///     Beautiful, but slow.
///     https://leetcode.com/problems/palindrome-number/solutions/3010225/c-3-line-solution-faster-than-99-65-explained/
/// </summary>
internal class PalindromeNumberLinqSolution
{
    public bool IsPalindrome(int x)
    {
        return string.Concat(x.ToString().Reverse()) == x.ToString();
    }
}

internal class PalindromeNumberTest
{
    [TestCaseSource(typeof(TestCases))]
    public void PalindromeNumberSolutionTest(int number, bool isPalindrome)
    {
        var sut = new PalindromeNumberSolution();
        var output = sut.IsPalindrome(number);
        output.Should().Be(isPalindrome);
    }

    [TestCaseSource(typeof(TestCases))]
    public void PalindromeNumberLinqSolutionTest(int number, bool isPalindrome)
    {
        var sut = new PalindromeNumberLinqSolution();
        var output = sut.IsPalindrome(number);
        output.Should().Be(isPalindrome);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { 121, true };
            yield return new object?[] { -121, false };
            yield return new object?[] { 10, false };
        }
    }
}