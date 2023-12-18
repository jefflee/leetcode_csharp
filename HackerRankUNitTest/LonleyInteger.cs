using System.Collections;

namespace HackerRankUNitTest;

/// <summary>
///     https://www.hackerrank.com/challenges/one-week-preparation-kit-lonely-integer/problem
/// </summary>
internal class BruteForceSolution
{
    public int Lonelyinteger(List<int> a)
    {
        var countDic = new Dictionary<int, int>();
        foreach (var num in a)
        {
            if (countDic.ContainsKey(num))
            {
                countDic[num] += 1;
            }
            else
            {
                countDic[num] = 1;
            }
        }

        foreach (var entry in countDic)
        {
            if (entry.Value == 1)
            {
                return entry.Key;
            }
        }

        return 0;
    }
}

internal class XorSolution
{
    public int Lonelyinteger(List<int> a)
    {
        var ans = 0;
        foreach (var number in a)
        {
            ans = ans ^ number;
        }

        return ans;
    }
}

internal class LonleyIntegerTest
{
    [TestCaseSource(typeof(TestCases))]
    public void BruteForceSolutionTest(List<int> numbers, int expectedNumber)
    {
        var sut = new BruteForceSolution();
        var output = sut.Lonelyinteger(numbers);
        output.Should().Be(expectedNumber);
    }

    [TestCaseSource(typeof(TestCases))]
    public void XorSolutionTest(List<int> numbers, int expectedNumber)
    {
        var sut = new XorSolution();
        var output = sut.Lonelyinteger(numbers);
        output.Should().Be(expectedNumber);
    }
}

public class TestCases : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new object?[] { new List<int> { 1, 2, 3, 4, 3, 2, 1 }, 4 };
    }
}