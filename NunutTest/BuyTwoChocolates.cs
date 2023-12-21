using System.Collections;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/buy-two-chocolates/description/
///     2706. Buy Two Chocolates
/// </summary>
internal class BuyTwoChocolatesSolution
{
    public int BuyChoco(int[] prices, int money)
    {
        var min = 100;
        var secondMin = 100;
        foreach (var price in prices)
        {
            if (price < min)
            {
                secondMin = min;
                min = price;
            }
            else if (price < secondMin)
            {
                secondMin = price;
            }
        }

        var twoChocolatesPrice = min + secondMin;
        return money < twoChocolatesPrice ? money : money - twoChocolatesPrice;
    }
}

internal class BuyTwoChocolatesTest
{
    [TestCaseSource(typeof(TestCases))]
    public void BuyChocoSolutionTest(int[] prices, int money, int expected)
    {
        var sut = new BuyTwoChocolatesSolution();
        var output = sut.BuyChoco(prices, money);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 1, 2, 2 }, 3, 0 };
            yield return new object?[] { new[] { 3, 2, 3 }, 3, 3 };
        }
    }
}