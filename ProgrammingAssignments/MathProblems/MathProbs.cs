using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.MathProblems
{
    public class MathProbs
    {
        public static int nCrModP(int A, int B, int C)
        {

            var factA = fact(A - B, A, C);
            var factB = fact(B, B, C);
            //var factAminusB = fact(1,A-B,C);

            var FPfactB = Fast_Power(factB, C - 2, C);
            //var FpfactAminusB = Fast_Power(factAminusB,C-2,C);

            return MultiPlyAndMod(factA, FPfactB, C);

        }
        static int MultiPlyAndMod(int A, int B, int mod)
        {
            return (A * B % mod + mod) % mod;

        }
        static int fact(int count, int num, int C)
        {
            long fact = 1;
            for (int i = 1; i <= count; i++)
            {
                fact = (fact * num % C + C) % C;
                num--;
            }
            return (int)fact;
        }
        static int Fast_Power(int A, int B, int C)
        {
            if (A == 1 || B == 0) return 1;
            int mod = C;

            long fa = Fast_Power(A, B / 2, C);
            long temp = (fa % C * fa % C + C) % C;
            if (B % 2 == 0)
            {
                return (int)((temp + mod) % mod);
            }
            else
            {
                return (int)((A * temp % mod + mod) % mod);
            }

        }
        public static int LuckyNums(int A)
        {
            var N = A;

            //sieve for prime numbers
            /*  var isP = Enumerable.Repeat(true,N+1).ToList();
              isP[0]=false;
              isP[1]=false;
              for(int i=2;i*i <= N;i++){
                  if(isP[i]){
                      for(int j=i*i;j <= N;j+=i)
                          isP[j] = false;
                  }
              }*/

            //sieve for smallest prime factors (spf)
            var spf = Enumerable.Repeat(0, N + 1).ToList();
            for (int i = 2; i * i <= N; i++)
            {
                if (spf[i] == 0)
                {
                    spf[i] = i;
                    for (int j = i * i; j <= N; j += i)
                    {
                        if (spf[j] == 0)
                            spf[j] = i;
                    }
                }
            }
            for (int k = 2; k <= N; k++)
            {
                if (spf[k] == 0)
                    spf[k] = k;
            }

            var ans = 0;
            for (int i = 6; i <= A; i++)
            {
                var elem = i;
                //var count = 0;
                while (elem > 1)
                {
                    var s = spf[elem];
                    //count++;
                    while (elem % s == 0)
                    {
                        elem /= s;
                    }
                    if (spf[elem] == elem)
                    {
                        ans++;
                    }
                    break;
                }
            }


            return ans;
        }
    }
}
