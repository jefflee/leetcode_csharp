using System.Collections;
using System.Text;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/zigzag-conversion/description/
///     6. Zigzag Conversion
///     Refer to this solution, because it is better than mine.
///     https://leetcode.com/problems/zigzag-conversion/solutions/4387201/zigzag-conversion-decoded-code-in-c-java-python-c-js/
/// </summary>
internal class ZigzagConversionSolution
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1)
        {
            return s;
        }

        IList<char[]> resultList = new List<char[]>();
        char? c = s[0];
        var x = 0;
        var index = 0;
        while (index < s.Length)
        {
            if (x % (numRows - 1) == 0)
            {
                var cAry = new char[numRows];
                for (var i = 0; i < numRows; i++)
                {
                    cAry[i] = index < s.Length ? s[index] : '@';
                    index++;
                }

                resultList.Add(cAry);
            }
            else
            {
                var cAry = new char[numRows];
                for (var i = 0; i < numRows; i++)
                {
                    if (i == numRows - 1 - x % (numRows - 1))
                    {
                        cAry[i] = index < s.Length ? s[index] : '@';
                        index++;
                    }
                    else
                    {
                        cAry[i] = '@';
                    }
                }

                resultList.Add(cAry);
            }

            x++;
        }

        var sb = new StringBuilder(s.Length);
        for (var i = 0; i < numRows; i++)
        {
            foreach (var ary in resultList)
            {
                if (ary[i] != '@')
                {
                    sb.Append(ary[i]);
                }
            }
        }

        return sb.ToString();
    }
}

internal class ZigzagConversionTest
{
    [TestCaseSource(typeof(TestCases))]
    public void ZigzagConversionSolutionTest(string s, int numRows, string expected)
    {
        var sut = new ZigzagConversionSolution();
        var output = sut.Convert(s, numRows);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { "PAYPALISHIRING", 3, "PAHNAPLSIIGYIR" };
            yield return new object?[] { "PAYPALISHIRING", 4, "PINALSIGYAHRPI" };
            yield return new object?[] { "A", 1, "A" };
        }
    }
}