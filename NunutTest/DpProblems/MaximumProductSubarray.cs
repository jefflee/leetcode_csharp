using System;
using System.Collections;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeNUnitTest.DpProblems;

/// <summary>
///     152. MaximumProductSubarray
///     https://leetcode.com/problems/maximum-product-subarray/description/
///     https://medium.com/%E6%8A%80%E8%A1%93%E7%AD%86%E8%A8%98/%E6%BC%94%E7%AE%97%E6%B3%95%E7%AD%86%E8%A8%98%E7%B3%BB%E5%88%97-dynamic-programming-%E5%8B%95%E6%85%8B%E8%A6%8F%E5%8A%83-de980ca4a2d3
/// </summary>
internal class DynamicProgrammingSolution
{
    public int MaxProduct(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        var maxProduct = nums[0];
        var minProduct = maxProduct;
        var ans = nums[0];

        for (var k = 1; k < nums.Length; k++)
        {
            var multipliedMax = nums[k] * maxProduct;
            var multipliedMin = nums[k] * minProduct;
            maxProduct = Math.Max(nums[k], Math.Max(multipliedMax, multipliedMin));
            minProduct = Math.Min(nums[k], Math.Min(multipliedMax, multipliedMin));

            ans = Math.Max(ans, maxProduct);
        }

        return ans;
    }
}

/// <summary>
///     https://leetcode.com/problems/maximum-product-subarray/solutions/3321410/c-kadane-s-algo-full-explanation/
/// </summary>
internal class TraversingTwiceSolution
{
    public int MaxProduct(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        // From left to right
        var maxLeftToRight = 0;
        var product = 1;

        for (var k = 0; k < nums.Length; k++)
        {
            product = nums[k] * product;
            maxLeftToRight = Math.Max(product, maxLeftToRight);
            if (product == 0)
            {
                product = 1;
            }
        }

        // From right to left
        var maxRightToLeft = 0;
        product = 1;
        for (var k = nums.Length - 1; k >= 0; k--)
        {
            product = product * nums[k];
            maxRightToLeft = Math.Max(product, maxRightToLeft);

            if (product == 0)
            {
                product = 1;
            }
        }

        return Math.Max(maxLeftToRight, maxRightToLeft);
    }
}

public class MaximumProductSubarrayTest
{
    [TestCaseSource(typeof(TestCases))]
    public void DynamicProgrammingSolutionTest(int[] nums, int numOfWays)
    {
        var sut = new DynamicProgrammingSolution();
        var output = sut.MaxProduct(nums);
        output.Should().Be(numOfWays);
    }

    [TestCaseSource(typeof(TestCases))]
    public void TraversingTwiceSolutionTest(int[] nums, int numOfWays)
    {
        var sut = new TraversingTwiceSolution();
        var output = sut.MaxProduct(nums);
        output.Should().Be(numOfWays);
    }
}

public class TestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object?[] { new[] { 2, 3, -2, 4 }, 6 };
        yield return new object?[] { new[] { -2, 0, -1 }, 0 };
        yield return new object?[] { new[] { -2, 0, -1, -3 }, 3 };
    }
}