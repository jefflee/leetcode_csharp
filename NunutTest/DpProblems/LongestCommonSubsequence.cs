using System.Collections;

namespace LeetCodeNUnitTest.DpProblems;

/// <summary>
///     https://leetcode.com/problems/longest-common-subsequence/description/
///     1143. Longest Common Subsequence
///     Solution
///     https://leetcode.com/problems/longest-common-subsequence/solutions/4649482/fastest-in-c-dp-bottom-up-easy-explaination-with-tables/
/// </summary>
internal class LongestCommonSubsequenceSolution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        var m = text1.Length;
        var n = text2.Length;
        var table = new int[text1.Length + 1, text2.Length + 1];
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                table[i + 1, j + 1] =
                    text1[i] == text2[j] ? table[i, j] + 1 : Math.Max(table[i + 1, j], table[i, j + 1]);
            }
        }

        return table[m, n];
    }
}

internal class LongestCommonSubsequenceTest
{
    [TestCaseSource(typeof(TestCases))]
    public void LongestCommonSubsequenceSolutionTest(string text1, string text2, int expected)
    {
        var sut = new LongestCommonSubsequenceSolution();
        var output = sut.LongestCommonSubsequence(text1, text2);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { "abcde", "ace", 3 };
            yield return new object?[] { "abc", "abc", 3 };
            yield return new object?[] { "abc", "def", 0 };
        }
    }
}