using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.StacksAndQueues
{
    class SlidingWindowsMaxMin
    {
        public int solve(List<int> A, int B)
        {
            // we will sliding window max technique, same for minimum
            // we will use dubly ended queue.

            var dequeMin = new LinkedList<int>();
            var dequeMax = new LinkedList<int>();
            // do operations for first window
            for (int i = 0; i < B; i++)
            {
                //we are pushing indexed to queues
                //max queue
                operateDequeMax(dequeMax, A, i);

                //min queue
                operateDequeMin(dequeMin, A, i);

            }

            var ans = A[dequeMax.First.Value] + A[dequeMin.First.Value];

            //slide the window further
            for (int i = B; i < A.Count; i++)
            {
                operateDequeMax(dequeMax, A, i);
                operateDequeMin(dequeMin, A, i);


                if (dequeMax.First.Value == i - B)
                {
                    dequeMax.RemoveFirst();
                }
                if (dequeMin.First.Value == i- B)
                {
                    dequeMin.RemoveFirst();
                }
                ans += A[dequeMax.First.Value] + A[dequeMin.First.Value];
            }

            return ans;
        }

        void operateDequeMin(LinkedList<int> dequeMin, List<int> A, int i)
        {
            while (dequeMin.Count > 0 && A[dequeMin.Last.Value] >= A[i])
            {
                dequeMin.RemoveLast();
            }
            dequeMin.AddLast(i);
        }
        void operateDequeMax(LinkedList<int> dequeMax, List<int> A, int i)
        {
            while (dequeMax.Count > 0 && A[dequeMax.Last.Value] <= A[i])
            {
                dequeMax.RemoveLast();
            }
            dequeMax.AddLast(i);
        }

    }

}
