using System.Collections;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/combinations/description/
///     77. Combinations
///     Solutions:
/// </summary>
internal class CombinationsSoution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var integers = Enumerable.Range(1, n);
        var currentCombination = new List<IList<int>>();
        foreach (var i in integers)
        {
            IList<IList<int>> tmpList = new List<IList<int>>
            {
                new List<int> { i }
            };

            foreach (var comb in currentCombination)
            {
                var newCombination = new List<int>(comb) { i };
                tmpList.Add(newCombination);
            }

            currentCombination.AddRange(tmpList);
        }

        return currentCombination.Where(p => p.Count == k).ToList();
    }
}

/// <summary>
///     The same technique with Backtracking.
///     Refer to "46. Permutations"
///     https://leetcode.com/problems/combinations/solutions/3845192/daily-leetcoding-challenge-august-day-1/
/// </summary>
internal class CombinationsRecursionSolution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        var combs = new List<IList<int>>();
        Backtrack(combs, new List<int>(), 1, n, k);

        return combs;
    }

    private void Backtrack(List<IList<int>> combs, List<int> comb, int start, int n, int k)
    {
        if (k == 0)
        {
            combs.Add(new List<int>(comb));
            return;
        }

        for (var i = start; i <= n; i++)
        {
            comb.Add(i);
            Backtrack(combs, comb, i + 1, n, k - 1);
            comb.RemoveAt(comb.Count - 1);
        }
    }
}

internal class CombinationsSolutionTest
{
    [TestCaseSource(typeof(TestCases))]
    public void CombinationsTest(int nInteger, int kNumbers, IList<IList<int>> expected)
    {
        var sut = new CombinationsSoution();
        var output = sut.Combine(nInteger, kNumbers);
        output.Should().BeEquivalentTo(expected);
    }

    [TestCaseSource(typeof(TestCases))]
    public void CombinationsRecursionSolutionTest(int nInteger, int kNumbers, IList<IList<int>> expected)
    {
        var sut = new CombinationsRecursionSolution();
        var output = sut.Combine(nInteger, kNumbers);
        output.Should().BeEquivalentTo(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[]
            {
                4, 2,
                new List<IList<int>>
                {
                    new List<int> { 1, 2 }, new List<int> { 1, 3 }, new List<int> { 1, 4 }, new List<int> { 2, 3 },
                    new List<int> { 2, 4 }, new List<int> { 3, 4 }
                }
            };
            yield return new object?[] { 1, 1, new List<IList<int>> { new List<int> { 1 } } };
        }
    }
}