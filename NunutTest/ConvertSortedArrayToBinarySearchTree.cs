﻿using System.Collections;
using static LeetCodeNUnitTest.ConvertSortedArrayToBinarySearchTreeSolution;

namespace LeetCodeNUnitTest;

/// <summary>
///     https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/description/
///     108. Convert Sorted Array to Binary Search Tree
///     Solutions:
///     https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/solutions/2406277/python-easily-understood-faster-than-86-less-than-83-recursion/
/// </summary>
internal class ConvertSortedArrayToBinarySearchTreeSolution
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        var bstTree = MakeBst(nums, 0, nums.Length - 1);
        return bstTree;
    }

    private TreeNode MakeBst(int[] nums, int start, int end)
    {
        if (start > end)
        {
            return null;
        }

        var mid = (start + end) / 2;
        var root = new TreeNode(nums[mid]);
        root.left = MakeBst(nums, start, mid - 1);
        root.right = MakeBst(nums, mid + 1, end);
        return root;
    }

    public class TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        public TreeNode? left = left;
        public TreeNode? right = right;
        public int val = val;
    }
}

internal class ConvertSortedArrayToBinarySearchTreeTest
{
    [TestCaseSource(typeof(TestCases))]
    public void ConvertSortedArrayToBinarySearchTreeSolutionTest(int[] nums, TreeNode expected1, TreeNode expected2)
    {
        var sut = new ConvertSortedArrayToBinarySearchTreeSolution();
        var tree = sut.SortedArrayToBST(nums);
        tree.Should().BeOneOf(expected1, expected2);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[]
            {
                new[] { -10, -3, 0, 5, 9 },
                new TreeNode(0,
                    new TreeNode(-3,
                        new TreeNode(-10)),
                    new TreeNode(9,
                        new TreeNode(5))),
                new TreeNode(0,
                    new TreeNode(-10,
                        null,
                        new TreeNode(-3)),
                    new TreeNode(5,
                        null,
                        new TreeNode(9)))
            };

            //yield return new object?[]
            //{
            //    new int?[] { 1, 3 },
            //    new int?[] { 1, null, 3 },
            //    new int?[] { 3, 1 }
            //};
        }
    }
}