using System;
using System.Collections.Generic;

namespace ProgrammingAssignments.ArraysProblems
{
    public class MaxSum
    {
        private List<long> rangeSum(List<int> A, List<List<int>> B)
        {
            var res = new List<long>();
            var preSum = A.ConvertAll<long>(a => a);

            for (int i = 1; i < preSum.Count; i++)
            {
                preSum[i] = preSum[i] + preSum[i - 1];
            }

            foreach (var list in B)
            {
                int k = list[0] - 1;

                res.Add(preSum[list[1] - 1] - (k - 1 < 0 ? 0 : preSum[k - 1]));
            }


            return res;
        }
        private int GetMaxSum(List<int> A, int B)
        {
            //TODO: try solving without additional space

            int sum = 0;
            int maxSum = int.MinValue;
            var N = A.Count;
            if (B == N)
            {
                A.ForEach(x => sum += x);
                return sum;
            }
            var auxList = new List<int>();

            auxList.AddRange(A.GetRange(N - B, B));
            auxList.AddRange(A.GetRange(0, B));


            N = auxList.Count;

            auxList.GetRange(0, B).ForEach(x => sum += x);
            maxSum = Math.Max(sum, maxSum);

            for (int i = B; i < N; i++)
            {
                sum -= auxList[i - B];
                sum += auxList[i];
                maxSum = Math.Max(maxSum, sum);
            }

            return maxSum;
        }


    }
}