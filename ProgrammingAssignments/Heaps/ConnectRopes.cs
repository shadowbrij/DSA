using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Heaps
{
    public class ConnectRopes
    {
        int size = 0;
        public int Solve(List<int> A)
        {
            if (A.Count == 1) return 0;
            this.size = A.Count;
            var ans = 0;

            CreateInPlaceHeap(A);

            while (this.size > 2)
            {
                var minPair = GetMinPair(A);
                var sum = minPair.Item1 + minPair.Item2;
                ans += sum;
                Insert(A, sum);
            }
            ans += A[0];
            ans += A[1];

            return ans;
        }
        Tuple<int, int> GetMinPair(List<int> A)
        {
            var first = A[0];
            A[0] = A[this.size - 1];
            //this.size--;

            int second = A[1];
            A[1] = A[this.size - 2];

            if (A[2] < second)
            {
                second = A[2];
                A[2] = A[this.size - 2];
                if(this.size == 3)//special case
                {
                    A[0] = A[1];//because then A[2] and A[0] bacame same.
                }
            }
            this.size -=2;
            return Tuple.Create(first, second);
        }

        void Insert(List<int> A, int B)
        {
            if (A.Count == this.size)
                A.Add(B);
            else A[this.size] = B;
            this.size++;

            CreateInPlaceHeap(A);
        }

        void CreateInPlaceHeap(List<int> A)
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
        void Swap(List<int> A, int i, int j)
        {
            var temp = A[j];
            A[j] = A[i];
            A[i] = temp;
        }

        //void HeapifyUp(List<int> A)
        //{
        //    int i = this.size - 1;
        //    while (i > 0)
        //    {
        //        var parent = (i - 1) / 2;
        //        if (A[parent] > A[i])
        //        {
        //            Swap(A, i, parent);
        //            i = parent;
        //        }
        //        else
        //            break;
        //    }
        //}
        //void HeapifyDown(List<int> A)
        //{
        //    int N = this.size;
        //    int i = 0;
        //    while (i <= (N - 3) / 2)
        //    {
        //        var leftchild = 2 * i + 1;
        //        var rightChild = 2 * i + 2;

        //        if ((N > leftchild) && (A[leftchild] < A[i]))
        //        {
        //            Swap(A, leftchild, i);
        //            i = leftchild;
        //        }
        //        else if ((N > rightChild) && (A[rightChild] < A[i]))
        //        {
        //            Swap(A, rightChild, i);
        //            i = rightChild;
        //        }
        //        else
        //            break;
        //    }
        //}

        //void HeapifyDown(List<int> A)
        //{
        //    int N = this.size;
        //    int i = 0;
        //    while (i <= (N - 2) / 2)
        //    {
        //        var leftchild = 2 * i + 1;
        //        if (A[leftchild] < A[i])
        //            Swap(A, leftchild, i);

        //        var rightChild = 2 * i + 2;
        //        if (A[rightChild] < A[i])
        //            Swap(A, rightChild, i);

        //        i++;
        //    }
        //}


        //int poll(List<int> A)
        //{
        //    var item = A[0];
        //    A[0] = A[this.size - 1]; //copy last to first;
        //    this.size--;
        //    if(this.size > 1)
        //        HeapifyAtIndex(A,0);
        //    return item;
        //}


    }
}
