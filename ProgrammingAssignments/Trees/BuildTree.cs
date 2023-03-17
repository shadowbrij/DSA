using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Trees
{
    class BuildTree
    {
        public TreeNode buildTree(List<int> A, List<int> B)
        {
            return CreateTreeFromInPost(A, B, 0, A.Count - 1, 0, B.Count - 1);
        }

        //st_in - start index of inorder , vice versa for end-in.
        //st_p - start index of postorder, vice versa for end_p.    
        TreeNode CreateTreeFromInPost(List<int> In, List<int> Post, int st_in, int end_in, int st_p, int end_p)
        {
            if (st_in > end_in)
                return null;
            //last index of post-order is root.
            var node = new TreeNode(Post[end_p]);

            //find root in inorder
            var num_in = end_in - st_in + 1;
            var ind = st_in+ In.GetRange(st_in, num_in).FindIndex(a => a == Post[end_p]);

            //decide st_p and end_p is little tricky.
            var cntLeft = ind - st_in;

            node.left = CreateTreeFromInPost(In, Post, st_in, ind - 1, st_p, st_p + cntLeft - 1);
            node.right = CreateTreeFromInPost(In, Post, ind + 1, end_in, st_p + cntLeft, end_p - 1);

            return node;
        }
    }

}
