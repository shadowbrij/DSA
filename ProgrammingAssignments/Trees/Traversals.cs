using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Trees
{
    public class Traversals
    {
        static List<List<int>> VerticalOrder(TreeNode A)
        {
            var ans = new List<List<int>>();
            var queue = new LinkedList<Tuple<TreeNode,int>>();
            var map = new Dictionary<int,List<int>>();

            queue.AddLast(Tuple.Create(A,0));
            map.Add(0,new List<int>(){A.val });

            while(queue.Count > 0)
            {
                var front = queue.First(); 
                queue.RemoveFirst();

                if(front.Item1.left != null)
                {
                    var index= front.Item2 - 1;
                    var leftNode = front.Item1.left;
                    queue.AddLast(Tuple.Create(leftNode, index));
                    if(map.ContainsKey(index))
                        map[index].Add(leftNode.val);
                    else map.Add(index,new List<int>() { leftNode.val });
                }

                if (front.Item1.right != null)
                {
                    var index = front.Item2 + 1;
                    var rightNode = front.Item1.right;
                    queue.AddLast(Tuple.Create(rightNode, index));
                    if (map.ContainsKey(index))
                        map[index].Add(rightNode.val);
                    else map.Add(index, new List<int>() { rightNode.val });
                }

            }

            var min = map.Keys.Min();
            var max = map.Keys.Max();
            for(int i= min; i <= max; i++)
            {
                ans.Add(map[i]);
            }


            return ans;
        }
    }
}
