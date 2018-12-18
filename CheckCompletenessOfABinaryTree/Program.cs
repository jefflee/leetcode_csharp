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
            List<ANode> nodes = new List<ANode>();
            nodes.Add(new ANode(root, 1));
            int i = 0;
            while (i < nodes.Count)
            {
                ANode anode = nodes[i];
                i += 1;
                if (anode.node != null)
                {
                    nodes.Add(new ANode(anode.node.left, anode.code * 2));
                    nodes.Add(new ANode(anode.node.right, anode.code * 2 + 1));
                }
            }

            return nodes[i - 1].code == nodes.Count;
        }

        public class ANode
        {  // Annotated Node
            public TreeNode node;
            public int code;

            public ANode(TreeNode node, int code)
            {
                this.node = node;
                this.code = code;
            }
        }
    }
}
