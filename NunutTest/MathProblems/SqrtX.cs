using System.Collections;

namespace LeetCodeNUnitTest.MathProblems;

/// <summary>
///     https://leetcode.com/problems/sqrtx/description/
///     69. Sqrt(x)
///     Another solution
///     https://leetcode.com/problems/sqrtx/solutions/3706594/easy-explained-solution-beats-100/
/// </summary>
internal class SqrtXSolution
{
    public int MySqrt(int x)
    {
        var exponent = 0;
        for (var k = 0; k < 46341; k++)
        {
            if (k * k > x)
            {
                break;
            }

            exponent = k;
        }

        return exponent;
    }
}

internal class SqrtXTest
{
    [TestCaseSource(typeof(TestCases))]
    public void SqrtXSolutionTest(int x, int exponent)
    {
        var sut = new SqrtXSolution();
        var output = sut.MySqrt(x);
        output.Should().Be(exponent);
    }


    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { 4, 2 };
            yield return new object?[] { 8, 2 };
            yield return new object?[] { 1024, 32 };
        }
    }
}