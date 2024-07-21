using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.BitManipulations
{
    class Divide
    {
        public int divide(int A, int B)
        {
            long n = A;
            long m = B;

            var sign = 1;
            if (A < 0)
                sign *= -1;
            if (B < 0)
                sign *= -1;

            n = Math.Abs(n);
            m = Math.Abs(m);

            long result = 0;

            for (int i = 31; i >= 0; i--)
            {
                if ((m << i) <= n)
                {
                    n -= (m << i);
                    result += (1L << i); //this was tricky , needed 1L
                }
            }
            if (sign < 0)
                result *= -1;

            if (result > int.MaxValue)
                return int.MaxValue;
            return (int)result;
        }
    }

}
