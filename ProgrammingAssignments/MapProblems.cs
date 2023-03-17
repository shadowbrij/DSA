using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{
    public class MapProblems
    {
        public static int IsDictionary(List<string> A, string B= "nbpfhmirzqxsjwdoveuacykltg")
        {
            var map = new Dictionary<char, int>();
            var c = 0;
            foreach (var ch in B)
            {
                map[ch] = c++;
            }
            var N = A.Count;

            if (N == 1) return 1;

            for (int i = 1; i < N; i++)
            {
                var first = A[i - 1];
                var second = A[i];
                if (map[first[0]] > map[second[0]]) 
                        return 0;
                if (first.Length > second.Length) 
                        return 0;

                if ((map[first[0]] == map[second[0]]))
                {
                    var j = 1;
                    while ((j < first.Length) && (j < second.Length))
                    {
                        if (map[first[j]] > map[second[j]]) 
                                return 0;
                        j++;
                    }
                }
            }
            return 1;
        }
        public static List<int> dNums(List<int> A, int B)
        {
            var N = A.Count;
            var ans = new List<int>();

            if (B > N) return ans;

            var map = new Dictionary<int, int>();

            for (int i = 0; i < B; i++)
            {
                if (map.ContainsKey(A[i]))
                    map[A[i]]++;
                else map[A[i]] = 1;
            }
            ans.Add(map.Count);

            for (int i = B; i < N; i++)
            {
                var lf = i - B;
                if (map.ContainsKey(A[lf]))
                {
                    map[A[lf]]--;
                    if (map[A[lf]] == 0)
                        map.Remove(map[A[lf]]);

                    if (map.ContainsKey(A[i]))
                        map[A[i]]++;
                    else map[A[i]] =  1;
                }
                ans.Add(map.Count);
            }
            return ans;
        }
        public static int FisrtRepeating(List<int> A)
        {
            var map = new Dictionary<int, int>();
            A.ForEach(a => { if (map.ContainsKey(a)) map[a]++; else map.Add(a, 0); });
            for (int i = 0; i < A.Count; i++)
            {
                if (map[A[i]] > 1)
                    return A[i];
            }
            return -1;
        }
        public static bool checkIfEqual(Dictionary<char,int> A,Dictionary<char,int> B)
        {
            foreach(var item in A) { 
                }
            foreach(var key in B.Keys)
            {
                if(B[key] != A[key])
                    return false;
            }
            return true;
        }
    }
}
