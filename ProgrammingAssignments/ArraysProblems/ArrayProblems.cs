using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.ArraysProblems
{
    class ArrayProblems
    {
        public static int evenOddSumByRemoveItem(List<int> A)
        {
            int N = A.Count;
            int ans = 0;
            var PreEven = A.ConvertAll(c => c);
            var PreOdd = A.ConvertAll(c => c);
            var PostEven = A.ConvertAll(c => c);
            var PostOdd = A.ConvertAll(c => c);

            PreEven[0] = A[0];
            PreOdd[0] = 0;
            for (int i = 1; i < N; i++)
            {
                if (i % 2 == 0)
                {
                    PreEven[i] = PreEven[i] + PreEven[i - 2];
                    PreOdd[i] = PreOdd[i - 1];
                }
                else
                {
                    PreOdd[i] = PreOdd[i] + (i == 1 ? 0 : PreOdd[i - 2]);
                    PreEven[i] = PreEven[i - 1];
                }
            }
            if (N % 2 == 0)
            {
                PostEven[N - 1] = 0;
            }
            else
            {
                PostOdd[N - 1] = 0;
            }
            for (int i = N - 2; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    PostEven[i] = PostEven[i] + (i == N - 2 ? 0 : PostEven[i + 2]);
                    PostOdd[i] = PostOdd[i + 1];
                }
                else
                {
                    PostOdd[i] = PostOdd[i] + (i == N - 2 ? 0 : PostOdd[i + 2]);
                    PostEven[i] = PostEven[i + 1];
                }
            }

            for (int i = 0; i < N; i++)
            {
                if ((i == 0 ? 0 : PreEven[i - 1]) + (i == N - 1 ? 0 : PostOdd[i + 1])
                     == (i == 0 ? 0 : PreOdd[i - 1]) + (i == N - 1 ? 0 : PostEven[i + 1]))
                    ans++;
            }

            return ans;
        }
        public static List<int> AlternatingSubarray(List<int> A, int B)
        {
            int N = A.Count;
            var ans = new List<int>();
            if (B == 0)
            {
                ans.AddRange(Enumerable.Range(0, N));
            }

            for (int i = 1; i < N - B; i++)
            {
                int j = 1;
                int count = 1;
                // if(A[i-1] != A [i]){
                while (i - j >= 0 && i + j < N && A[i - j] == A[i + j] && A[i + j] != A[i + j - 1])
                {
                    count += 2;
                    j++;
                    if (count == 2 * B + 1)
                    {
                        ans.Add(i);
                        break;
                    }
                }
                // }
            }
            return ans;
        }
        private static int minAvg(List<int> A, int B)
        {
            int N = A.Count;
            int ts = 0;
            for (int i = 0; i < B; i++)
            {
                ts += A[i];
            }
            int avg = ts;
            int start = 0;
            int pavg = avg;
            for (int i = B; i < N; i++)
            {
                int navg = pavg + A[i] - A[i - B];
                start = navg < avg ? i - B + 1 : start;
                avg = Math.Min(avg, navg);
                pavg = navg;

            }

            return start;
        }
        public int solve(string A)
        {
            int N = A.Length;
            int count = 0;

            var ca = A.ToCharArray();
            var vovels = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            for (int i = N - 1; i >= 0; i--)
            {
                if (vovels.Contains(ca[i]))
                    count += N - i;
            }

            return count;
        }
        private static int equilibriumIndex(List<int> A)
        {
            int N = A.Count;
            var P = A.ConvertAll(a => a);
            for (int i = 1; i < N; i++)
            {
                P[i] = P[i - 1] + P[i];
            }
            for (int k = 0; k < N; k++)
            {

                if (k == 0 && P[N - 1] == P[k])
                    return 0;

                if (P[N - 1] - P[k - 1] == P[k])
                    return k;
            }
            return -1;
        }
        private static void Oddeven()
        {
            string? input = Console.ReadLine()?.Trim();
            if (input == null)
                throw new InvalidOperationException("Input cannot be null.");
                
            int T = Convert.ToInt32(input);
            for (int i = 0; i < T; i++)
            {
                string? nInput = Console.ReadLine()?.Trim();
                if (nInput == null) break;
                
                int N = Convert.ToInt32(nInput);
                
                string? arrayInput = Console.ReadLine()?.Trim();
                if (arrayInput == null) break;
                
                int[] A = Array.ConvertAll(arrayInput.Split(' '), int.Parse);
                var listofOdds = new List<int>();
                var listofEvens = new List<int>();

                for (int j = 0; j < N; j++)
                {
                    if (A[j] % 2 == 0)
                        listofEvens.Add(A[j]);
                    else
                        listofOdds.Add(A[j]);
                }
                listofEvens.ForEach(x => Console.Write("{0} ", x));
                Console.Write("\n");
                listofOdds.ForEach(x => Console.Write("{0} ", x));
            }
            Console.Read();
        }
    }
}
