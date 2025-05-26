using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.DynamicProgramming
{
    public class PalindromePartitioning
    {
        public int minCut(string A)
        {
            int N = A.Length;
            var isPalindrome = new bool[N, N];
            for (int l = 0; l < N; l++)
            {
                for (int r = 0; r < N; r++)
                {
                    int j = l+r-1;
                    if (j>=N) break;
                    if(l ==1) isPalindrome[l, r] = true;
                    else if (l == 2) isPalindrome[l, r] = A[l] == A[r];
                    else
                    {
                        isPalindrome[l, r] = A[l] == A[r] && isPalindrome[l + 1, r - 1];
                    }
                }
            }
            var cut = Enumerable.Repeat(int.MaxValue, N).ToArray();
            for (int i = 0; i < N; i++)
            {
                if (isPalindrome[0, i])
                {
                    cut[i] = 0;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (isPalindrome[j + 1, i])
                        {
                            cut[i] = Math.Min(cut[i], cut[j] + 1);
                        }
                    }
                }
            }
            return cut[N-1];
        }
    }
}
