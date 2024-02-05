using System.Collections;

namespace LeetCodeNUnitTest.DpProblems;

/// <summary>
///     https://leetcode.com/problems/longest-increasing-subsequence/description/
///     300. Longest Increasing Subsequence
///     Solution
///     https://leetcode.com/problems/longest-increasing-subsequence/solutions/4512773/c-dp-and-binary-search-with-explanation/
///     The below solution is hard. It uses Patience Sorting Algorithm.
///     https://leetcode.com/problems/longest-increasing-subsequence/solutions/4516519/c-solution-for-longest-increasing-subsequence-problem/
/// </summary>
internal class LongestIncreasingSubsequenceSolution
{
    public int LengthOfLIS(int[] nums)
    {
        var n = nums.Length;
        if (n <= 1)
        {
            return n;
        }

        // lis array keeps track of what is idx of i-th element in longest subseq in which it is present
        // for any single digit, Length of LIS will be just 1
        var lis = Enumerable.Repeat(1, n).ToArray();

        var max = 1;
        for (var i = 1; i < n; i++)
        {
            for (var j = 0; j < i; j++)
            {
                // if nums[i] is greater than nums[j] 
                // and i is currently part of a different subseq where len(i's subseq) <= len(j's subseq)
                // then we add i to the same subsequence as j
                if (nums[i] > nums[j] && lis[i] <= lis[j])
                {
                    lis[i] = lis[j] + 1;
                    max = Math.Max(max, lis[i]);
                }
            }
        }

        return max;
    }
}

internal class LongestIncreasingSubsequenceTest
{
    [TestCaseSource(typeof(TestCases))]
    public void LongestIncreasingSubsequenceSolutionTest(int[] nums, int expected)
    {
        var sut = new LongestIncreasingSubsequenceSolution();
        var output = sut.LengthOfLIS(nums);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4 };
            yield return new object?[] { new[] { 0, 1, 0, 3, 2, 3 }, 4 };
            yield return new object?[] { new[] { 7, 7, 7, 7, 7, 7, 7 }, 1 };
        }
    }
}