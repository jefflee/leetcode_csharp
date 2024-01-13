using System.Collections;

namespace LeetCodeNUnitTest.BitManipulation;

/// <summary>
///     https://leetcode.com/problems/single-number-ii/description/
///     137. Single Number II
/// </summary>
internal class SingleNumber2Solution
{
    public int SingleNumber(int[] nums)
    {
        return nums.GroupBy(p => p)
            .Where(p => p.Count() < 2)
            .Select(p => p.Key)
            .First();
    }
}

internal class SingleNumber2Test
{
    [TestCaseSource(typeof(TestCases))]
    public void SingleNumber2SolutionTest(int[] nums, int expected)
    {
        var sut = new SingleNumber2Solution();
        var output = sut.SingleNumber(nums);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 2, 2, 3, 2 }, 3 };
            yield return new object?[] { new[] { 0, 1, 0, 1, 0, 1, 99 }, 99 };
        }
    }
}