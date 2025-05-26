using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.ArraysProblems
{
    class SubMatrixSum
    {
        public List<int> solve(List<List<int>> A, List<int> B, List<int> C, List<int> D, List<int> E)
        {
            var N = A.Count;
            var M = A[0].Count;
            var Q = B.Count;
            int mod = 1000000007;

            // Create prefix sum matrix
            var prefixSum = new long[N, M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    prefixSum[i, j] = A[i][j];
                    if (i > 0) prefixSum[i, j] = (prefixSum[i, j] + prefixSum[i - 1, j]) % mod;
                    if (j > 0) prefixSum[i, j] = (prefixSum[i, j] + prefixSum[i, j - 1]) % mod;
                    if (i > 0 && j > 0) prefixSum[i, j] = (prefixSum[i, j] - prefixSum[i - 1, j - 1] + mod) % mod;
                }
            }

            var ans = new List<int>();

            for (int i = 0; i < Q; i++)
            {
                var ex = D[i] - 1;
                var ey = E[i] - 1;
                var sx = B[i] - 1;
                var sy = C[i] - 1;

                long sum = prefixSum[ex, ey];
                if (sx > 0) sum = (sum - prefixSum[sx - 1, ey] + mod) % mod;
                if (sy > 0) sum = (sum - prefixSum[ex, sy - 1] + mod) % mod;
                if (sx > 0 && sy > 0) sum = (sum + prefixSum[sx - 1, sy - 1]) % mod;

                // Ensure the sum is non-negative
                if (sum < 0) sum += mod;

                ans.Add((int)sum);
            }
            return ans;
        }
    }
}
