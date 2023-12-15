using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeNUnitTest.DpProblems;

/// <summary>
///     https://leetcode.com/problems/climbing-stairs/description/
///     https://medium.com/%E6%8A%80%E8%A1%93%E7%AD%86%E8%A8%98/%E6%BC%94%E7%AE%97%E6%B3%95%E7%AD%86%E8%A8%98%E7%B3%BB%E5%88%97-dynamic-programming-%E5%8B%95%E6%85%8B%E8%A6%8F%E5%8A%83-de980ca4a2d3
/// </summary>
internal class ClimbingStairsSolution
{
    /// <summary>
    ///     This is a Fibonacci sequence problem.
    ///     F(n-1) + 1 step to reach F(n)
    ///     F(n-2) + 2 steps to reach F(n)
    ///     So, F(n) = F(n-1) + F(n-2)
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int ClimbStairs(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        var n1 = 1;
        var n2 = 1;
        var numOfWays = 0;

        for (var k = 2; k <= n; k++)
        {
            numOfWays = n1 + n2;
            n1 = n2;
            n2 = numOfWays;
        }

        return numOfWays;
    }
}

public class ClimbingStairsTest
{
    [TestCase(2, 2)]
    [TestCase(3, 3)]
    [TestCase(4, 5)]
    public void ClimbingStairsSolutionTest(int nStairs, int numOfWays)
    {
        var sut = new ClimbingStairsSolution();
        var output = sut.ClimbStairs(nStairs);
        output.Should().BeOneOf(nStairs, numOfWays);
    }
}