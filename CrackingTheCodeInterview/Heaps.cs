using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public class Heaps
    {
    }
    public class MinHeap
    {
        private static int capacity = 10;
        private int size = 0;

        int[] items = new int[capacity];

        private int peek()
        {
            if (size == 0) throw new Exception();
            else return items[0];
        }
        private int poll()//this will remove the root element
        {
            if (size == 0) throw new Exception();
            int item = items[0];
            items[0] = items[size - 1];
            size--;
            heapifyDown();
            return item;
        }
        public void add(int item)
        {
            ensureExtraCapacity();
            items[size] = item;
            size++;
            heapifyUp();
        }

        private void heapifyUp()
        {
            int index = size - 1;
            while(hasParent(index) && parent(index) > items[index])
            {
                swap(index, getParentIndex(index));
                index = getParentIndex(index);
            }
        }

        private void heapifyDown()
        {
            int index = 0;
            while(hasLeftChild(index))
            {
                int smallerChildIndex = getLeftchildIndex(index);
                if (items[smallerChildIndex] > items[getRightchildIndex(index)])
                    smallerChildIndex = getRightchildIndex(index);
                if (items[smallerChildIndex] < items[index])
                    break;
                else
                {
                    swap(smallerChildIndex, index);
                }
                index = smallerChildIndex;
            }
        }


        //Helper methods
        private int getLeftchildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int getRightchildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }
        private bool hasLeftChild(int index) { return getLeftchildIndex(index) < size; }
        private bool hasParent(int index) { return getParentIndex(index) >= 0; }
        private int parent(int index) { return items[getParentIndex(index)]; }

        //Extra methods

        private void swap(int indexOne,int indexTwo)
        {
            int temp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = temp;
        }

        private void ensureExtraCapacity()
        {
            if(size == capacity)
            {
                Array.Resize<int>(ref items, capacity * 2);
                capacity *= 2;
            }
        }
    }
}
