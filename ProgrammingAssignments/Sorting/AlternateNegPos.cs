using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{
    class AlternateNegPos
    {
        public List<int> solve(List<int> A)
        {
            var negatives = A.Where(a => a < 0).Select(a=>a).ToList();
            var positives = A.Where(a => a >= 0).Select(a=>a).ToList();
            
            if (negatives.Count == 0) return positives;
            if (positives.Count == 0) return negatives;

            return Merge(negatives, positives);
        }
        List<int> Merge(List<int> Neg, List<int> Pos)
        {
            var P = Neg.Count;
            var Q = Pos.Count;
            var i = 1;
            var j = 0;
            var ans = Enumerable.Repeat(0, P + Q).ToList();
            ans[0] = Neg[0];
            for (int k = 1; k < P + Q; k++)
            {
                if (i == P)
                {
                    ans[k] = Pos[j];
                    j++;
                }
                else if (j == Q)
                {
                    ans[k] = Neg[i];
                    i++;
                }
                else if (ans[k - 1] < 0)
                {
                    ans[k] = Pos[j];
                    j++;
                }
                else
                {
                    ans[k] = Neg[i];
                    i++;
                }
            }
            return ans;
        }
    }

}
