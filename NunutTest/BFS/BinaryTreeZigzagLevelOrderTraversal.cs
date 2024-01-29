using System.Collections;

namespace LeetCodeNUnitTest.BFS;

/// <summary>
///     103. Binary Tree Zigzag Level Order Traversal
///     https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/description/
///     Solution:
///     https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/solutions/4543743/bfs-if-you-know-standard-bfs-using-queue-you-only-need-1-min-for-this/
/// </summary>
internal class BinaryTreeZigzagLevelOrderTraversalSolution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        IList<IList<int>> result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }

        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Count > 0)
        {
            var levelSize = q.Count();
            var temp = new List<int>();
            for (var i = 0; i < levelSize; i++)
            {
                var node = q.Dequeue();
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }

                temp.Add(node.val);
            }

            if (result.Count % 2 == 1)
            {
                temp.Reverse();
            }

            result.Add(temp);
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

internal class BinaryTreeZigzagLevelOrderTraversalTest
{
    [TestCaseSource(typeof(TestCases))]
    public void BinaryTreeZigzagLevelOrderTraversalSolutionTest(
        BinaryTreeZigzagLevelOrderTraversalSolution.TreeNode root,
        IList<IList<int>> expected)
    {
        var sut = new BinaryTreeZigzagLevelOrderTraversalSolution();
        var output = sut.ZigzagLevelOrder(root);
        output.Should().BeEquivalentTo(expected);
    }

    public class TestCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object?[]
            {
                new BinaryTreeZigzagLevelOrderTraversalSolution.TreeNode(
                    3,
                    new BinaryTreeZigzagLevelOrderTraversalSolution.TreeNode(9),
                    new BinaryTreeZigzagLevelOrderTraversalSolution.TreeNode(20,
                        new BinaryTreeZigzagLevelOrderTraversalSolution.TreeNode(15),
                        new BinaryTreeZigzagLevelOrderTraversalSolution.TreeNode(7))
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
                new BinaryTreeZigzagLevelOrderTraversalSolution.TreeNode(1),
                new List<IList<int>> { new List<int> { 1 } }
            };
        }
    }
}