using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Heaps
{
    class MaxHeaps
    {
        int size = 0;
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

        int poll(List<int> A)
        {
            var item = A[0];
            A[0] = A[this.size - 1]; //copy last to first;
            this.size--;
            if (this.size > 1)
                heapifyDown(A);
            return item;
        }
        private void heapifyDown(List<int> items)
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int largerChildIndex = getLeftchildIndex(index);
                if (items[largerChildIndex] < items[getRightchildIndex(index)])
                    largerChildIndex = getRightchildIndex(index);
                if (items[largerChildIndex] < items[index])
                    break;
                else
                {
                    Swap(items, largerChildIndex, index);
                }
                index = largerChildIndex;
            }
        }

        private int getLeftchildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int getRightchildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }
        private bool hasLeftChild(int index) { return getLeftchildIndex(index) < this.size; }

        void Swap(List<int> A, int i, int j)
        {
            var temp = A[j];
            A[j] = A[i];
            A[i] = temp;
        }
        void CreateInPlaceMaxHeap(List<int> A)
        {
            int noOfleaves = (this.size + 1) / 2;
            int HeapifyIndex = this.size - noOfleaves - 1;
            for (int i = HeapifyIndex; i >= 0; i--)
                HeapifyAtIndex(A, i);
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
    }
}
