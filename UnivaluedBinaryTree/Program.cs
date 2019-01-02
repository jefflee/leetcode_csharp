using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnivaluedBinaryTree
{
    class Program
    {
        // https://leetcode.com/problems/univalued-binary-tree/
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

        public static bool IsUnivalTree(TreeNode root)
        {
            bool r = IsUnivalTreeImpl(root, root.val);
            return r;
        }

        public static bool IsUnivalTreeImpl(TreeNode root, int uniVal)
        {
            if (root.val != uniVal)
            {
                return false;
            }

            if (root.left != null && !IsUnivalTreeImpl(root.left, uniVal))
            {
                return false;
            }

            if (root.right != null && !IsUnivalTreeImpl(root.right, uniVal))
            {
                return false;
            }

            return true;
        }
    }
}
