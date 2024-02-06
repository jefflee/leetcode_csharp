using System.Collections;

namespace LeetCodeNUnitTest.Backtracking;

/// <summary>
///     https://leetcode.com/problems/subsets/description/
///     78. Subsets
///     Solutions
///     I use the 10th algorithm of this page.
///     https://hackernoon.com/14-patterns-to-ace-any-coding-interview-question-c5bb3357f6ed.
///     It is also a backtracking problem. We can use the same way of "46. Permutations" and "77. Combinations".
/// </summary>
internal class SubsetsSolution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        var result = new List<IList<int>> { new List<int>() };
        foreach (var i in nums)
        {
            IList<IList<int>> tempList = new List<IList<int>>(result);
            result.AddRange(tempList.Select(p => new List<int>(p) { i }));
        }

        return result;
    }
}

internal class SubsetsSolutionTest
{
    [TestCaseSource(typeof(TestCases))]
    public void SubsetsTest(int[] nums, IList<IList<int>> expected)
    {
        var sut = new SubsetsSolution();
        var output = sut.Subsets(nums);
        output.Should().BeEquivalentTo(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[]
            {
                new[] { 1, 2, 3 },
                new List<IList<int>>
                {
                    new List<int>(), new List<int> { 1 }, new List<int> { 2 }, new List<int> { 1, 2 },
                    new List<int> { 3 }, new List<int> { 1, 3 }, new List<int> { 2, 3 }, new List<int> { 1, 2, 3 }
                }
            };
            yield return new object?[]
            {
                new[] { 0 },
                new List<IList<int>>
                {
                    new List<int>(), new List<int> { 0 }
                }
            };
        }
    }
}