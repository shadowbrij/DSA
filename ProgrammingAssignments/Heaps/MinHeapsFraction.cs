using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Heaps
{

    class MinHeapsFraction
    {
        int size = 0;
        public List<int> solve(List<int> A, int B)
        {
            var N = A.Count;
            var minHeap = new List<Fraction>();

            for (int i = N - 1; i > 0; i--)
            {
                decimal fraction = (decimal)A[0] / A[i];
                var fractionObj = new Fraction(fraction, 0, i);
                Insert(minHeap, fractionObj);
            }

            while (B-- > 1)
            {
                Fraction top = poll(minHeap);
                decimal fraction = (decimal)A[top.P + 1] / A[top.Q];
                var fractionObj = new Fraction(fraction, top.P + 1, top.Q);
                Insert(minHeap, fractionObj);
            }

            var last = poll(minHeap);
            return new List<int>() { last.P, last.Q };
        }

        void Insert(List<Fraction> A, Fraction B)
        {
            if (A.Count == this.size)
                A.Add(B);
            else A[this.size] = B;
            this.size++;

            HeapifyUp(A);
        }

        void HeapifyUp(List<Fraction> A)
        {
            int i = this.size - 1;
            while (i > 0)
            {
                var parent = (i - 1) / 2;
                if (A[parent].fraction > A[i].fraction)
                {
                    Swap(A, i, parent);
                    i = parent;
                }
                else
                    break;
            }
        }

        Fraction poll(List<Fraction> A)
        {
            var item = A[0];
            A[0] = A[this.size - 1]; //copy last to first;
            this.size--;
            if (this.size > 1)
                heapifyDown(A);
            return item;
        }

        private void heapifyDown(List<Fraction> items)
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftchildIndex(index);
                if (items[smallerChildIndex].fraction > items[getRightchildIndex(index)].fraction)
                    smallerChildIndex = getRightchildIndex(index);
                if (items[smallerChildIndex].fraction > items[index].fraction)
                    break;
                else
                {
                    Swap(items, smallerChildIndex, index);
                }
                index = smallerChildIndex;
            }
        }

        private int getLeftchildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int getRightchildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        //private int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }
        private bool hasLeftChild(int index) { return getLeftchildIndex(index) < this.size; }

        void Swap(List<Fraction> A, int i, int j)
        {
            var temp = A[j];
            A[j] = A[i];
            A[i] = temp;
        }
    }
    class Fraction
    {
        public Fraction(decimal val,int p,int q)
        {
            this.fraction = val;
            this.P = p;
            this.Q = q;
        }
        public decimal fraction { get; set; }
        public int P { get; set; }
        public int Q { get; set; }
    }
}
