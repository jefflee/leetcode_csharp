using System.Collections;

namespace LeetCodeNUnitTest.DpProblems;

/// <summary>
///     https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/?envType=study-plan-v2&amp;envId=top-interview-150
///     122. Best Time to Buy and Sell Stock II
/// </summary>
internal class BestTimeToBuyAndSellStock2
{
    /// <summary>
    ///     Dynamic Programming.
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public int MaxProfit(int[] prices)
    {
        if (prices.Length <= 1)
        {
            return 0;
        }

        var currentProfile = 0;
        for (var k = 1; k < prices.Length; k++)
        {
            var p = prices[k] - prices[k - 1];
            if (p > 0)
            {
                currentProfile += p;
            }
        }

        return currentProfile;
    }
}

internal class BestTimeToBuyAndSellStock2Test
{
    [TestCaseSource(typeof(TestCases))]
    public void BestTimeToBuyAndSellStock2SolutionTest(int[] prices, int profit)
    {
        var sut = new BestTimeToBuyAndSellStock2();
        var output = sut.MaxProfit(prices);
        output.Should().Be(profit);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 7, 1, 5, 3, 6, 4 }, 7 };
            yield return new object?[] { new[] { 1, 2, 3, 4, 5 }, 4 };
            yield return new object?[] { new[] { 7, 6, 4, 3, 1 }, 0 };
        }
    }
}