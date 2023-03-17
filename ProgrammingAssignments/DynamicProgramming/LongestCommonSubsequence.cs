using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.DynamicProgramming
{
    class LongestCommonSubsequence
    {
        public int solve(string A, string B)
        {
            //LCS[][] array 
            //LCS[i][j] is of first i chars of string A and first j chars of string B.
            var N = A.Length;
            var M = B.Length;
            var LCS = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        LCS[i, j] = 0;
                    }
                    else if (A[i] == B[j])
                    {
                        LCS[i, j] = 1 + LCS[i - 1, j - 1];
                    }
                    else
                        LCS[i, j] = Math.Max(LCS[i - 1, j], LCS[i, j - 1]);
                }
            }
            return LCS[N - 1, M - 1];

            /*
             
                     var N = A.Length;
        var M = B.Length;
        var LCS = new int[N,M];

        for(int i=0;i<N;i++){
            for(int j=0;j<M;j++){   
                if(A[i] == B[j]){
                    if(i == 0 || j == 0)
                        LCS[i,j] = 1;
                    else 
                        LCS[i,j] = 1 + LCS[i-1,j-1];
                }
                else if(!(i == 0 || j == 0))
                     LCS[i,j] = Math.Max(LCS[i-1,j],LCS[i,j-1]);
            }
        }
        return LCS[N-1,M-1];
             */
        }
    }

}
