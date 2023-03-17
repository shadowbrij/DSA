using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Backtracking
{
    class UniquePermutatons
    {
        List<List<int>> ans ;
        int N;
        public List<List<int>> permute(List<int> A)
        {
            N = A.Count;
            if(N == 1)
            {
                ans.Add(new List<int> { A[0]});
                return ans;
            }

            ans = new List<List<int>>();
            var Frequency = Enumerable.Repeat(0,11).ToList();
            foreach(int item in A)
            {
                Frequency[item]++;
            }
            Permute(Frequency,0,new int[N]);
            return ans;
        }

        void Permute(List<int> Frequency,int index,int[] currAns)
        {
            if(index == N)
            {
                ans.Add(currAns.ToList());
                return;
            }
            for(int i = 0; i < 11; i++)
            {
                if(Frequency[i] > 0)
                {
                    Frequency[i]--;//do
                    currAns[index] = i;
                    Permute(Frequency,index+1,currAns);

                    currAns[index] = -1;//undo
                    Frequency[i]++; //undo
                }
            }

        }
    }
}
