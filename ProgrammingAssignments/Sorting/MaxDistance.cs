using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Sorting
{
    class MaxDistance
    {
        public int maximumGap(List<int> A)
        {
            var N = A.Count;
            int count = 0;
            mergeSort(A, 0, N - 1, ref count);
            return count;
        }
        void mergeSort(List<int> A, int start, int end, ref int count)
        {
            if (start >= end) return;
            var mid = (start + end) / 2;
            mergeSort(A, start, mid, ref count);
            mergeSort(A, mid + 1, end, ref count);
            merge(A, start, mid, end, ref count);
        }
        void merge(List<int> ans, int start, int mid, int end, ref int count)
        {
            //no of elements
            var M = mid - start + 1;
            var N = end - mid;

            //separat out the two arrays.
            var A = ans.GetRange(start, M);
            var B = ans.GetRange(mid + 1, N);

            var i = 0;
            var j = 0;
            for (int k = start; k < start + M + N; k++)
            {
                if (i == M)
                {
                    ans[k] = B[j];
                    j++;
                }
                else if (j == N)
                {
                    ans[k] = A[i];
                    i++;
                }
                else if (A[i] <= B[j])
                {
                    //if(i<M && j < N)
                    count = Math.Max(count, M - i + j);
                    ans[k] = A[i];
                    i++;
                    // if(A[i] == B[j])
                    //     j++;
                    // else
                    //     i++;
                }
                else
                {
                    ans[k] = B[j];
                    j++;
                }
            }
        }
    }

}
