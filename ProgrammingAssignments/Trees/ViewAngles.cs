using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Trees
{
    public class ViewAngles
    {

        static List<int> RightView(TreeNode A)
        {
            var queue = new LinkedList<TreeNode>();
            var ans = new List<int>();
            queue.AddLast(A);
            var last = A;
            while (queue.Count > 0)
            {
                TreeNode front = queue.First();
                queue.RemoveFirst();
                if (front.left != null)
                {
                    queue.AddLast(front.left);
                }
                if (front.right != null)
                {
                    queue.AddLast(front.right);
                }
                if (last == front)
                {
                    ans.Add(front.val);
                    if (queue.Count > 0)
                    {
                        TreeNode rear = queue.Last();
                        last = rear;
                    }
                }
            }
            return ans;
        }

    }

}
