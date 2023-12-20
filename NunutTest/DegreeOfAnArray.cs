using System.Collections;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/degree-of-an-array/description/
///     697. Degree of an Array
/// </summary>
internal class DegreeOfAnArraySolution1
{
    public int FindShortestSubArray(int[] nums)
    {
        var numIndexes = new Dictionary<int, IList<int>>();
        for (var k = 0; k < nums.Length; k++)
        {
            if (numIndexes.ContainsKey(nums[k]))
            {
                numIndexes[nums[k]].Add(k);
            }
            else
            {
                numIndexes[nums[k]] = new List<int> { k };
            }
        }

        // Get Max degree numbers
        var maxDegreePair = numIndexes.MaxBy(p => p.Value.Count);
        var degreeOfArray = maxDegreePair.Value.Count;

        // Calculate degree of each number
        var minDegreeOfNumber = -1;
        foreach (var keyValuePair in numIndexes)
        {
            var currentDegree = keyValuePair.Value.Last() - keyValuePair.Value.First() + 1;
            if (keyValuePair.Value.Count == degreeOfArray)
            {
                minDegreeOfNumber =
                    minDegreeOfNumber == -1 ? currentDegree : Math.Min(minDegreeOfNumber, currentDegree);
            }
        }

        return minDegreeOfNumber;
    }
}

/// <summary>
///     https://leetcode.com/problems/degree-of-an-array/solutions/3349572/c-single-linq-query/
///     Very good solution, but it takes more CPU and memory.
/// </summary>
internal class DegreeOfAnArrayLinqSolution
{
    public int LinqSolution1(int[] nums)
    {
        var result =
            from index in Enumerable.Range(0, nums.Length)
            group index by nums[index]
            into sub
            let degree = sub.Count()
            let length = sub.Last() - sub.First() + 1
            orderby degree descending, length
            select length;

        return result.First();
    }

    public int LinqSolution2(int[] nums)
    {
        var result = Enumerable.Range(0, nums.Length)
            .Select((p, index) => new { Index = index, Number = nums[p] })
            .GroupBy(p => p.Number)
            .Select(p => new { p, Degree = p.Count(), Length = p.Last().Index - p.First().Index + 1 })
            .OrderByDescending(p => p.Degree)
            .ThenBy(p => p.Length)
            .Select(p => p.Length);


        //var result = nums.GroupBy(p => p).OrderByDescending(p => p.Count())
        //    .ThenBy(p => p.Last() - p.First() + 1)
        //    .First();

        return result.First();
    }
}

internal class DegreeOfAnArrayTest
{
    [TestCaseSource(typeof(TestCases))]
    public void DegreeOfAnArraySolution1Test(int[] nums, int expected)
    {
        var sut = new DegreeOfAnArraySolution1();
        var output = sut.FindShortestSubArray(nums);
        output.Should().Be(expected);
    }

    [TestCaseSource(typeof(TestCases))]
    public void LinqSolution1Test(int[] nums, int expected)
    {
        var sut = new DegreeOfAnArrayLinqSolution();
        var output = sut.LinqSolution1(nums);
        output.Should().Be(expected);
    }

    [TestCaseSource(typeof(TestCases))]
    public void LinqSolution2Test(int[] nums, int expected)
    {
        var sut = new DegreeOfAnArrayLinqSolution();
        var output = sut.LinqSolution2(nums);
        output.Should().Be(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 1, 2, 2, 3, 1 }, 2 };
            yield return new object?[] { new[] { 1, 2, 2, 3, 1, 4, 2 }, 6 };
        }
    }
}