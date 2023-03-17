using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.DynamicProgramming
{
    class NumDecoding
    {
        public int numDecodings(string A)
        {
            var N = A.Length;
            if (N == 1) return 1;

            var Ways = new int[N];
            if (A[0] == 0)
                return 0;
            else
                Ways[0] = 1;

            for (int i = 1; i < N; i++)
            {
                if (A[i] > 0)
                {
                    Ways[i] += Ways[i - 1];
                }
                var twoDigits = A[i - 1] * 10 + A[i];
                if ((twoDigits >= 10) && (twoDigits <= 26))
                {
                    if (i > 1)
                    {
                        Ways[i] += Ways[i - 2];
                    }
                    else
                    {
                        Ways[i] += 1;
                    }
                }
            }
            return Ways[N - 1];

        }
    }

}
