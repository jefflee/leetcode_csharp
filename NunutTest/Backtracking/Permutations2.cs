using System.Collections;

namespace LeetCodeNUnitTest.Backtracking;

/// <summary>
///     https://leetcode.com/problems/permutations-ii/description/
///     47. Permutations II
///     Solutions:
///     https://leetcode.com/problems/permutations-ii/solutions/18594/really-easy-java-solution-much-easier-than-the-solutions-with-very-high-vote/
/// </summary>
internal class Permutations2Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> currentPermute = new List<int>();
        var usedIndices = new HashSet<int>();
        Array.Sort(nums);
        Backtrack(nums, currentPermute, usedIndices, result);
        return result;
    }

    private static void Backtrack(
        IReadOnlyList<int> nums,
        IList<int> currentPermute,
        ISet<int> usedIndices,
        ICollection<IList<int>> result)
    {
        if (currentPermute.Count == nums.Count)
        {
            result.Add(new List<int>(currentPermute));
            return;
        }

        for (var k = 0; k < nums.Count; k++)
        {
            if (usedIndices.Contains(k))
            {
                continue;
            }

            // Sort the array "int[] nums" to make sure we can skip the same value.
            // when a number has the same value with its previous, we can use this number only if his previous is used
            if (k > 0 && nums[k] == nums[k - 1] && !usedIndices.Contains(k - 1))
            {
                continue;
            }

            currentPermute.Add(nums[k]);
            usedIndices.Add(k);
            Backtrack(nums, currentPermute, usedIndices, result);
            currentPermute.RemoveAt(currentPermute.Count - 1);
            usedIndices.Remove(k);
        }
    }
}

internal class Permutations2Test
{
    [TestCaseSource(typeof(TestCases))]
    public void PermutationsSolutionTest(int[] nums, int[][] expected)
    {
        var sut = new Permutations2Solution();
        var output = sut.PermuteUnique(nums);
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
            yield return new object?[]
                { new[] { 1, 1, 2 }, new[] { new[] { 1, 1, 2 }, new[] { 1, 2, 1 }, new[] { 2, 1, 1 } } };
        }
    }
}