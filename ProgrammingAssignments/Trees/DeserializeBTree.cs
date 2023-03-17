using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Trees
{
    class DeserializeBTree
    {
        public static TreeNode FromLevelOrderTraversal(List<int> A)
        {
            var N = A.Count;
            var map = new Dictionary<int, TreeNode>();
            var root = new TreeNode(A[0]);
            map[0] = root;
            var i = 0;
            for (int j = 1; j < N && i < N; i++)
            {
                if (A[i] != -1)
                {
                    //if(!map.ContainsKey(i)) continue;
                    var current = map[i];
                    var left = j;
                    var right = j + 1;

                    TreeNode leftChild = null;
                    TreeNode rightChild = null;

                    if (A[left] != -1)
                    {
                        leftChild = new TreeNode(A[left]);
                        map[left] = leftChild;
                    }
                    if (A[right] != -1)
                    {
                        rightChild = new TreeNode(A[right]);
                        map[right] = rightChild;
                    }

                    current.left = leftChild;
                    current.right = rightChild;
                    j += 2;
                }
            }
            return root;
        }
    }
}
