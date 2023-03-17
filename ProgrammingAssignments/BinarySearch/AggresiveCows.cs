using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.BinarySearch
{
    class AggresiveCows
    {
        public static int AggressiveCows(List<int> A, int B)
        {
            var N = A.Count;
            A.Sort();
            var l = A[1] - A[0];
            for (int i = 2; i < N; i++)
            {
                l = Math.Min(l, A[i] - A[i - 1]);
            }
            var r = A[N - 1] - A[0];
            var maxDist = r;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var X = NoOfCowsWithDist(mid, A);
                if ((X == B && NoOfCowsWithDist(mid + 1, A) < B) || (mid == maxDist))
                    return mid;

                if (X >= B)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return -1;
        }

        static int NoOfCowsWithDist(int D, List<int> A)
        {
            var count = 1;
            var N = A.Count;
            var last = A[0];
            for (int i = 1; i < N; i++)
            {
                if (A[i] - last >= D)
                {
                    count++;
                    last = A[i];
                }
            }
            return count;
        }
    }
}
