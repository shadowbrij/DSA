using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Trees
{
    class CheckBSTWithOneChild
    {
        public string solve(List<int> A)
        {

            int L = int.MinValue;
            int R = int.MaxValue;

            int root = A[0];

            for (int i = 1; i < A.Count; i++)
            {
                if (A[i] > root)
                {
                    L = root;
                }
                else
                {
                    R = root;
                }

                if (A[i] < L || A[i] > R) return "NO";

                root = A[i];
            }

            return "YES";
    

       /*
       *******TLE CODE 
        if(A.Count < 3) return "Yes";

        var node = new TreeNode(A[0]);
        for(int i =1 ;i<A.Count;i++)
        {
            if(!isBSTFine(A[i],node))
                return "NO";
        }

        return "YES"; */
    }

        /*
        BELOW code is correct but it gives TLE

            bool isBSTFine(int a,TreeNode node){
                if(!hasLeft(node) && !hasRight(node)){
                    if(a < node.val){
                        node.left = new TreeNode(a);
                    }
                    else{
                        node.right = new TreeNode(a);
                    }
                    return true;
                }
                else if(hasLeft(node)){
                    if(a >= node.val) return false;
                    else{
                        return isBSTFine(a,node.left);
                    }
                }
                else{
                    if(a < node.val) return false;
                    else{
                        return isBSTFine(a,node.right);
                    }
                }
            }

            bool hasLeft(TreeNode node){
                return node.left != null;
            }
            bool hasRight(TreeNode node){
                return node.right != null;
            }
            */
    }


}
