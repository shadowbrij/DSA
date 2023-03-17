using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Greedy
{
    class FreeCars
    {
        int size = 0;
        public int solve(List<int> A, List<int> B)
        {
            var N = A.Count;
            if (N == 1) return B[0];
            var cars = new List<Car>();
            for (int i = 0; i < N; i++)
            {
                cars.Add(new Car(A[i], B[i]));
            }
            cars.Sort(new CarComparer());
            var heap = new List<int>();
            var time = 0;

            for (int i = 0; i < N; i++)
            {
                if (time < A[i])
                {
                    time += 1;
                    Insert(heap, B[i]);
                }
                else
                {
                    if (B[i] <= heap[0])
                        continue;
                    else
                    {
                        poll(heap);
                        Insert(heap, B[i]);
                    }
                }
            }
            return Enumerable.Sum(heap.GetRange(0, size));
        }

        //Heap supported items
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
                if (A[parent] > A[i])
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
                int smallerChildIndex = getLeftchildIndex(index);
                if (items[smallerChildIndex] > items[getRightchildIndex(index)])
                    smallerChildIndex = getRightchildIndex(index);
                if (items[smallerChildIndex] > items[index])
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

        void Swap(List<int> A, int i, int j)
        {
            var temp = A[j];
            A[j] = A[i];
            A[i] = temp;
        }
    }
    public class Car
    {
        public int Time { get; set; }
        public int Profit { get; set; }
        public Car(int time, int profit)
        {
            this.Time = time;
            this.Profit = profit;
        }
    }
    public class CarComparer : IComparer<Car>
    {
        public int Compare(Car i, Car j)
        {
            return i.Time - j.Time;
        }
    }

}
