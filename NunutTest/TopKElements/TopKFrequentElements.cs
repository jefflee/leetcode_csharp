using System.Collections;

namespace LeetCodeNUnitTest.TopKElements;

/// <summary>
///     https://leetcode.com/problems/top-k-frequent-elements/description/
///     347. Top K Frequent Elements
///     Solution
///     https://leetcode.com/problems/top-k-frequent-elements/editorial/
///     https://leetcode.com/problems/top-k-frequent-elements/solutions/3948343/c-best-2-solutions-bucket-sort-priority-queue/
/// </summary>
internal class TopKFrequentElementsSolution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        return nums.GroupBy(x => x)
            .OrderByDescending(p => p.Count())
            .Take(k)
            .Select(p => p.Key)
            .ToArray();
    }
}

internal class TopKFrequentElementsPriorityQueueSolution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var goups = nums.GroupBy(x => x).ToList();
        var maxHeap =
            new PriorityQueue<int, int>();
        foreach (var group in goups)
        {
            maxHeap.Enqueue(group.Key, group.Count());
            if (maxHeap.Count > k)
            {
                maxHeap.Dequeue();
            }
        }

        var result = new int[maxHeap.Count];
        var i = 0;
        while (maxHeap.TryDequeue(out var e, out _))
        {
            result[i] = e;
            i++;
        }

        return result;
    }

    private class IntMaxCompare : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }
}

internal class TopKFrequentElementsTest
{
    [TestCaseSource(typeof(TestCases))]
    public void TopKFrequentElementsSolutionTest(int[] nums, int k, int[] expected)
    {
        var sut = new TopKFrequentElementsSolution();
        var output = sut.TopKFrequent(nums, k);
        output.Should().BeEquivalentTo(expected);
    }

    [TestCaseSource(typeof(TestCases))]
    public void TopKFrequentElementsPriorityQueueSolutionTest(int[] nums, int k, int[] expected)
    {
        var sut = new TopKFrequentElementsPriorityQueueSolution();
        var output = sut.TopKFrequent(nums, k);
        output.Should().BeEquivalentTo(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 1, 1, 1, 2, 2, 3 }, 2, new[] { 1, 2 } };
            yield return new object?[] { new[] { 1 }, 1, new[] { 1 } };
            yield return new object?[] { new[] { 1, 2 }, 2, new[] { 1, 2 } };
        }
    }
}