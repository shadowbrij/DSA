using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.ArraysProblems
{
    class SpiralOrderMatrixII
    {
       public List<List<int>> generateMatrix(int A)
       {
            var N = A;
            var ans = new int[N, N];
            var a = 1;
            for (int i = 0; i < N / 2; i++)
            {
                //i=0;,1
                int j;
                for (j = i; j < N - i; j++)
                {
                    ans[i, j]  = a++;
                }
                //j = N-1,N-2
                int k;
                j--;
                for (k = i + 1; k <= j; k++)
                {
                    ans[k, j] = a++;
                }
                //k = j = N-1, i = 0;//N-2, i =1
                k--;
                while (j > i)
                {
                    j--;
                    ans[k, j] = a++;
                }
                //j==0//1
                k--;
                while (k > i)
                {
                    ans[k, j] = a++;
                    k--;
                }
                //k =1,j=0//2,1
            }
            return getFinalAns(ans,A);

        }

        List<List<int>> getFinalAns(int[,] ans,int A){
            var finalans = new List<List<int>>();
            for (int i = 0; i < A; i++)
            {
                var tl = new List<int>();
                for (int j = 0; j < A; j++)
                {
                    tl.Add(ans[i, j]);
                }
                finalans.Add(tl);
            }
            return finalans;
        }

    }

}

