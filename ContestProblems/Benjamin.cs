using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestProblems
{
    class Benjamin
    {
        public List<int> solve(List<int> A, List<int> B)
        {
            //create a new list which a copy of A
            var copyA = new List<int>(A);

            //count the number of pairs for which XOR of B[i]th bit is 1.
            //ans-> N(B[i]th bit is 1) x M (B[i]th bit is 0)
            int N = A.Count;
            int Q = B.Count;
            var ans = Enumerable.Repeat(0, Q).ToList();

            for (int i = 0; i < Q; i++)
            {
                int bit = B[i];
                int n = 0;
                int m = 0;
                for (int j = 0; j < N; j++)
                {
                    if ((A[j] & (1 << bit)) == 1)
                        n += 1;
                    else
                        m += 1;
                }
                ans[i] = n * m;
            }
            return ans;
        }
    }
}
