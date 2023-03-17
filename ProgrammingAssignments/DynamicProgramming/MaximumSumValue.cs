using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.DynamicProgramming
{
    class MaximumSumValue
    {
        public int solve(List<int> A, int B, int C, int D)
        {
            int N = A.Count;

            //using 3 prefix array each for B,C and D
            var Pb = Enumerable.Repeat(A[0], N).ToList();
            var Pc = Enumerable.Repeat(A[0], N).ToList();
            var Pd = Enumerable.Repeat(A[0], N).ToList();

            Pb[0] =  A[0] * B;

            for (int i = 1; i < N; i++)
            {
                Pb[i] = Math.Max(Pb[i - 1], A[i] * B);
            }

            Pc[0] = Math.Max(Pb[0], Pb[0] + A[0] * C);
            for (int j = 1; j < N; j++)
            {
                Pc[j] = Math.Max(Pc[j - 1], Pb[j] + A[j] * C);
            }

            Pd[0] = Math.Max(Pc[0], Pc[0] + A[0] * D);
            for (int k = 1; k < N; k++)
            {
                Pd[k] = Math.Max(Pd[k - 1], Pc[k] + A[k] * D);
            }

            return Pd[N - 1];
        }
    }

}
