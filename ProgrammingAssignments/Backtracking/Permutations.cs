using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Backtracking
{
    class Permutations
    {
        private List<List<int>> ans;
        private int N;
        public List<List<int>> permute(List<int> A)
        {
            N = A.Count;
            ans = new List<List<int>>();
            if (N == 1)
            {
                ans.Add(new List<int>(){A[0]});
                return ans;
            }
            var Visited = Enumerable.Repeat(false, N).ToList();
            Permute(Visited, A, 0,new int[N]);
            return ans;
        }
        void Permute(List<bool> Visited, List<int> A, int index,int[] curr)
        {
            if (index == N)
            {
                ans.Add(curr.ToList());
                return;
            }                
            for (int i = 0; i < N; i++)
            {
                if (!Visited[i])
                {
                    Visited[i] = true;
                    curr[index] = A[i];
                    Permute(Visited, A, index + 1,curr);
                    Visited[i] = false;
                    curr[index] = 0;//reset for upper level, not needed though.
                }
            }        
        }
        
    }

}
