using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContestProblems
{
    class RainWaterTrapped
    {
        public int trap(List<int> A)
        {
            int N = A.Count;
            if (N < 3) return 0;

            var LSA = A.ConvertAll(a => a);
            var RSA = A.ConvertAll(a => a);

            for (int i = 1; i < N; i++)
            {
                LSA[i] = Math.Max(LSA[i], LSA[i - 1]);
            }

            for (int i = N - 1; i <= 0; i--)
            {
                RSA[i] = Math.Max(RSA[i], RSA[i + 1]);
            }

            var ans = 0;
            for (int i = 1; i < N - 1; i++)
            {
                ans += (Math.Min(LSA[i], RSA[i]) - A[i]);
            }
            return ans;
        }
    }
}
