using System.Collections;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/description/
///     80. Remove Duplicates from Sorted Array II
///     Solution:
///     https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/solutions/27976/3-6-easy-lines-c-java-python-ruby/
/// </summary>
internal class RemoveDuplicatesFromSortedArray2Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        var k = 0;
        foreach (var number in nums)
        {
            if (k < 2 || number > nums[k - 2])
            {
                nums[k] = number;
                k++;
            }
        }

        return k;
    }
}

internal class RemoveDuplicatesFromSortedArray2SolutionTest
{
    [TestCaseSource(typeof(TestCases))]
    public void RemoveDuplicatesTest(int[] nums, int[] expectedNums, int numOfUniqueElement)
    {
        var sut = new RemoveDuplicatesFromSortedArray2Solution();
        var output = sut.RemoveDuplicates(nums);
        output.Should().Be(numOfUniqueElement);

        nums.Should().BeEquivalentTo(expectedNums, options => options.WithStrictOrdering());
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 1, 1, 1, 2, 2, 3 }, new[] { 1, 1, 2, 2, 3, 3 }, 5 };
            yield return new object?[]
                { new[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 }, new[] { 0, 0, 1, 1, 2, 3, 3, 3, 3 }, 7 };
        }
    }
}