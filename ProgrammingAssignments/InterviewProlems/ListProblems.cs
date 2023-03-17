using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.InterviewProlems
{
    public class ListProblems
    {
        class ListOfListComparer : IComparer<List<int>>
        {
            public int Compare(List<int> x, List<int> y)
            {
                return (int)Math.Floor(Math.Sqrt(x[0]*x[0] + x[1]*x[1]) - Math.Sqrt(y[0] * y[0] + y[1] * y[1]));
            }
        }
        class WaveComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                throw new NotImplementedException();
            }
        }
        public static List<int> WaveArray(List<int> A)
        {
            new List<Tuple<int,int>>();
            Tuple.Create(3,4);
            A.Sort();
            return A;
        }
        public static int UniqueElements(List<int> A)
        {
            var N = A.Count;
            A.Sort();
            var ans = 0;
            for (int i = 1; i < N; i++)
            {
                if (A[i] == A[i - 1])
                {
                    ans++;
                    A[i]++;
                }
                else if (A[i] < A[i - 1])
                {
                    var inc = A[i-1] - A[i] + 1;
                    ans += inc;
                    A[i] += inc;
                }
            }
            return ans;

        }
        public static int firstMissingPositive(List<int> A)
        {
            int N = A.Count;
            for (int i = 0; i < N; i++)
            {
                while ((A[i] >= 1 && A[i] <= N) && (A[i] != A[A[i] - 1]))
                {
                    //swaps A[i]-1 with i
                    var a = i;
                    var b = A[i]-1;
                    var temp = A[b];                    
                    A[b] = A[a];
                    A[a] = temp;
                }
            }
            for (int i = 1; i <= N; i++)
            {
                if (A[i - 1] != i)
                    return i;
            }
            var allN = A.Any(a => a > 0);
            return allN ? 1 : N + 1;

        }
        public static int RepeatedNumber(List<int> A)
        {
            var N = A.Count;
            if (N < 3) return 1;
            var P = A[0];
            var Cp = 1;
            var Q = -1;
            var Cq = 0;

            for (int i = 1; i < N; i++)
            {

                if (A[i] == P) { Cp++; continue; }
                else if (A[i] == Q) { Cq++; continue; }

                if (Cp == 0)
                {
                    Cp++;
                    P = A[i];
                    continue;
                }

                if (Cq == 0)
                {
                    Cq++;
                    Q = A[i];
                    continue;
                }

                if (Cp > Cq) Cq--;
                else Cp--;

            }
            var rcp = 0;
            var rcq = 0;
            for (int i = 0; i < N; i++)
            {
                if(A[i] == P) rcp++;
                else if(A[i] == Q) rcq++;
            }
            Cp = rcp;
            Cq = rcq;

            if ((Cp == 0 && Cq == 0) || (Cp <= N / 3 && Cq <= N / 3)) return -1;

            return Cp > Cq ? P : Q;
        }
        public static int subAWithContiguousElems(List<int> A)
        {
            
            int N = A.Count;
            int len = int.MinValue;
            for (int i = 0; i < N; i++)
            {
                if (N - i < len) break;
                for (int j = i; j < N; j++)
                {

                    var valid = checkSubArray(A, i, j);
                    if (valid)
                    {
                        len = Math.Max(len, j - i + 1);
                    }
                }
            }
            return len;
        }
        private static bool checkSubArray(List<int> A, int i, int j)
        {
            if (i == j)
                return true;
            var range = A.GetRange(i, j - i + 1);
            if (range.Count != range.Distinct().Count())
                return false;
            int max = Enumerable.Max(range);
            int min = Enumerable.Min(range);
            int sum = Enumerable.Sum(range);

            var apsum = ((j - i + 1) / 2) * (2 * min + (j - i));

            if (apsum == sum) return true;

            return false;

        }
        public static int ChristMasTree(List<int> A,List<int> B)
        {
            int N = A.Count;
            int ans = int.MaxValue;

            for (int j = 1; j < N - 1; j++)
            {
                var min_Bp = int.MaxValue;
                for (int i = j - 1; i >= 0; i--)
                {
                    if (A[i] < A[j] && B[i] < min_Bp)
                    {
                        min_Bp = B[i];
                    }
                }

                var min_Br = int.MaxValue;
                for (int k = j + 1; k < N; k++)
                {
                    if (A[k] > A[j] && B[k] < min_Br)
                    {
                        min_Br = B[k];
                    }
                }
                if(min_Bp != int.MaxValue && min_Br != int.MaxValue)
                    ans = Math.Min(ans, min_Bp + B[j] + min_Br);
            }

            return (ans != int.MaxValue ? ans : -1);
        }
    }
}
