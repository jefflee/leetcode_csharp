using System.Collections;

namespace LeetCodeNUnitTest.DpProblems;

/// <summary>
///     https://leetcode.com/problems/maximum-subarray/description/
///     50. Maximum Subarray
///     Dynamic Programming
/// </summary>
internal class MaximumSubarrayDpsolution
{
    public int MaxSubArray(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        var maxSum = nums[0];
        var ans = nums[0];

        for (var k = 1; k < nums.Length; k++)
        {
            var summedMax = nums[k] + maxSum;
            maxSum = Math.Max(nums[k], summedMax);

            ans = Math.Max(ans, maxSum);
        }

        return ans;
    }
}

public class MaximumSubarrayTest
{
    [TestCaseSource(typeof(TestCases))]
    public void MaximumSubarrayDpsolutionTest(int[] nums, int expected)
    {
        var sut = new MaximumSubarrayDpsolution();
        var output = sut.MaxSubArray(nums);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 2, 3, -2, 4 }, 7 };
            yield return new object?[] { new[] { -2, 0, -1 }, 0 };
            yield return new object?[] { new[] { -2, 0, -1, -3 }, 0 };
            yield return new object?[] { new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6 };
            yield return new object?[] { new[] { 5, 4, -1, 7, 8 }, 23 };
            yield return new object?[] { new[] { 1 }, 1 };
        }
    }
}