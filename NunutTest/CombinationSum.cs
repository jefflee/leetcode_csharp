using System.Collections;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/combination-sum/description/
///     39. Combination Sum
///     Solutions
///     This is a Backtracking problem. The idea is to use recursion to generate all possible combinations of the input.
///     Refer to "46. Permutations" and "77. Combinations".
///     https://leetcode.com/problems/combination-sum/solutions/1777569/full-explanation-with-state-space-tree-recursion-and-backtracking-well-explained-c/
/// </summary>
internal class CombinationSumSolution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> currentComb = new List<int>();
        for (var i = 0; i < candidates.Length; i++)
        {
            Backtrack(result, currentComb, 0, candidates, i, target);
        }

        return result;
    }

    private void Backtrack(IList<IList<int>> result, IList<int> currentComb, int currentCombSum, int[] candidates,
        int currentIndex, int target)
    {
        if (currentCombSum + candidates[currentIndex] > target)
        {
            return;
        }

        if (currentCombSum + candidates[currentIndex] == target)
        {
            var newComb = new List<int>(currentComb) { candidates[currentIndex] };
            result.Add(newComb);
            return;
        }

        for (var i = currentIndex; i < candidates.Length; i++)
        {
            currentComb.Add(candidates[currentIndex]);
            Backtrack(result, currentComb, currentCombSum + candidates[currentIndex], candidates, i, target);
            currentComb.RemoveAt(currentComb.Count - 1);
        }
    }
}

internal class CombinationSumTest
{
    [TestCaseSource(typeof(TestCases))]
    public void CombinationSumSolutionTest(int[] candidates, int target, IList<IList<int>> expected)
    {
        var sut = new CombinationSumSolution();
        var output = sut.CombinationSum(candidates, target);
        output.Should().BeEquivalentTo(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[]
                { new[] { 2, 3, 6, 7 }, 7, new List<IList<int>> { new List<int> { 2, 2, 3 }, new List<int> { 7 } } };
            yield return new object?[]
            {
                new[] { 2, 3, 5 }, 8,
                new List<IList<int>> { new List<int> { 2, 2, 2, 2 }, new List<int> { 2, 3, 3 }, new List<int> { 3, 5 } }
            };
            yield return new object?[]
                { new[] { 2 }, 1, new List<IList<int>>() };
        }
    }
}