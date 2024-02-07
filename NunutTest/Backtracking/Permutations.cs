using System.Collections;

namespace LeetCodeNUnitTest.Backtracking;

/// <summary>
///     https://leetcode.com/problems/permutations/description/
///     46. Permutations
///     Solution:
///     https://leetcode.com/problems/permutations/solutions/3850889/c-solution-for-permutations-problem/
/// </summary>
internal class PermutationsSolution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> currentPermute = new List<int>();
        var usedIndices = new HashSet<int>();
        Backtrack(nums, currentPermute, usedIndices, result);
        return result;
    }

    private static void Backtrack(IReadOnlyList<int> nums, IList<int> currentPermute, ISet<int> usedIndices,
        ICollection<IList<int>> result)
    {
        if (currentPermute.Count == nums.Count)
        {
            result.Add(new List<int>(currentPermute));
            return;
        }

        for (var k = 0; k < nums.Count; k++)
        {
            if (!usedIndices.Contains(k))
            {
                currentPermute.Add(nums[k]);
                usedIndices.Add(k);
                Backtrack(nums, currentPermute, usedIndices, result);
                currentPermute.RemoveAt(currentPermute.Count - 1);
                usedIndices.Remove(k);
            }
        }
    }
}

internal class PermutationsTest
{
    [TestCaseSource(typeof(TestCases))]
    public void PermutationsSolutionTest(int[] nums, int[][] expected)
    {
        var sut = new PermutationsSolution();
        var output = sut.Permute(nums);
        output.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[]
            {
                new[] { 1, 2, 3 },
                new[]
                {
                    new[] { 1, 2, 3 }, new[] { 1, 3, 2 }, new[] { 2, 1, 3 }, new[] { 2, 3, 1 }, new[] { 3, 1, 2 },
                    new[] { 3, 2, 1 }
                }
            };
            yield return new object?[] { new[] { 0, 1 }, new[] { new[] { 0, 1 }, new[] { 1, 0 } } };
            yield return new object?[] { new[] { 1 }, new[] { new[] { 1 } } };
        }
    }
}