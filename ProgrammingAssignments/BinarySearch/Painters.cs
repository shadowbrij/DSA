using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.BinarySearch
{
    class Painters
    {
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
    }
}
