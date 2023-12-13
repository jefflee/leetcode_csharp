using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCodeNUnitTest
{
    /// <summary>
    ///     https://leetcode.com/problems/minimize-deviation-in-array/
    /// </summary>
    public class MinimumDeviationSolution1
    {
        public int MinimumDeviation(int[] nums)
        {
            // multiply every odd number by 2; leave the evens alone
            var sortedSet = new SortedSet<int>(nums.Select(x => 1 == (x & 1) ? x * 2 : x));

            var minDeviation = sortedSet.Max - sortedSet.Min;

            while (true)
            {
                var max = sortedSet.Max;

                if (0 != (max & 1))
                {
                    break; // if we can't reduce the maximum, we are done
                }

                sortedSet.Remove(max);
                sortedSet.Add(max / 2);

                minDeviation = Math.Min(minDeviation, sortedSet.Max - sortedSet.Min);
            }

            //Console.WriteLine(string.Join(',', sortedSet));
            return minDeviation;
        }
    }

    public class MinimumDeviationTest
    {
        [TestCase(new[] { 1, 2, 3, 4 }, 1)]
        [TestCase(new[] { 4, 1, 5, 20, 3 }, 3)]
        [TestCase(new[] { 2, 10, 8 }, 3)]
        [TestCase(new[] { 3, 5 }, 1)]
        [TestCase(new[] { 10, 4, 3 }, 2)]
        [TestCase(new[] { 399, 908, 648, 357, 693, 502, 331, 649, 596, 698 }, 315)]
        public void TestSolution1(int[] nums, int expectedDeviation)
        {
            var result = new MinimumDeviationSolution1().MinimumDeviation(nums);

            result.Should().Be(expectedDeviation);
        }
    }
}