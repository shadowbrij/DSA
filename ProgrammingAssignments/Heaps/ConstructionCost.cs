using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Heaps
{
    class ConstructionCost
    {
        public int solve(int A,List<List<int>> B)
        {
            //sort edges based on weight;
            B = B.OrderBy(b=>b[2]).ToList();

            var cost = 0;

            //parent array - inially each node point to self. ignore 0 - 1 point to 1 , 2 to 2 and so on.
            var parent = Enumerable.Range(0,A+1).ToList();

            foreach(var uvw in B)
            {
                if(union(uvw[0],uvw[1],parent)) cost+=uvw[2];
                else return -1;
            }

            return cost;
        }

        private bool union(int u, int v,List<int> parent)
        {
            int ru = FindRoot(u,parent);
            int rv = FindRoot(v,parent);
            if(ru == rv) 
                    return false;
            
            parent[ru] = rv;

            return true;
        }

        private int FindRoot(int x,List<int> parent)
        {
            //an Optimized version of root finding using "Path compression."
            if(x == parent[x])
                  return x;

            var r = FindRoot(parent[x],parent);
            parent[x] = r;
            return r;



           /* Below one has a TC O(n). 
            * while(x != parent[x])
            {
                x = parent[x];
            }

            return x; */
        }
    }
}
