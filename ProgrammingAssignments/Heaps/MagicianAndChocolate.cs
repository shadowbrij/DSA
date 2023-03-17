using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Heaps
{
    public class MagicianAndChocolate
    {
        int size = 0;
        public int nchoc(int A, List<int> B)
        {
            if (A == 0) return 0;
            if (A == 1) return Enumerable.Max(B);
            this.size = B.Count;
            CreateInPlaceMaxHeap(B);
            long sum = 0;
            var mod = 1000000007;
            while (A-- > 0)
            {
                var max = poll(B);
                Insert(B, max / 2);
                sum = (sum + max) % mod;
            }
            return (int)sum;
        }
        void Insert(List<int> A, int B)
        {
            if (A.Count == this.size)
                A.Add(B);
            else A[this.size] = B;
            this.size++;

            HeapifyUp(A);
        }

        void HeapifyUp(List<int> A)
        {
            int i = this.size - 1;
            while (i > 0)
            {
                var parent = (i - 1) / 2;
                if (A[parent] < A[i])
                {
                    Swap(A, i, parent);
                    i = parent;
                }
                else
                    break;
            }
        }
        void HeapifyAtIndex(List<int> A, int i)
        {
            int left = (2 * i + 1);
            bool hasLeft = this.size > left;

            int right = (2 * i + 2);
            bool hasRight = this.size > right;

            if (!(hasLeft || hasRight))
                return;

            if (hasLeft && (A[left] > A[i]))
            {
                Swap(A, i, left);
                HeapifyAtIndex(A, left);
            }

            if (hasRight && (A[right] > A[i]))
            {
                Swap(A, i, right);
                HeapifyAtIndex(A, right);
            }
        }

        int poll(List<int> A)
        {
            var item = A[0];
            A[0] = A[this.size - 1]; //copy last to first;
            this.size--;
            if (this.size > 1)
                HeapifyAtIndex(A, 0);
            return item;
        }

        void CreateInPlaceMaxHeap(List<int> A)
        {
            int noOfleaves = (this.size + 1) / 2;
            int HeapifyIndex = this.size - noOfleaves - 1;
            for (int i = HeapifyIndex; i >= 0; i--)
                HeapifyAtIndex(A, i);
        }

        void Swap(List<int> A, int i, int j)
        {
            var temp = A[j];
            A[j] = A[i];
            A[i] = temp;
        }
    }

}
