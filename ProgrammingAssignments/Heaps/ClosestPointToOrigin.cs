using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Heaps
{
    class ClosestPointToOrigin
    {
        int size = 0;
        public List<List<int>> solve(List<List<int>> A, int B)
        {
            int N = A.Count;
            if ((N == 1) && (B == 1)) return new List<List<int>>() { A[0] };

            var heapOfDistance = new List<Tuple<int,List<int>>>();
            var map = new Dictionary<int, List<int>>();

            foreach (var point in A)
            {
                var distance = (int)Math.Sqrt(point[0] * point[0] + point[1] * point[1]);
                var node = Tuple.Create(distance, point);
                Insert(heapOfDistance, node);
                //map.Add(distance,point);
            }
            var ans = new List<List<int>>();
            while (B-- > 0)
            {
                var tple = poll(heapOfDistance);
                ans.Add(tple.Item2);
            }
            return ans;
        }
        void Insert(List<Tuple<int, List<int>>> A, Tuple<int, List<int>> B)
        {
            if (A.Count == this.size)
                A.Add(B);
            else A[this.size] = B;
            this.size++;

            HeapifyUp(A);
        }

        void HeapifyUp(List<Tuple<int, List<int>>> A)
        {
            int i = this.size - 1;
            while (i > 0)
            {
                var parent = (i - 1) / 2;
                if (A[parent].Item1 > A[i].Item1)
                {
                    Swap(A, i, parent);
                    i = parent;
                }
                else
                    break;
            }
        }
        void HeapifyAtIndex(List<Tuple<int, List<int>>> A, int i)
        {
            int left = (2 * i + 1);
            bool hasLeft = this.size > left;

            int right = (2 * i + 2);
            bool hasRight = this.size > right;

            if (!(hasLeft || hasRight))
                return;

            if (hasLeft && (A[left].Item1 < A[i].Item1))
            {
                Swap(A, i, left);
                HeapifyAtIndex(A, left);
            }

            if (hasRight && (A[right].Item1 < A[i].Item1))
            {
                Swap(A, i, right);
                HeapifyAtIndex(A, right);
            }
        }

        Tuple<int,List<int>> poll(List<Tuple<int, List<int>>> A)
        {
            var item = A[0];
            A[0] = A[this.size - 1]; //copy last to first;
            this.size--;
            if (this.size > 1)
                heapifyDown(A);
            return item;
        }

        private void heapifyDown(List<Tuple<int, List<int>>> items)
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftchildIndex(index);
                if (items[smallerChildIndex].Item1 > items[getRightchildIndex(index)].Item1)
                    smallerChildIndex = getRightchildIndex(index);
                if (items[smallerChildIndex].Item1 > items[index].Item1)
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
        private bool hasParent(int index) { return getParentIndex(index) >= 0; }

        void Swap(List<Tuple<int, List<int>>> A, int i, int j)
        {
            var temp = A[j];
            A[j] = A[i];
            A[i] = temp;
        }
    }



}
