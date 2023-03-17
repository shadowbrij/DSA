using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.StacksAndQueues
{
    public class SlidingWindowMaximum
    {
        //
        public List<int> SlidingMaximum(List<int> A,int B)
        {
            var ans = new List<int>();
            var N = A.Count;
            var deque = new LinkedList<int>();
            for(int i = 0; i < B; i++)
            {
                while(deque.Count > 0 && A[deque.Last.Value] <= A[i]){
                    deque.RemoveLast();
                }
                deque.AddLast(i);
            }

            ans.Add(A[deque.First.Value]);

            for(int i = B; i < N; i++)
            {
                while (deque.Count > 0 && A[deque.Last.Value] <= A[i])
                {
                    deque.RemoveLast();
                }
                deque.AddLast(i);
                
                //IMPORTANT step
                if(deque.First.Value == i-B) 
                        deque.RemoveFirst();

                ans.Add(A[deque.First.Value]);
            }

            return ans;
        }
    }
}
