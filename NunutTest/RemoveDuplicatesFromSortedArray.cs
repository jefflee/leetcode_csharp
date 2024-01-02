using System.Collections;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/?envType=study-plan-v2&amp;
///     envId=top-interview-150
///     26. Remove Duplicates from Sorted Array
/// </summary>
internal class RemoveDuplicatesFromSortedArraySolution
{
    public int RemoveDuplicates(int[] nums)
    {
        int? previousNum = null;
        var numberOfUniqueElement = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (previousNum == nums[i])
            {
                continue;
            }

            nums[numberOfUniqueElement] = nums[i];
            previousNum = nums[i];
            numberOfUniqueElement++;
        }

        return numberOfUniqueElement;
    }
}

internal class RemoveDuplicatesFromSortedArrayTest
{
    [TestCaseSource(typeof(TestCases))]
    public void RemoveDuplicatesTest(int[] nums, int[] expectedNums, int numOfUniqueElement)
    {
        var sut = new RemoveDuplicatesFromSortedArraySolution();
        var output = sut.RemoveDuplicates(nums);
        output.Should().Be(numOfUniqueElement);

        nums.Should().BeEquivalentTo(expectedNums, options => options.WithStrictOrdering());
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 1, 1, 2 }, new[] { 1, 2, 2 }, 2 };
            yield return new object?[]
                { new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new[] { 0, 1, 2, 3, 4, 2, 2, 3, 3, 4 }, 5 };
        }
    }
}