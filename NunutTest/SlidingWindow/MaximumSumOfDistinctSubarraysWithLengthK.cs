using System.Collections;

namespace LeetCodeNUnitTest.SlidingWindow;

/// <summary>
///     https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k/description/
///     2461. Maximum Sum of Distinct Subarrays With Length K
/// </summary>
internal class MaximumSumOfDistinctSubArraysWithLengthKSolution
{
    public long MaximumSubarraySum(int[] nums, int k)
    {
        var dic = new Dictionary<int, int>();
        long sum = 0;
        long maxSum = 0;

        // sliding window
        for (int i = 0, j = 0; j < nums.Length; j++)
        {
            AddToDictionary(nums, dic, j);

            sum += nums[j];

            if (j - i + 1 == k)
            {
                if (dic.Keys.Count == k)
                {
                    maxSum = Math.Max(maxSum, sum);
                }

                RemoveFromDictionary(nums, dic, i);

                sum -= nums[i];
                i++;
            }
        }

        return maxSum;
    }

    private static void RemoveFromDictionary(int[] nums, Dictionary<int, int> dic, int i)
    {
        if (dic[nums[i]] == 1)
        {
            dic.Remove(nums[i]);
        }
        else
        {
            dic[nums[i]] -= 1;
        }
    }

    private static void AddToDictionary(int[] nums, Dictionary<int, int> dic, int j)
    {
        if (dic.ContainsKey(nums[j]))
        {
            dic[nums[j]] += 1;
        }
        else
        {
            dic.Add(nums[j], 1);
        }
    }
}

internal class MaximumSumOfDistinctSubArraysWithLengthKTest
{
    [TestCaseSource(typeof(TestCases))]
    public void MaximumSumOfDistinctSubArraysWithLengthKSolutionTest(int[] nums, int k, long expected)
    {
        var sut = new MaximumSumOfDistinctSubArraysWithLengthKSolution();
        var output = sut.MaximumSubarraySum(nums, k);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 1, 5, 4, 2, 9, 9, 9 }, 3, 15 };
            yield return new object?[] { new[] { 4, 4, 4 }, 3, 0 };
            yield return new object?[] { new[] { 1, 2, 2 }, 2, 3 };
            yield return new object?[] { new[] { 9, 9, 9, 1, 2, 3 }, 3, 12 };
        }
    }
}