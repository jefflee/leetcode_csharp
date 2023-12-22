using System.Collections;

namespace LeetCodeNUnitTest;

/// <summary>
///     121. Best Time to Buy and Sell Stock
///     https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/?envType=study-plan-v2&amp;
///     envId=top-interview-150
///     Solutions:
///     https://leetcode.com/problems/best-time-to-buy-and-sell-stock/solutions/39038/kadane-s-algorithm-since-no-one-has-mentioned-about-this-so-far-in-case-if-interviewer-twists-the-input/?envType=study-plan-v2
///     &amp;envId=top-interview-150
/// </summary>
internal class BestTimeToBuyAndSellStockSolution
{
    public int MaxProfit(int[] prices)
    {
        var min = prices[0];
        var maxProfit = 0;

        for (var k = 1; k < prices.Length; k++)
        {
            if (prices[k] > min && prices[k] - min > maxProfit)
            {
                maxProfit = prices[k] - min;
                continue;
            }

            if (prices[k] < min)
            {
                min = prices[k];
            }
        }

        return maxProfit;
    }
}

internal class BestTimeToBuyAndSellStockDynamicProgrammingSolution
{
    public int MaxProfit(int[] prices)
    {
        int maxCur = 0, maxSoFar = 0;
        for (var i = 1; i < prices.Length; i++)
        {
            maxCur = Math.Max(0, maxCur += prices[i] - prices[i - 1]);
            maxSoFar = Math.Max(maxCur, maxSoFar);
        }

        return maxSoFar;
    }
}

internal class BestTimeToBuyAndSellStockTest
{
    [TestCaseSource(typeof(TestCases))]
    public void BestTimeToBuyAndSellStockSolutionTest(int[] prices, int profit)
    {
        var sut = new BestTimeToBuyAndSellStockSolution();
        var output = sut.MaxProfit(prices);
        output.Should().Be(profit);
    }

    [TestCaseSource(typeof(TestCases))]
    public void DynamicProgrammingSolutionTest(int[] prices, int profit)
    {
        var sut = new BestTimeToBuyAndSellStockDynamicProgrammingSolution();
        var output = sut.MaxProfit(prices);
        output.Should().Be(profit);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 7, 1, 5, 3, 6, 4 }, 5 };
            yield return new object?[] { new[] { 7, 6, 4, 3, 1 }, 0 };
            yield return new object?[] { new[] { 2, 4, 1 }, 2 };
        }
    }
}