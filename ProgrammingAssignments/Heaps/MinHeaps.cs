using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Heaps
{
    class MinHeaps
    {
        public int size { get; set; }
        public List<int> A{ get;set;}
        public MinHeaps(int size)
        {
            this.size = size;
            this.A = new List<int>();
        }
        public void Insert( int B)
        {
            if (A.Count == this.size)
                A.Add(B);
            else A[this.size] = B;
            this.size++;

            HeapifyUp();
        }

        void HeapifyUp()
        {
            int i = this.size - 1;
            while (i > 0)
            {
                var parent = (i - 1) / 2;
                if (A[parent] > A[i])
                {
                    Swap(A, i, parent);
                    i = parent;
                }
                else
                    break;
            }
        }

        public int poll()
        {
            var item = A[0];
            A[0] = A[this.size - 1]; //copy last to first;
            this.size--;
            if (this.size > 1)
                heapifyDown();
            return item;
        }

        private void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftchildIndex(index);
                if (A[smallerChildIndex] > A[getRightchildIndex(index)])
                    smallerChildIndex = getRightchildIndex(index);
                if (A[smallerChildIndex] > A[index])
                    break;
                else
                {
                    Swap(A, smallerChildIndex, index);
                }
                index = smallerChildIndex;
            }
        }

        private int getLeftchildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int getRightchildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private bool hasLeftChild(int index) { return getLeftchildIndex(index) < this.size; }

        void Swap(List<int> A, int i, int j)
        {
            var temp = A[j];
            A[j] = A[i];
            A[i] = temp;
        }
    }

    //Below method can be used only for an in-place heap

    /*void HeapifyAtIndex(List<int> A, int i)
        {
            int left = (2 * i + 1);
            bool hasLeft = this.size > left;

            int right = (2 * i + 2);
            bool hasRight = this.size > right;

            if (!(hasLeft || hasRight))
                return;

            if (hasLeft && (A[left] < A[i]))
            {
                Swap(A, i, left);
                HeapifyAtIndex(A, left);
            }

            if (hasRight && (A[right] < A[i]))
            {
                Swap(A, i, right);
                HeapifyAtIndex(A, right);
            }
        }
    */
}
