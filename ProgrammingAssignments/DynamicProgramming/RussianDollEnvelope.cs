using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.DynamicProgramming
{
    public class RussianDollEnvelope
    {
        public int solve(List<List<int>> A)
        {
            int ans = 0;
            A.Sort((a, b) =>
            {
                if (a[0] == b[0])
                    return b[1].CompareTo(a[1]);
                return a[0].CompareTo(b[0]);
            });

            //apply LIS on the second element of the envelope
            int N = A.Count;
            int[] dp = new int[N];
            for (int i = 0; i < N; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (A[i][1] > A[j][1] && A[i][0] > A[j][0])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                ans = Math.Max(ans, dp[i]);
            }

            return ans;
        }
    }
}
