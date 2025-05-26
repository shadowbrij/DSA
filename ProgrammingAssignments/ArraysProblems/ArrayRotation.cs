using System.Collections.Generic;

namespace ProgrammingAssignments.ArraysProblems
{
    public class ArrayRotation
    {
        /* Call from Main()
         * List<int> A = new List<int>() { 6, 31, 33, 13, 82, 66, 9, 12, 69, 21, 17, 2, 50, 69, 90, 71, 31, 1, 13, 70, 94, 46, 89, 13, 55, 54, 67, 97, 28, 27, 62, 34, 41, 18, 15, 35, 13, 84, 93, 27, 89, 23, 6, 56, 94, 40, 54, 95, 47 };
            List<int> B = new List<int>() { 88, 85, 98, 36, 66, 40, 30, 26, 51, 77, 62, 60, 92, 64, 53, 86, 24, 53, 85, 49, 57, 29, 32, 60, 75, 82, 17, 23, 67, 51, 23, 11, 70, 59 };
            
            var ar = new ArrayRotation();
            ar.RotateArray(A,B);
         
         */

        public List<List<int>> RotateArray(List<int> A, List<int> B)
        {
            List<List<int>> result = new List<List<int>>();
            foreach (int a in B)
            {
                var C = A.ConvertAll(i => i);
                LeftRotateArray(C, a);
                result.Add(C);

            }
            return result;
        }
        private void LeftRotateArray(List<int> A, int k)
        {
            int N = A.Count;
            if (k == 0 || k == N)
                return;

            if (k > N) k = N % k;

            SwapArray(A, 0, N - 1);
            SwapArray(A, 0, N - k - 1);
            SwapArray(A, N - k, N - 1);
        }

        private void Swap(List<int> A, int i, int j)
        {
            int temp = A[i];
            A[i] = A[j];
            A[j] = temp;
        }

        private void SwapArray(List<int> A, int k, int v)
        {
            int length = (v + k) / 2;
            for (int i = k; i <= length; i++)
            {
                Swap(A, i, v--);
            }
        }
    }
}