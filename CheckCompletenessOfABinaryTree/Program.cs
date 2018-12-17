using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckCompletenessOfABinaryTree
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

        public static bool IsCompleteTree(TreeNode root)
        {
            int treeHigh = 0;
            TreeNode c = root;
            while (c.left != null)
            {
                treeHigh += 1;
                c = c.left;
            }
            // find the high of the tree. (find the most left node.)
            return CheckCompleteTree(root, 0, treeHigh, null);
        }

        public static bool CheckCompleteTree(TreeNode node, int currentTreeHigh, int treeHigh, bool? hasRightSibling)
        {
            if (node.left == null && node.right != null)
            {
                return false;
            }

            if (currentTreeHigh == treeHigh && node.left != null)
            {
                return false;
            }

            if (node.left != null && node.right is null && hasRightSibling == true)
            {
                return false;
            }

            if (node.left == null && node.right == null && (currentTreeHigh > treeHigh || currentTreeHigh < treeHigh - 1))
            {
                return false;
            }

            if (node.left == null && node.right == null && hasRightSibling == true && currentTreeHigh == treeHigh - 1)
            {
                return false;
            }

            if (((node.left == null && node.right != null) || (node.left != null && node.right == null)) && currentTreeHigh != (treeHigh - 1))
            {
                return false;
            }

            //leaf node
            if (node.left == null && node.right == null)
            {
                return true;
            }

            // deal with return value
            bool leftResult = false;
            bool rightResult = false;
            bool rightSiblingWithChild = node.right != null && (node.right.left != null || node.right.right != null)
                ? true
                : false;
            if (node.left != null && node.right != null)
            {
                leftResult = CheckCompleteTree(node.left, currentTreeHigh + 1, treeHigh, rightSiblingWithChild);
            }

            if (node.left != null && node.right == null)
            {
                leftResult = CheckCompleteTree(node.left, currentTreeHigh + 1, treeHigh, rightSiblingWithChild);
            }

            if (node.right != null)
            {
                rightResult = CheckCompleteTree(node.right, currentTreeHigh + 1, treeHigh, null);
            }
            else
            {
                // the node only has left child, it doesn't have right child.
                rightResult = true;
            }

            if (leftResult == false || rightResult == false)
            {
                return false;
            }

            return true;
        }
    }
}
