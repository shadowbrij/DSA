using ProgrammingAssignments.LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Heaps
{
    class MergeSortedLists
    {
        int size = 0;
        public ListNode mergeKLists(List<ListNode> A)
        {
            var N = A.Count;
            if (N == 1) return A[0];

            this.size = N;
            var heap = new List<ListNode>();
            foreach (var headNode in A)
            {
                heap.Add(headNode);
            }
            int noOfleaves = (this.size + 1) / 2;
            int HeapifyIndex = this.size - noOfleaves - 1;
            for (int i = HeapifyIndex; i >= 0; i--)
                HeapifyAtIndex(heap, i);

            var head = poll(heap);
            if (head.next != null)
                Insert(heap, head.next);

            var temp = head;
            while (this.size > 0)
            {
                var current = poll(heap);
                temp.next = current;
                if (current.next != null)
                    Insert(heap, current.next);
                temp = temp.next;
            }
            return head;

        }
        void Insert(List<ListNode> A, ListNode B)
        {
            if (A.Count == this.size)
                A.Add(B);
            else A[this.size] = B;
            this.size++;

            HeapifyUp(A);
        }

        void HeapifyUp(List<ListNode> A)
        {
            int i = this.size - 1;
            while (i > 0)
            {
                var parent = (i - 1) / 2;
                if (A[parent].val >= A[i].val)
                {
                    Swap(A, i, parent);
                    i = parent;
                }
                else
                    break;
            }
        }
        void HeapifyAtIndex(List<ListNode> A, int i)
        {
            int left = (2 * i + 1);
            bool hasLeft = this.size > left;

            int right = (2 * i + 2);
            bool hasRight = this.size > right;

            if (!(hasLeft || hasRight))
                return;

            if (hasLeft && (A[left].val < A[i].val))
            {
                Swap(A, i, left);
                HeapifyAtIndex(A, left);
            }

            if (hasRight && (A[right].val < A[i].val))
            {
                Swap(A, i, right);
                HeapifyAtIndex(A, right);
            }
        }

        ListNode poll(List<ListNode> A)
        {
            var item = A[0];
            A[0] = A[this.size - 1]; //copy last to first;
            this.size--;
            if (this.size > 1)
                heapifyDown(A);
            return item;
        }

        private void heapifyDown(List<ListNode> items)
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftchildIndex(index);
                if (items[smallerChildIndex].val > items[getRightchildIndex(index)].val)
                    smallerChildIndex = getRightchildIndex(index);
                if (items[smallerChildIndex].val > items[index].val)
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
        private int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }
        private bool hasLeftChild(int index) { return getLeftchildIndex(index) < this.size; }

        void Swap(List<ListNode> A, int i, int j)
        {
            var temp = A[j];
            A[j] = A[i];
            A[i] = temp;
        }
    }

}
