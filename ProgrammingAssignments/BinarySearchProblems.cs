using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{
    class BinarySearchProblems
    {
 
        public static int multiply(int A, int B, int mod)
        {
            if (B == 1) return A;
            var cache = multiply(A, B / 2, mod);
            if (B % 2 == 0)
                return (cache + cache) % mod;
            else
                return (cache + cache + A) % mod;
        }
        int gcd(int a, int b)
        {
            if (a == 0) return b;
            return gcd(b % a, a);
        }
    }
}
