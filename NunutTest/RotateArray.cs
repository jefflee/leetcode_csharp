using System.Collections;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/rotate-array/description/?envType=study-plan-v2&amp;envId=top-interview-150
///     Solutions:
///     https://leetcode.com/problems/rotate-array/solutions/4006719/simple-beats-100/
///     https://leetcode.com/problems/rotate-array/solutions/4358342/simple-solution-with-recursion-and-slicing-easy-to-understand/
/// </summary>
internal class RotateArraySolution
{
    public void Rotate(int[] nums, int k)
    {
        // Ensure k is within array bounds
        k %= nums.Length;
        // Reverse entire array
        ReverseNumber(nums, 0, nums.Length - 1);
        // Reverse first k elements
        ReverseNumber(nums, 0, k - 1);
        // Reverse remaining elements
        ReverseNumber(nums, k, nums.Length - 1);
    }

    private static void ReverseNumber(int[] nums, int start, int end)
    {
        while (start < end)
        {
            // swap via deconstruction
            // https://stackoverflow.com/a/39190792
            (nums[start], nums[end]) = (nums[end], nums[start]);

            start++;
            end--;
        }
    }
}

internal class RotateArrayTest
{
    [TestCaseSource(typeof(TestCases))]
    public void RotateArraySolutionTest(int[] nums, int k, int[] expected)
    {
        var sut = new RotateArraySolution();
        sut.Rotate(nums, k);
        nums.Should().Equal(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[] { new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 } };
            yield return new object?[] { new[] { -1, -100, 3, 99 }, 2, new[] { 3, 99, -1, -100 } };
            yield return new object?[] { new[] { 1, 2 }, 3, new[] { 2, 1 } };
            yield return new object?[] { new[] { 1 }, 0, new[] { 1 } };
            yield return new object?[] { new[] { 1, 2, 3 }, 2, new[] { 2, 3, 1 } };
            yield return new object?[] { new[] { 1, 2, 3, 4, 5, 6 }, 3, new[] { 4, 5, 6, 1, 2, 3 } };
        }
    }
}