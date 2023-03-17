using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{
    class BinarySearchProblems
    {
        public static int SpecialInteger(List<int> A, int B)
        {
            int N = A.Count;
            int l = 1;
            int r = N;

            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var sumExists = subArraySum(A, mid,B);
                if (sumExists && !subArraySum(A, mid + 1,B))
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
        static bool subArraySum(List<int> A,int C, int B)
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
                var mid = l + (r-l) / 2;
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

        public static int paint(int A, int B, List<int> C)
        {

            //*************************MODULO****************************

            //A - no of painters
            //B unit of time to paint ONE unit of board.
            var mod = 10000003;
            long maxelem = Enumerable.Max(C);
            long sum = Enumerable.Sum(C);
            long minTime = B * maxelem;
            long maxTime = B * sum;
            var l = minTime;
            var r = maxTime;

            //if(A == 1) return (int)(maxTime%mod);

            while (l <= r)
            {
                var mid = (r + (l - r) / 2);

                //check if mid is the answer
                var painters = noOfPaintersInTime(mid, C, B);
                if (painters > 0 && painters <= A)
                {
                    var nop = noOfPaintersInTime(mid - 1, C, B);
                    if (nop > A || nop == -1)
                        return (int)(mid % mod);
                }

                if (painters > A)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }
            return -1;
        }
        static int noOfPaintersInTime(long time, List<int> Boards, int B/*unit of time to paint ONE unit*/)
        {
            var N = Boards.Count;
            var count = 1;
            var exhausted = time;
            for (int i = 0; i < N; i++)
            {
                var needed = Boards[i] * B;
                if (needed > time) return -1; //impossible to paint;
                if (needed <= exhausted)
                {
                    exhausted -= needed;
                }
                else
                {
                    count += 1;
                    exhausted = time - needed;
                }
            }
            return count;
        }
        public static int multiply(int A, int B, int mod)
        {
            if (B == 1) return A;
            var cache = multiply(A, B / 2, mod);
            if (B % 2 == 0)
                return (cache + cache) % mod;
            else
                return (cache + cache + A) % mod;
        }
        int gcd(int a, int b)
        {
            if (a == 0) return b;
            return gcd(b % a, a);
        }
    }
}
