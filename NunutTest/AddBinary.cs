using System.Collections;
using System.Text;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/add-binary/description/
///     67. Add Binary
/// </summary>
internal class AddBinarySolution
{
    public string AddBinary(string a, string b)
    {
        var maxLength = Math.Max(a.Length, b.Length);
        var result = new StringBuilder();
        var carry = 0;
        for (var i = 0; i < maxLength; i++)
        {
            var aIndex = a.Length - 1 - i;
            var bIndex = b.Length - 1 - i;
            var aChar = aIndex >= 0 ? a[aIndex] : '0';
            var bChar = bIndex >= 0 ? b[bIndex] : '0';
            //var sum = aChar - '0' + (bChar - '0') + carry;
            var sum = aChar - '0' + (bChar - '0') + carry;
            carry = sum / 2;
            result.Insert(0, sum % 2);
        }

        if (carry > 0)
        {
            result.Insert(0, carry);
        }

        return result.ToString();
    }
}

internal class AddBinaryTest
{
    [TestCaseSource(typeof(TestCases))]
    public void AddBinarySolutionTest(string a, string b, string expected)
    {
        var sut = new AddBinarySolution();
        var output = sut.AddBinary(a, b);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { "11", "1", "100" };
            yield return new object?[] { "1010", "1011", "10101" };
        }
    }
}