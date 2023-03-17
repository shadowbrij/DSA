using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{

    class Matrix
    {
        public static List<List<int>> GenerateMatrix(int A)
        {
            var N = A;
            var ans = Enumerable.Repeat(Enumerable.Repeat(0, N).ToList(), N).ToList();
            var a = 1;
            for (int i = 0; i < N / 2; i++)
            {
                //i=0;,1
                int j;
                for (j = i; j < N - i; j++)
                {
                    ans[i][j] = a++;
                }
                //j = N-1,N-2
                int k;
                j--;
                for (k = i + 1; k <= j; k++)
                {
                    ans[k][j] = a++;
                }
                //k = j = N-1, i = 0;//N-2, i =1
                k--;
                j--;
                while (j >= i)
                {
                    ans[k][j] = a++;
                    j--;
                }
                //j==0//1
                j++;
                k--;
                while (k > i)
                {
                    ans[k][j] = a++;
                    k--;
                }
                //k =1,j=0//2,1

            }
            return ans;
        }
        public static List<List<int>> diagonal(List<List<int>> A)
        {
            int N = A.Count;
            var ans = new List<List<int>>();
            var a = new List<int>(4);
            
            for (int k = 0; k < N; k++)
            {
                int i = 0; int j = k;
                var ansrow = new List<int>();
                while (i <= k)
                {
                    ansrow.Add(A[i][j]);
                    i++;
                    j--;
                }
                ansrow.AddRange(Enumerable.Repeat(0, N - ansrow.Count));
                ans.Add(ansrow);
            }

            for (int k = 1; k < N; k++)
            {
                int i = k; int j = N - 1;
                var ansrow = new List<int>();
                while (i < N)
                {
                    ansrow.Add(A[i][j]);
                    i++;
                    j--;
                }
                ansrow.AddRange(Enumerable.Repeat(0, N - ansrow.Count));
                ans.Add(ansrow);
            }
            return ans;
        }
        public static List<List<int>> sum(List<List<int>> A, List<List<int>> B)
        {
            A.ForEach(x =>{
                x.ForEach(c=> c = c + B[A.IndexOf(x)][x.IndexOf(c)]);
                });
            return A;
            
    }
        //in clockwise order
        public static void PrintBoundaryElems(List<List<int>> A)
        {
            //wrong impl
            int N = A.Count;
            for(int k = 0; k < N; k++)
            {
                if(k == 0 || k == N - 1)
                {
                    //print all array
                    int i = k;
                    for(int j = 0; j < N; j++)
                    {
                        Console.WriteLine(A[i][j]);
                    }
                }
                else
                {
                    //print only first and last
                    int i = k;
                    Console.WriteLine(A[i][0]);
                    Console.WriteLine(A[i][N-1]);
                }

            }

            //Simplest way is to use 4 for loops 

        }
    }
}
