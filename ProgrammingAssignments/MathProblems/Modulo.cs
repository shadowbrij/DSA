using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.MathProblems
{
    public class Modulo
    {
        public static long findMod(string A, int B)
        {
            int N = A.Length;
            long ans = 0;
            long p = 1;
            var carr = A.ToCharArray();
            for (int i = N - 1; i >= 0; i--)
            {
                ans = (ans + p * carr[i]) % B;
                p = p * 10 % B;
            }
            return ans;
        }
    }
}
