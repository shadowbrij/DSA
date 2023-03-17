using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments
{
    public class SortingProbs
    {
        public int InversionCount(List<int> A)
        {
            var N = A.Count;
            var count = 0;
            mergeSort(A, 0, N - 1, ref count);
            return count;
        }
        void mergeSort(List<int> A, int start, int end, ref int count)
        {
            if (start >= end) 
                return;
            var mid = (start + end) / 2;
            mergeSort(A, start, mid, ref count);
            mergeSort(A, mid + 1, end, ref count);
            merge(A, start, mid, end, ref count);
        }
        void merge(List<int> ans, int start, int mid, int end, ref int count)
        {
            //no of elements
            var M = mid - start + 1;
            var N = end - mid;

            //separat out the two arrays.
            var A = ans.GetRange(start, M);
            var B = ans.GetRange(mid + 1, N);

            var i = 0;
            var j = 0;
            for (int k = start+M+N; k < M + N; k++)
            {
                if (i == M)
                {
                    ans[k] = B[j];
                    j++;
                }
                else if (j == N || A[i] <= B[j])
                {
                    ans[k] = A[i];
                    i++;
                }
                else
                {
                    count += M - i;
                    ans[k] = B[j];
                    j++;
                }
            }
        }
        public static List<string> solve(List<string> A)
        {
            var N = A.Count;
            var numChar = "0123456789".ToCharArray();
            var studList = new List<Student>();
            for (int i = 0; i < N; i++)
            {
                var str = A[i];
                var fnumIndex = str.IndexOfAny(numChar);
                var name = str.Substring(0, fnumIndex);
                var mark = Convert.ToInt32(str.Substring(fnumIndex));
                studList.Add(new Student(name, mark));
            }
            //studList.Sort(new StudentComparer());
            studList.OrderByDescending(c=>c.marks);

            var retList = new List<string>();
            for (int i = 0; i < studList.Count; i++)
            {
                var a = studList[i];
                retList.Add(string.Concat(a.name, a.marks));
            }
            return retList;
        }

    
        class Student
        {
            public string name { get; set; }
            public int marks { get; set; }
            public Student(string name, int marks)
            {
                this.name = name;
                this.marks = marks;
            }
        }

        class StudentComparer : IComparer<Student>
        {
            public int Compare(Student a, Student b)
            {
                return b.marks - a.marks;
            }
        }
        public List<int> AlternateSort(List<int> A)
        {
            A.Sort(new AlternateComparer());
            return A;
        }
        public static List<int> FactorSort(List<int> A)
        {
            A.Sort(new FactorComparer());
            return A;
        }
        public static string LargestNumber(List<int> A)
        {
            var ans = new StringBuilder();
            A.Sort(new MaxComparer());
            
            int N = A.Count;

            for(int i = N - 1; i >= 0; i--)
            {
                ans.Append(A[i].ToString());
            }

            int index=0;
            int count = 0;
            while(index < A.Count-1 && ans[index++] == '0')
                    count++;
            ans.Remove(0,count);

            return ans.ToString();
        }
        public static List<int> SortByColor(List<int> A)
        {

            var ans = new List<int>();
            var frequency = Enumerable.Repeat(0,3).ToList();
            foreach(var a in A)
                frequency[a]++;
            var index = 0;
            foreach(var a in frequency)
            {
                ans.AddRange(Enumerable.Repeat(index,a));
                index++;
            }
            return ans;
        }
        internal class MaxComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                var p = x.ToString();
                var q = y.ToString();
                var P = $"{p}{q}";
                var Q = $"{q}{p}";
                return P.CompareTo(Q);

            }
        }
        private class FactorComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {

                var countfx = 2;
                var countfy = 2;
                for(int i = 2;i<= x / 2; i++)
                {
                    if (x% i == 0) countfx++;
                }
                for (int i = 2; i <= y / 2; i++)
                {
                    if (x % i == 0) countfy++;
                }

                return countfx-countfy;
            }
        }



    }

    class AlternateComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            //return x-y;//

            if(((x<0) && (y>0)) || ((x > 0) && (y < 0)))
                    return -1;
            else if((x < 0) && (y > 0)) return 0;
            else return -1;
        }
    }
}
