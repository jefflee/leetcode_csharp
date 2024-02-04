using System.Collections;

namespace LeetCodeNUnitTest.BFS;

/// <summary>
///     https://leetcode.com/problems/binary-tree-level-order-traversal/
///     102. Binary Tree Level Order Traversal
/// </summary>
internal class BinaryTreeLevelOrderTraversalSolution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        IList<IList<int>> result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }

        var q = new Queue<(TreeNode, int)>();
        q.Enqueue((root, 1));

        while (q.Count != 0)
        {
            var (node, level) = q.Dequeue();
            if (result.Count < level)
            {
                IList<int> subList = new List<int> { node.val };
                result.Add(subList);
            }
            else
            {
                result[level - 1].Add(node.val);
            }

            if (node.left != null)
            {
                q.Enqueue((node.left, level + 1));
            }

            if (node.right != null)
            {
                q.Enqueue((node.right, level + 1));
            }
        }

        return result;
    }

    public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        public TreeNode left = left;
        public TreeNode right = right;
        public int val = val;
    }
}

internal class BinaryTreeLevelOrderTraversalTest
{
    [TestCaseSource(typeof(TestCases))]
    public void BinaryTreeLevelOrderTraversalSolutionTest(
        BinaryTreeLevelOrderTraversalSolution.TreeNode root,
        IList<IList<int>> expected)
    {
        var sut = new BinaryTreeLevelOrderTraversalSolution();
        var output = sut.LevelOrder(root);
        output.Should().BeEquivalentTo(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[]
            {
                new BinaryTreeLevelOrderTraversalSolution.TreeNode(
                    3,
                    new BinaryTreeLevelOrderTraversalSolution.TreeNode(9),
                    new BinaryTreeLevelOrderTraversalSolution.TreeNode(20,
                        new BinaryTreeLevelOrderTraversalSolution.TreeNode(15),
                        new BinaryTreeLevelOrderTraversalSolution.TreeNode(7))
                ),
                new List<IList<int>>
                {
                    new List<int> { 3 },
                    new List<int> { 20, 9 },
                    new List<int> { 15, 7 }
                }
            };
            yield return new object?[] { null, new List<IList<int>>() };
            yield return new object?[]
            {
                new BinaryTreeLevelOrderTraversalSolution.TreeNode(1),
                new List<IList<int>> { new List<int> { 1 } }
            };
        }
    }
}