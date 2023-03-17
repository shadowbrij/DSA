using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.StacksAndQueues
{
    public class MaxMinSubArraySum
    {
        public int MaxMinusMinElemSum(List<int> A)
        {
            /*contribution technique.
            SUM( A[i]*(#subarrays where A[i] is max - #subarrays where A[i] is min) );        
            SUM(A[i] * (((i-nearest greater on left)*(nearest greater on right -i))
                        - ((i-nearest smaller on left)*(nearest smaller on right -i)))
                )
            */
            int N = A.Count;
            var sum = 0;
            var SmallerLeft = CreateSmallerLeftList(A);//SOL
            var SmallerRight = CreateSmallerRight(A); //SOR
            var GreaterLeft = CreateGreaterLeftList(A); //GOL
            var GreaterRight = CreateGreaterRight(A); //GOR

            for (int i = 0; i < N; i++)
            {
                sum += A[i] * (
                                  ((i - GetElement(GreaterLeft, i)) * (GetElement(GreaterRight, i) - i))
                                - ((i - GetElement(SmallerLeft, i)) * (GetElement(SmallerRight, i) - i))
                              );
            }
            return sum;
        }

        private List<int> CreateGreaterRight(List<int> A)
        {
            int N = A.Count;
            var ans = Enumerable.Repeat(0,N).ToList();
            var stack = new Stack<int>();
            for(int i = N-1; i >=0 ; i--)
            {
                while(stack.Count > 0 && A[i] >= A[stack.Peek()])
                {
                    stack.Pop();
                }
                if(stack.Count > 0)
                {
                    ans[i] = stack.Peek();
                }
                else ans[i] = -1;
                stack.Push(i);
            }

            return ans;
        }

        private List<int> CreateGreaterLeftList(List<int> A)
        {
            int N = A.Count;
            var ans = Enumerable.Repeat(0, N).ToList();
            var stack = new Stack<int>();
            for (int i = 0; i < N; i++)
            {
                while (stack.Count > 0 && A[i] >= A[stack.Peek()])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    ans[i] = stack.Peek();
                }
                else ans[i] = -1;
                stack.Push(i);
            }

            return ans;
        }

        private List<int> CreateSmallerLeftList(List<int> A)
        {
            int N = A.Count;
            var ans = Enumerable.Repeat(0, N).ToList();
            var stack = new Stack<int>();
            for (int i = 0; i < N; i++)
            {
                while (stack.Count > 0 && A[i] <= A[stack.Peek()])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    ans[i] = stack.Peek();
                }
                else ans[i] = -1;
                stack.Push(i);
            }

            return ans;
        }
        private List<int> CreateSmallerRight(List<int> A)
        {
            int N = A.Count;
            var ans = Enumerable.Repeat(0, N).ToList();
            var stack = new Stack<int>();
            for (int i = N - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && A[i] <= A[stack.Peek()])
                {
                    stack.Pop();
                }
                if (stack.Count > 0)
                {
                    ans[i] = stack.Peek();
                }
                else ans[i] = -1;
                stack.Push(i);
            }

            return ans;
        }

        private int GetElement(List<int> A,int i)
        {
            if (A[i] == -1) return i+1;
            else
                return A[i] ;

        }

        //private int NearestSmallerRight(List<int> A, int i)
        //{
        //    if(A[i] == -1) return i;
        //    else return A[i];
        //}


        //private int NearestGreaterLeft(List<int> A, int i)
        //{
        //    if (A[i] == -1) return i;
        //    else 
        //        return A[i];
        //}
    }
}
