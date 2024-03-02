using System.Collections.Generic;
using System.Linq;

namespace BinaryTreePostorderTraversal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }

        public IList<int> PostorderTraversal_solution1_iteration(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            var stack = new Stack<TreeNode>();
            var resultList = new LinkedList<int>();

            stack.Push(root);
            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                resultList.AddFirst(currentNode.val); // Pay attention here. Add to the list first.

                if (currentNode.left != null)
                {
                    stack.Push(currentNode.left);
                }

                if (currentNode.right != null)
                {
                    stack.Push(currentNode.right);
                }
            }

            return resultList.ToList();
        }

        public IList<int> PostorderTraversal_solution2(TreeNode root)
        {
            IList<int> resultList = new List<int>();

            if (root != null)
            {
                traversalTreeByRecursivelyImpl(root, resultList);
            }

            return resultList;
        }

        private void traversalTreeByRecursivelyImpl(TreeNode node, IList<int> resultList)
        {
            if (node.left != null)
            {
                traversalTreeByRecursivelyImpl(node.left, resultList);
            }

            if (node.right != null)
            {
                traversalTreeByRecursivelyImpl(node.right, resultList);
            }

            resultList.Add(node.val);
        }
        // https://leetcode.com/problems/binary-tree-postorder-traversal/

        public class TreeNode
        {
            public TreeNode left;
            public TreeNode right;
            public int val;

            public TreeNode(int x)
            {
                val = x;
            }
        }
    }
}