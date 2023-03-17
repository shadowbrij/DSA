using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Sorting
{
    public class StringProblems
    {
        public static List<List<int>> Anagrams(List<string> A)
        {
            var N = A.Count;
            var ans = new List<List<int>>();
            var map = new Dictionary<string, int>();
            for (int i = 0; i < N; i++)
            {
                A[i] = new String(A[i].OrderBy(c => c).ToArray());
                if (map.ContainsKey(A[i]))
                {
                    ans[map[A[i]]].Add(i+1);
                }
                else
                {
                    map[A[i]] = ans.Count;
                    ans.Add(new List<int>() { i + 1 });
                }
            }
            return ans;
        }
        public static int BoringSubs(string A)
        {
            var N = A.Length;
            var FA = Enumerable.Repeat(0, 26).ToList();
            foreach (char ch in A)
            {
                FA[ch - 'a']++;
            }
            for (int i = 0; i < 26; i++)
            {
                if (FA[i] != 0)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < 26; j++)
                        {
                            if (j % 2 != 0 && FA[j] != 0 && j != i - 1 && j != i + 1) return 1;
                        }
                    }

                }
            }
            return 0;
        }
        public static int PermutationOfAinB(string A, string B)
        {
            var N = A.Length;
            var M = B.Length;
            var FA = Enumerable.Repeat(0, 26).ToList();
            var FB = Enumerable.Repeat(0, 26).ToList();
            for (int i = 0; i < N; i++)
            {
                FA[A[i] - 'a']++;
                FB[B[i] - 'a']++;
            }

            var count = 0;
            var l = 0;
            var r = N - 1;
            while (r < M)
            {
                if (checkEqual(FA, FB))
                {
                    count++;
                }
                FB[B[l]]--;
                l++;
                r++;
                if (r == M) break;
                FB[B[r]]++;
            }
            return count;
        }
        static bool checkEqual(List<int> A, List<int> B)
        {
            for (int i = 0; i < 26; i++)
            {
                if (A[i] != B[i]) return false;
            }
            return true;
        }
        public static string StringOps(string A)
        {
            var vovels = "aeiou".ToCharArray();
            return A;
        }
        public string ReverseString(string A)
        {
            
            var ca = A.Trim().ToCharArray();
            var N = ca.Length;
            var l = 0;
            var r = N - 1;
            while (l < r)
            {
                swap(ca, l, r);
                l++;
                r--;
            }
            // var i =0;
            var start = 0;
            for (int i = 0; i < N; i++)
            {
                if (ca[i] == ' ')
                {
                    swapRange(ca, start, i - 1);
                    while (ca[i] == ' ')
                    {
                        i++;
                    }
                    start = i;
                    i--;
                }

            }
            swapRange(ca, start, N - 1);

            return new String(ca);
        }
        private void swap(char[] ca, int l, int r)
        {
            var temp = ca[l];
            ca[l] = ca[r];
            ca[r] = temp;
        }
        private void swapRange(char[] ca, int start, int end)
        {
            if (start >= 0 && end < ca.Length)
            {
                while (start < end)
                {
                    swap(ca, start, end);
                    start++;
                    end--;
                }

            }
        }
        private static int CheckPalindromAtIndex(string A, int N, int i, int j)
        {

            if (i < 0 || j >= N || (A[i] != A[j]))
            {
                return 0;
            }
            return (i==j? 1: 2) + CheckPalindromAtIndex(A, N, i - 1, j + 1);
        }
        public static string ConversionCheck(string A)
        {
            var ca = A.ToCharArray();
            return ca.ToString();
        }
        public static string LongestPalindrome(string A)
        {
            
            var length = 0;
            var N = A.Length;
            var ind = 0;
            for (int i = 0; i < N; i++)
            {
                var currLen = CheckPalindromAtIndex(A, N, i, i);
                if(currLen > length)
                {
                    ind = i;
                }
                length = Math.Max(currLen,length);
                if (i < N - 1)
                {
                    currLen = CheckPalindromAtIndex(A, N, i, i + 1);
                    if (currLen > length)
                    {
                        ind = i;
                    }
                    length = Math.Max(currLen, length);
                }
                if (length == N)
                    break;
            }
            
            if(length % 2 == 0)
                return A.Substring(ind-(length/2)+1,length);
            else return A.Substring(ind - (length/2), length);

        }
        //private static int GetCurrentIndex(int currLen, int length, int i)
        //{
        //    if (currLen > length)
        //    {
        //        return i;
        //    }
        //}
        public List<int> countNoOfVovels(string A,List<List<int>> B)
        {
            var N = A.Length;
            var ans = new List<int>();
            var runningC = new List<int>(N);
            var listOfVs = new HashSet<char>(){ 'a','e','i','o','u'};
            var cf = 0;
            for (int i = 0; i < N; i++)
            {
                if (listOfVs.Contains(A.ElementAt(i)))
                {
                    runningC.Add(cf++);
                }
                else
                {
                    runningC.Add(cf);
                }
            }

            for (int i = 0; i < B.Count; i++)
            {
                var Q = B[i];
                int p = Q[0];
                int q = Q[1];
                //Got TLE 
                //if(listOfVs.Contains(A.ElementAt(p)) && listOfVs.Contains(A.ElementAt(q))){
                //    ans.Add(runningC[q] - runningC[p] +1);
                //}
                //else
                //{
                //    ans.Add(runningC[q] -runningC[p]);
                //}
            }
            return ans;

        }
        public static string addBinaryStrings(string A,string B)
        {
            StringBuilder sb = new StringBuilder();
            int N = A.Length;
            int M = B.Length;
            var F = A.ToCharArray().Select(c => Convert.ToInt32(c)).ToArray(); 
            var S = B.ToCharArray().Select(c => Convert.ToInt32(c)).ToArray(); ;

            bool carry = false;
            while (N > 0 || M > 0)
            {
                var a = (N > 0 ? F.ElementAt(N - 1) : 0);
                var b = (M > 0 ? S.ElementAt(M - 1) : 0);
                if (a == '1' && b == '1')
                {
                    if (carry)
                        sb.Append('1');
                    else sb.Append('0');
                    carry = true;
                }
                else if (a == '0' && b == '0')
                {
                    if (carry)
                        sb.Append('1');
                    else sb.Append('0');
                    carry = false;
                }
                else
                {
                    if (carry)
                    {
                        sb.Append('0');
                        carry = true;
                    }
                    else
                    {
                        sb.Append('1');
                    }
                }
                N--;
                M--;
            }

            return new string(sb.ToString().Reverse().ToArray());
        }
        public static string addBinary(string A, string B)
        {
            /* 1+1 = 2 
            1+1+carry = 3
            */
            int M = A.Length;
            int N = B.Length;
            var sb = new StringBuilder();
            var carry = 0;
            for (int i = 1; i <= Math.Max(M, N); i++)
            {
                var b1 = M - i < 0 ? 0 : (int)A.ElementAt(M - i);
                var b2 = N - i < 0 ? 0 : (int)B.ElementAt(N - i);
                if (b1 + b2 + carry >= 2)
                {
                    sb.Append("1");
                    carry = 1;
                }
                else
                {
                    sb.Append((b1 + b2 + carry).ToString());
                    carry = 0;
                }
            }
            return new String(sb.ToString().Reverse().ToArray());
        }
        public static int swaps(string A)
        {
            
            var chA = A.Reverse().GetEnumerator();
             
            var ans =0;
            var N = A.Length;
            var charA = A.ToCharArray();
            var countOfOnes = 0;
            for (int i = 0; i < N; i++)
            {
                if(charA[i] == '1') countOfOnes++;
            }
            for (int i = 0; i < N; i++)
            {
                if(charA[i] == '0')
                {
                    var lhs =0;
                    var p = i;
                    while (p >= 0 && charA[p-1] == '1')
                    {
                        lhs++;
                        p--;
                    }

                    var rhs = 0;
                    var k = i;
                    while(k<N && charA[k+1] == '1')
                    {
                        rhs++;
                        k++;
                    }

                    var total = lhs+rhs+1;
                    ans = Math.Max(total,ans);                 
                }

            }
            if(ans > countOfOnes)
                ans = countOfOnes;

            return ans;
        }
    }
}
