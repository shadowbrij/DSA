using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.BinarySearch
{
    class SpecialInteger
    {
        public static int SpecialInt(List<int> A, int B)
        {
            int N = A.Count;
            int l = 1;
            int r = N;

            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var sumExists = subArraySum(A, mid, B);
                if (sumExists && !subArraySum(A, mid + 1, B))
                    return mid;

                if (!sumExists)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return -1;
        }

        static bool subArraySum(List<int> A, int C, int B)
        {
            var sum = 0;
            var allSumLessThanB = true;
            for (int i = 0; i < A.Count; i++)
            {
                if (i < C)
                {
                    sum += A[i];
                    if (sum > B) return false;
                }
                else
                {
                    sum -= A[i - C];
                    sum += A[i];
                    if (sum > B) return false;
                }
            }
            return allSumLessThanB;
        }
    }
}
