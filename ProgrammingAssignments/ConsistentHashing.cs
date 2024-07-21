using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{
    public class ConsistentHashing
    {
        public List<int> solve(List<string> A, List<string> B, List<int> C)
        {
            int N = A.Count;
            var ans = new List<int>();
            for (int i = 0; i < N; i++)
            {
                if (A[i] == "ADD")
                {
                    if (i == 0) ans.Add(0);
                    else
                        this.AddServer(Hash(B[i], C[i]), ans);
                }
                else if (A[i] == "ASSIGN")
                {
                    this.AssignServer(Hash(B[i], C[i]), ans);
                }
                else if (A[i] == "REMOVE")
                {
                    this.RemoveServer(Hash(B[i], C[i]), ans);
                }
            }

            return ans;
        }

        private void AddServer(int hasValue, List<int> ans)
        {

        }

        private void RemoveServer(int hasValue, List<int> ans)
        {

        }

        private void AssignServer(int hasValue, List<int> ans)
        {

        }

        public int Hash(string username, int hashKey)
        {
            int p = hashKey;
            int n = 360;
            long hashCode = 0;
            long p_pow = 1;
            for (int i = 0; i < username.Length; i++)
            {
                char character = username[i];
                hashCode = (hashCode + (character - 'A' + 1) * p_pow) % n;
                p_pow = (p_pow * p) % n;
            }
            return (int)hashCode;
        }


    }
}
