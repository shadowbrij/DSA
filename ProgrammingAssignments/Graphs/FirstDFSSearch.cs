using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class FirstDFSSearch
    {
        public int solve(List<int> A, int B, int C)
        {
            // if(B >= C) return 1;
            // else return 0;
            var map = new Dictionary<int, HashSet<int>>();
            var N = A.Count;

            if (B == C) return 1;
            if (N < 3) return 0;

            for (int i = 1; i < N; i++)
            {
                if (!map.ContainsKey(A[i]))
                {
                    var hs = new HashSet<int>();
                    hs.Add(i + 1);
                    map.Add(A[i], hs);
                }
                else
                {
                    map[A[i]].Add(i + 1);
                }
            }
            var visited = new HashSet<int>();
            if (hasDFSPath(map, C, B, visited)) //has dfs path from C to B.
                return 1;
            else
                return 0;
        }
        bool hasDFSPath(Dictionary<int, HashSet<int>> map, int C, int B, HashSet<int> visited)
        {
            if (!map.ContainsKey(C)) 
                return false;

            if (!visited.Contains(C))
                visited.Add(C);

            if (map[C].Contains(B))
                return true;
            else
            {
                foreach (var node in map[C])
                {
                    if (!visited.Contains(node) && hasDFSPath(map, node, B, visited))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

}
