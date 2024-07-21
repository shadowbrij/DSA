using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.StacksAndQueues
{
    public class MaxMinSubArraySum
    {

  /*      public int solve(int[] A)
        {
            int arrLen = A.length;
            int[] minLeft = nearestMinLeft(A);
            int[] minRight = nearestMinRight(A);
            int[] maxLeft = nearestMaxLeft(A);
            int[] maxRight = nearestMaxRight(A);
            int modulo = 1000 * 1000 * 1000 + 7;
            long maxSum = 0L; long minSum = 0L;

            for (int i = 0; i < arrLen; i++)
            {

                int cur = A[i];

                int rightMax = maxRight[i];
                int leftMax = maxLeft[i];
                long maxIx = 1L * (i - leftMax) * (rightMax - i);
                long maxIxContribution = (maxIx * cur) % modulo;

                int leftMin = minLeft[i];
                int rightMin = minRight[i];
                long minIx = 1L * (i - leftMin) * (rightMin - i);
                long minIxContribution = (minIx * cur) % modulo;

                maxSum = ((maxSum % modulo) + (maxIxContribution % modulo)) % modulo;
                minSum = ((minSum % modulo) + (minIxContribution % modulo)) % modulo;
            }

            int out = (int)(maxSum - minSum) % modulo;
            return (out +modulo) % modulo;
        }

        public int[] nearestMinLeft(int[] arr)
        {
            Deque<Integer> stack = new ArrayDeque();
            int arrLen = arr.length;
            int[] out = new int[arrLen];

            for (int i = 0; i < arrLen; i++)
            {
                while (!stack.isEmpty() && arr[i] <= arr[stack.peek()])
                {
                    stack.pop();
                }

                if (stack.isEmpty())
                {
				out[i] = -1;
                }
                else
                {
				out[i] = stack.peek();
                }

                stack.push(i);
            }

            return out;
        }

        public int[] nearestMinRight(int[] arr)
        {
            Deque<Integer> stack = new ArrayDeque();
            int arrLen = arr.length;
            int[] out = new int[arrLen];

            for (int i = arrLen - 1; i >= 0; i--)
            {
                while (!stack.isEmpty() && arr[i] <= arr[stack.peek()])
                {
                    stack.pop();
                }

                if (stack.isEmpty())
                {
				out[i] = arrLen;
                }
                else
                {
				out[i] = stack.peek();
                }

                stack.push(i);
            }

            return out;
        }

        public int[] nearestMaxLeft(int[] arr)
        {
            Deque<Integer> stack = new ArrayDeque();
            int arrLen = arr.length;
            int[] out = new int[arrLen];

            for (int i = 0; i < arrLen; i++)
            {
                while (!stack.isEmpty() && arr[i] >= arr[stack.peek()])
                {
                    stack.pop();
                }

                if (stack.isEmpty())
                {
				out[i] = -1;
                }
                else
                {
				out[i] = stack.peek();
                }

                stack.push(i);
            }

            return out;
        }

        public int[] nearestMaxRight(int[] arr)
        {
            Deque<Integer> stack = new ArrayDeque();
            int arrLen = arr.length;
            int[] out = new int[arrLen];

            for (int i = arrLen - 1; i >= 0; i--)
            {
                int current = arr[i];

                while (!stack.isEmpty() && current >= arr[stack.peek()])
                {
                    stack.pop();
                }

                if (stack.isEmpty())
                {
				out[i] = arrLen;
                }
                else
                {
				out[i] = stack.peek();
                }

                stack.push(i);
            }

            return out;
        }
  */

        //public int MaxMinusMinElemSum(List<int> A)
        //{
        //    /*contribution technique.
        //    SUM( A[i]*(#subarrays where A[i] is max - #subarrays where A[i] is min) );        
        //    SUM(A[i] * (((i-nearest greater on left)*(nearest greater on right -i))
        //                - ((i-nearest smaller on left)*(nearest smaller on right -i)))
        //        )
        //    */
        //    int N = A.Count;
        //    //var sum = 0;
        //    var SmallerLeft = CreateSmallerLeftList(A);//SOL
        //    var SmallerRight = CreateSmallerRight(A); //SOR
        //    var GreaterLeft = CreateGreaterLeftList(A); //GOL
        //    var GreaterRight = CreateGreaterRight(A); //GOR
        //    var mod = 1000000007;
        //    long totalMax = 0, totalMin = 0;

        //    for (int i = 0; i < N; i++)
        //    {
        //        //number of subarrays where A[i] will be maximum
        //        long maxSubarrayCount = 1L * (GreaterRight[i] - i)* (i - GreaterLeft[i]);
        //        long currentMaxContri = (A[i] * maxSubarrayCount) % mod;

        //        //number of subarrays where A[i] will be minimum
        //        long minSubarrayCount = 1l(SmallerRight[i] - i)(i - SmallerLeft[i]);
        //        long currentMinContri = (A[i] * minSubarrayCount) % mod;

        //        //generating total max contribution and minimum contribution
        //        totalMax = ((currentMaxContri % mod) + (totalMax % mod)) % mod;
        //        totalMin = ((currentMinContri % mod) + (totalMin % mod)) % mod;
        //    }

        //    int sum = (int)(totalMax - totalMin) % mod;
        //    return (sum + mod) % mod;
        //}

        //private List<int> CreateGreaterRight(List<int> A)
        //{
        //    int N = A.Count;
        //    var ans = Enumerable.Repeat(0,N).ToList();
        //    var stack = new Stack<int>();
        //    for(int i = N-1; i >=0 ; i--)
        //    {
        //        while(stack.Count > 0 && A[i] >= A[stack.Peek()])
        //        {
        //            stack.Pop();
        //        }
        //        if(stack.Count > 0)
        //        {
        //            ans[i] = stack.Peek();
        //        }
        //        else ans[i] = -1;
        //        stack.Push(i);
        //    }

        //    return ans;
        //}

        //private List<int> CreateGreaterLeftList(List<int> A)
        //{
        //    int N = A.Count;
        //    var ans = Enumerable.Repeat(0, N).ToList();
        //    var stack = new Stack<int>();
        //    for (int i = 0; i < N; i++)
        //    {
        //        while (stack.Count > 0 && A[i] >= A[stack.Peek()])
        //        {
        //            stack.Pop();
        //        }
        //        if (stack.Count > 0)
        //        {
        //            ans[i] = stack.Peek();
        //        }
        //        else ans[i] = -1;
        //        stack.Push(i);
        //    }

        //    return ans;
        //}

        //private List<int> CreateSmallerLeftList(List<int> A)
        //{
        //    int N = A.Count;
        //    var ans = Enumerable.Repeat(0, N).ToList();
        //    var stack = new Stack<int>();
        //    for (int i = 0; i < N; i++)
        //    {
        //        while (stack.Count > 0 && A[i] <= A[stack.Peek()])
        //        {
        //            stack.Pop();
        //        }
        //        if (stack.Count > 0)
        //        {
        //            ans[i] = stack.Peek();
        //        }
        //        else ans[i] = -1;
        //        stack.Push(i);
        //    }

        //    return ans;
        //}
        //private List<int> CreateSmallerRight(List<int> A)
        //{
        //    int N = A.Count;
        //    var ans = Enumerable.Repeat(0, N).ToList();
        //    var stack = new Stack<int>();
        //    for (int i = N - 1; i >= 0; i--)
        //    {
        //        while (stack.Count > 0 && A[i] <= A[stack.Peek()])
        //        {
        //            stack.Pop();
        //        }
        //        if (stack.Count > 0)
        //        {
        //            ans[i] = stack.Peek();
        //        }
        //        else ans[i] = -1;
        //        stack.Push(i);
        //    }

        //    return ans;
        //}

        //private int GetElement(List<int> A,int i)
        //{
        //    if (A[i] == -1) return i+1;
        //    else
        //        return A[i] ;

        //}

        ////private int NearestSmallerRight(List<int> A, int i)
        ////{
        ////    if(A[i] == -1) return i;
        ////    else return A[i];
        ////}


        ////private int NearestGreaterLeft(List<int> A, int i)
        ////{
        ////    if (A[i] == -1) return i;
        ////    else 
        ////        return A[i];
        ////}
    }
}
