using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreePreorderTraversal
{
    class Program
    {
        // https://leetcode.com/problems/binary-tree-preorder-traversal/

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
        }

        public IList<int> PreorderTraversal_solution1_interation(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            IList<int> resultList = new List<int>();

            TreeNode currentNode = root;
            while (currentNode != null || stack.Count > 0)
            {
                while (currentNode != null)
                {
                    resultList.Add(currentNode.val);
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = stack.Pop();
                currentNode = currentNode.right;
            }

            return resultList;
        }

        public IList<int> PreorderTraversal_solution2(TreeNode root)
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
            resultList.Add(node.val);

            if (node.left != null)
            {
                traversalTreeByRecursivelyImpl(node.left, resultList);
            }

            if (node.right != null)
            {
                traversalTreeByRecursivelyImpl(node.right, resultList);
            }
        }
    }
}
