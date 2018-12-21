using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeInorderTraversal
{
    class Program
    {
        // https://leetcode.com/problems/binary-tree-inorder-traversal/

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }

        static void Main(string[] args)
        {
        }

        public IList<int> InorderTraversal_solution1_interation(TreeNode root)
        {
            var stack = new Stack<TreeNode>();
            IList<int> resultList = new List<int>();

            TreeNode currentNode = root;
            while (currentNode != null || stack.Count > 0)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = stack.Pop();
                resultList.Add(currentNode.val);
                currentNode = currentNode.right;
            }

            return resultList;
        }

        public IList<int> InorderTraversal_solution2(TreeNode root)
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

            resultList.Add(node.val);

            if (node.right != null)
            {
                traversalTreeByRecursivelyImpl(node.right, resultList);
            }
        }
    }
}
