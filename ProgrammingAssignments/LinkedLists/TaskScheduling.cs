using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.LinkedLists
{
    public class TaskScheduling
    {
        public static int CPUCycle(List<int> A, List<int> B)
        {
            var sum = 0;
            var queue = new LinkedList<int>(A);
            foreach (int task in B)
            {
                if (queue.First.Value == task)
                {
                    sum += 1;
                    queue.RemoveFirst();
                }
                else
                {
                    while (queue.First.Value != task)
                    {
                        var headVal = queue.First.Value;
                        queue.RemoveFirst();
                        var node = queue.AddLast(headVal);
                        sum += 1;
                    }
                    sum += 1;
                    queue.RemoveFirst();
                }
            }

            return sum;
        }
    }
}
