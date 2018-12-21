using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreePostorderTraversal
{
    class Program
    {
        // https://leetcode.com/problems/binary-tree-postorder-traversal/

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

        public IList<int> PostorderTraversal_solution1_iteration(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            Stack<TreeNode> stack = new Stack<TreeNode>();
            LinkedList<int> resultList = new LinkedList<int>();

            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode currentNode = stack.Pop();
                resultList.AddFirst(currentNode.val);

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
    }
}
