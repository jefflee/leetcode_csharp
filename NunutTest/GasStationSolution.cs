using System.Collections;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/gas-station/description/
///     134. Gas Station
///     Solution:
///     https://leetcode.com/problems/gas-station/solutions/3011277/c-153-ms/
/// </summary>
internal class GasStationSolution
{
    /// <summary>
    ///     Start from the end to the beginning; sum up each (gas - cost), figure out the index of the maximum.
    ///     If the sum is less than zero, you can't get there from here.
    ///     Otherwise, the answer is the index with the maximum sum.
    /// </summary>
    /// <param name="gas"></param>
    /// <param name="cost"></param>
    /// <returns></returns>
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        var sum = gas[^1] - cost[^1];
        var maxIndex = gas.Length - 1;
        var maxSum = sum;

        for (var i = gas.Length - 2; i >= 0; i--)
        {
            sum += gas[i] - cost[i];
            if (sum > maxSum)
            {
                maxIndex = i;
                maxSum = sum;
            }
        }

        if (sum < 0) return -1;
        return maxIndex;
    }
}

internal class GasStationTest
{
    [TestCaseSource(typeof(TestCases))]
    public void GasStationSolutionTest(int[] gas, int[] cost, int gasStationIndex)
    {
        var sut = new GasStationSolution();
        var output = sut.CanCompleteCircuit(gas, cost);
        output.Should().Be(gasStationIndex);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 1, 2, 3, 4, 5 }, new[] { 3, 4, 5, 1, 2 }, 3 };
            yield return new object?[] { new[] { 2, 3, 4 }, new[] { 3, 4, 3 }, -1 };
            yield return new object?[] { new[] { 2 }, new[] { 2 }, 0 };
            yield return new object?[] { new[] { 4, 5, 2, 6, 5, 3 }, new[] { 3, 2, 7, 3, 2, 9 }, -1 };
            yield return new object?[] { new[] { 5, 1, 2, 3, 4 }, new[] { 4, 4, 1, 5, 1 }, 4 };
        }
    }
}