using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Trees
{
    class LCA
    {
        public int lca(TreeNode A, int B, int C)
        {
            /*Since this is not a BST we'd use In/Out time concept here*/
            var InTime = new Dictionary<int, int>();
            var OutTime = new Dictionary<int, int>();
            var temp = A;
            var T = 0;
            Travel(temp, ref InTime, ref OutTime, ref T);
            var curr = A;

            /* Helper : check if root x is ancestor of y - 
            InTime[x] < InTime[y] && OutTime[x] > OutTime[y]
            */
            while (curr != null)
            {
                //if curr.left is ancenstor of A & B
                if (curr.left != null && IsAncestorOf(curr.left, B, InTime, OutTime) && IsAncestorOf(curr.left, C, InTime, OutTime))
                {
                    curr = curr.left;
                }

                //if curr.right is ancenstor of A & B
                else if (curr.right != null && IsAncestorOf(curr.right, B, InTime, OutTime) && IsAncestorOf(curr.right, C, InTime, OutTime))
                {
                    curr = curr.right;
                }
                else break;
            }
            return curr.val;
            //return -1;

        }
        bool IsAncestorOf(TreeNode x, int y, Dictionary<int, int> InTime, Dictionary<int, int> OutTime)
        {
            // if(x == null) return false;
            return ((InTime[x.val] < InTime[y]) && (OutTime[x.val] > OutTime[y]));
        }
        void Travel(TreeNode node, ref Dictionary<int, int> InTime, ref Dictionary<int, int> OutTime, ref int T)
        {
            if (node == null)
            {
                return;
            }
            InTime[node.val] = T;
            T += 1;

            Travel(node.left, ref InTime, ref OutTime, ref T);
            Travel(node.right, ref InTime, ref OutTime, ref T);
            OutTime[node.val] = T;
            T += 1;
        }
    }
}
