using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Trees
{
    class LargestBSTSubtree
    {
        public int solve(TreeNode A)
        {
            return BSTSize(A).Size;
        }

        NodeData BSTSize(TreeNode A)
        {
            /*
            1. if root
            */
            if (!hasLeft(A) && !hasRight(A))
            { //leaf
                return new NodeData(true, 1, A.val, A.val);
            }
            else if (hasLeft(A) && hasRight(A))
            {
                var left = BSTSize(A.left);
                var right = BSTSize(A.right);

                if (left.isBST && right.isBST && NodeDataFine(A, left, right))
                {
                    var newSize = left.Size + right.Size + 1;
                    return new NodeData(true, newSize, left.maxLeft, right.minRight);
                }
                else
                {
                    return new NodeData(false, Math.Max(left.Size, right.Size),0,0);
                }
            }
            else if (hasLeft(A))
            {
                var left = BSTSize(A.left);
                if (left.isBST && left.maxLeft < A.val)
                {
                    return new NodeData(true, 1 + left.Size, A.val, A.val);
                }
                else
                {
                    return new NodeData(false, left.Size,0,0);
                }
            }
            else
            { //if(hasRight(A))
                var right = BSTSize(A.right);
                if (right.isBST && right.minRight > A.val)
                {
                    return new NodeData(true, 1 + right.Size, A.val, A.val);
                }
                else
                {
                    return new NodeData(false,right.Size,0,0);
                }
            }
        }

        bool hasLeft(TreeNode A)
        {
            return A.left != null;
        }
        bool hasRight(TreeNode A)
        {
            return A.right != null;
        }
        bool NodeDataFine(TreeNode A, NodeData left, NodeData right)
        {
            return ((A.val > left.maxLeft) && (A.val < right.minRight));
        }
    }
    class NodeData
    {
        public NodeData(bool flag, int size, int max, int min)
        {
            this.isBST = flag;
            this.Size = size;
            this.maxLeft = max;
            this.minRight = min;
        }
        public bool isBST {get; set;}
        public int maxLeft { get; set; }
        public int minRight { get; set; }
        public int Size { get; set; }
    }

}
