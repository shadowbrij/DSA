using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.DynamicProgramming
{
    class MinSumPathTriangle
    {
        public int MinimumTotal(List<List<int>> A)
        {
            int N = A.Count;
            if (N == 1) return A[0][0];

            //update all row's first col
            for (int i = 1; i < N; i++)
            {
                A[i][0] = A[i - 1][0] + A[i][0];
            }

            //update last col
            for (int i = 1; i < N; i++)
            {
                A[i][A[i].Count - 1] = A[i][A[i].Count - 1] + A[i - 1][A[i - 1].Count - 1];
            }

            var ans = A[N - 1][0];
            for (int i = 2; i < N; i++)
            {
                for (int j = 1; j < A[i].Count - 1; j++)
                {
                    A[i][j] = Math.Min((A[i][j] + A[i - 1][j - 1]), (A[i][j] + A[i - 1][j]));
                    if (i == N - 1)
                    {
                        ans = Math.Min(ans, A[i][j]);
                    }
                }
            }
            return ans;
        }
    }
}
