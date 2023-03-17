using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{
    class Recursion
    {
        public static int FindKthRow(int A, int B)
        {
            var list = new List<int>() { 0 };
            if (A == 1) return 0;

            return kthRow(list, A)[B - 1];

        }
        static List<int> kthRow(List<int> L, int A)
        {

            if (L.Count == Math.Pow(2, (A - 1)))
                return L;

            var lst = new List<int>();
            foreach (var d in L)
            {
                if (d == 0)
                    lst.AddRange(new List<int>() { 0, 1 });
                if (d == 1)
                    lst.AddRange(new List<int>() { 1, 0 });
            }

            return kthRow(lst, A);

        }
        public List<int> solve(int A)
        {
            var N = Math.Pow(2, A);
            var ans = new List<int>();

            ans.Add(0);
            if (A == 1) return ans;

            ans.Add(1);
            if (A == 2) return ans;

            for (int i = 2; i < N; i++)
            {
                var M = A-1;
                var D = i;
                while (M > 0)
                {
                    D = setUnsetBits(i,D, M, M - 1);
                    M = M -1;
                }
                ans.Add(D);
            }
            return ans;
        }
        int setUnsetBits(int A,int D, int B, int C)
        {
            if (isSame(A, B, C))
            {
                if (isOne(A, C))
                    return D ^ (1 << C);
                else
                    return D;
            }
            else
            {
                if (isZero(A, C))
                {
                    return D | (1 << C);
                }
                else if (isOne(A, C))
                    return D ^ (1 << C);
            }
            return D;
        }
        bool isZero(int A, int b)
        {
            return (A & (1 << b)) == 0;
        }
        bool isOne(int A, int b)
        {
            return (A & (1 << b)) == 1;
        }
        bool isSame(int A, int B, int C)
        {
            return (isZero(A, B) && isZero(A, C)) || (isOne(A, B) && isOne(A, C));
        }
    }
}
