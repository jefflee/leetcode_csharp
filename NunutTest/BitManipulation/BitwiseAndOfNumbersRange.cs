using System.Collections;

namespace LeetCodeNUnitTest.BitManipulation;

/// <summary>
///     https://leetcode.com/problems/bitwise-and-of-numbers-range/description/
///     201. Bitwise AND of Numbers Range
///     Solution
///     https://leetcode.com/problems/bitwise-and-of-numbers-range/solutions/593317/simple-3-line-java-solution-faster-than-100/
/// </summary>
internal class BitwiseAndOfNumbersRangeSolution
{
    public int RangeBitwiseAnd(int left, int right)
    {
        var result = right;
        while (result > left)
        {
            result &= result - 1;
        }

        return result;
    }
}

internal class BitwiseAndOfNumbersRangeTest
{
    [TestCaseSource(typeof(TestCases))]
    public void BitwiseAndOfNumbersRangeSolutionTest(int left, int right, int expected)
    {
        var sut = new BitwiseAndOfNumbersRangeSolution();
        var output = sut.RangeBitwiseAnd(left, right);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { 5, 7, 4 };
            yield return new object?[] { 0, 0, 0 };
            yield return new object?[] { 1, 2147483647, 0 };
            yield return new object?[] { 0, 1, 0 };
            yield return new object?[] { 2147483646, 2147483647, 2147483646 };
        }
    }
}