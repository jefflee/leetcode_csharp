using System.Collections;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/number-of-1-bits/description
///     191. Number of 1 Bits
/// </summary>
internal class NumberOf1BitsSolution
{
    public int HammingWeight(uint n)
    {
        return Convert.ToString(n, 2).Count(bit => bit == '1');
    }
}

internal class NumberOf1BitsTest
{
    [TestCaseSource(typeof(TestCases))]
    public void NumberOf1BitsSolutionTest(uint n, int expected)
    {
        var sut = new NumberOf1BitsSolution();
        var output = sut.HammingWeight(n);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { 0b_00000000000000000000000000001011u, 3 };
            yield return new object?[] { 0b_00000000000000000000000010000000u, 1 };
            yield return new object?[] { 0b_11111111111111111111111111111101u, 31 };
        }
    }
}