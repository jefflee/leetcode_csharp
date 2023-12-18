using System.Collections;

namespace LeetCodeNUnitTest.DpProblems;

/// <summary>
///     https://leetcode.com/problems/degree-of-an-array/description/
///     697. Degree of an Array
/// </summary>
internal class DegreeOfAnArraySolution
{
    public int FindShortestSubArray(int[] nums)
    {
        var mostFrequentInt = nums.GroupBy(p => p).MaxBy(p => p.Count());
        var arrayDegree = mostFrequentInt!.Count();


        return 0;
    }
}

internal class DegreeOfAnArrayyTest
{
    [TestCaseSource(typeof(TestCases))]
    public void DegreeOfAnArrayTest(int[] nums, int expected)
    {
        var sut = new DegreeOfAnArraySolution();
        var output = sut.FindShortestSubArray(nums);
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