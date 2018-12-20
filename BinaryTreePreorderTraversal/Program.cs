using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreePreorderTraversal
{
    class Program
    {
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

        public IList<int> PreorderTraversal(TreeNode root)
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
    }
}
