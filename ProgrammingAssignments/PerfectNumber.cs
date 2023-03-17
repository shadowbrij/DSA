using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{
    public class PerfectNumber
    {
        public static string PFNumber(int A)
        {
            var queue = new LinkedList<string>();
            queue.AddLast("1");
            queue.AddLast("2");
            string ans = string.Empty;
            while (A-- > 0)
            {
                var rear = queue.First.Value; //kind of peek(rear)
                ans = rear;
                queue.RemoveFirst();
                queue.AddLast(string.Concat(rear,"1"));
                queue.AddLast(string.Concat(rear,"2"));
            }
            return string.Concat(ans,new String(ans.Reverse().ToArray()));
        }
    }
}
