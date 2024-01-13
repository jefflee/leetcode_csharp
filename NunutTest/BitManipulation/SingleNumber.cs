using System.Collections;

namespace LeetCodeNUnitTest.BitManipulation;

/// <summary>
///     https://leetcode.com/problems/single-number/description
///     136. Single Number
///     Check this for the bet solution
///     \leetcode_csharp\HackerRankUNitTest\LonleyInteger.cs
/// </summary>
internal class SingleNumberSolution
{
    public int SingleNumber(int[] nums)
    {
        return nums.GroupBy(p => p)
            .Where(p => p.Count() == 1)
            .Select(p => p.Key)
            .First();
    }
}

internal class SingleNumberTest
{
    [TestCaseSource(typeof(TestCases))]
    public void SingleNumberSolutionTest(int[] nums, int expected)
    {
        var sut = new SingleNumberSolution();
        var output = sut.SingleNumber(nums);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 2, 2, 1 }, 1 };
            yield return new object?[] { new[] { 4, 1, 2, 1, 2 }, 4 };
            yield return new object?[] { new[] { 1 }, 1 };
        }
    }
}