using System.Collections;

namespace LeetCodeNUnitTest.MathProblems;

/// <summary>
///     https://leetcode.com/problems/plus-one/description/
///     66. Plus One
///     The other option is using recursion.
///     https://leetcode.com/problems/plus-one/solutions/4517705/99-5-wondreful-recursion-solution/
/// </summary>
internal class PlusOneSolution
{
    public int[] PlusOne(int[] digits)
    {
        var carry = 1;
        IList<int> result = new List<int>(digits);
        var index = digits.Length - 1;
        while (index >= 0)
        {
            if (result[index] == 9)
            {
                result[index] = 0;
            }
            else
            {
                result[index] += 1;
                carry = 0;
                break;
            }

            index--;
        }

        if (carry == 1)
        {
            result.Insert(0, 1);
        }

        return result.ToArray();
    }
}

internal class PlusOneTest
{
    [TestCaseSource(typeof(TestCases))]
    public void PlusOneSolutionTest(int[] digits, int[] expected)
    {
        var sut = new PlusOneSolution();
        var output = sut.PlusOne(digits);
        output.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }


    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 1, 2, 3 }, new[] { 1, 2, 4 } };
            yield return new object?[] { new[] { 4, 3, 2, 1 }, new[] { 4, 3, 2, 2 } };
            yield return new object?[] { new[] { 9 }, new[] { 1, 0 } };
        }
    }
}