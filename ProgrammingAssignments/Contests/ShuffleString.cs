using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Contests
{
    internal class ShuffleString
    {
            public string solve(string A, List<int> B)
        {
            int N = B.Count;
            if (N == 1) return A;
            int i = 0;
            var map = new SortedDictionary<int, char>();
            foreach (char a in A)
            {
                map.Add(B[i], a);
            }

            var ans = new StringBuilder();
            foreach (var pair in map)
            {
                ans.Append(pair.Value);
            }
            return ans.ToString();
        }
    }
}
