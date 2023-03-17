using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.DynamicProgramming
{
    class MatrixChainMultiplication
    {
        public int solve(List<int> A)
        {
            var N = A.Count;
            var costMatrix = new int[N + 1, N + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int j = 0; j <= N; j++)
                {
                    if (i == 0 || j == 0)
                        costMatrix[i, j] = 0;
                    else
                        costMatrix[i, j] = int.MaxValue;
                }
            }

            //costMatrix[i,j] ->min cost to multiply matrix Mi,Mi+1.....Mj
            //our formula c[i,j] = Min(c[i,j], c[i,k]+c[k+1,j]+d[i-1]*d[k]*d[j]) - d is dimention same as A i.e. d[i] = A[i]

            for (int length = 1; length < N; length++)
            {
                for (int i = 1; i <= N; i++)
                {
                    //j-i+1 = l; => j = l-1+i;
                    int j = length + i - 1;
                    if (j >= N) break;
                    if (length == 1)
                    {
                        costMatrix[i, j] = 0;
                        continue;
                    }
                    for (int k = i; k < j; k++)
                    {
                        costMatrix[i, j] = Math.Min(costMatrix[i, j], costMatrix[i, k] + costMatrix[k + 1, j] + A[i - 1] * A[k] * A[j]);
                    }
                }
            }

            return costMatrix[1, N];
        }
    }

}
