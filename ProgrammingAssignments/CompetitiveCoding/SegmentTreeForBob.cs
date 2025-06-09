/*
Problem Description

Bob has an array A of N integers. Initially, all the elements of the array are zero. Bob asks you to perform Q operations on this array.

You have to perform three types of query, in each query you are given three integers x, y and z.

if x = 1: Update the value of A[y] to 2 * A[y] + 1.
if x = 2: Update the value A[y] to ⌊A[y]/2⌋ , where ⌊⌋ is Greatest Integer Function.
if x = 3: Take all the A[i] such that y <= i <= z and convert them into their corresponding binary strings. Now concatenate all the binary strings and find the total no. of '1' in the resulting string.
Queries are denoted by a 2-D array B of size M x 3 where B[i][0] denotes x, B[i][1] denotes y, B[i][2] denotes z.
*/
class SegmentTreeForBob {
    private List<int> segTree;
    private List<int> arr;  // Original array to store actual values

    public SegmentTreeForBob(int size) {
        this.arr = Enumerable.Repeat(0, size).ToList();
        this.segTree = Enumerable.Repeat(0, 4*size).ToList();
    }

    public void update(int index, int x, int y, int i, int type) {
        if(i < x || i > y)
            return;
        if(x == y) {
            // Update actual value in arr first
            arr[i] = type == 1 ? 2 * arr[i] + 1 : arr[i] / 2;
            // Then update segment tree with bit count
            segTree[index] = countOfSetBits(arr[i]);
            return;
        }

        int mid = getMiddle(x,y);
        int leftChild = getLeftChild(index);
        int rightChild = getRightChild(index);
        
        if(i <= mid)
            update(leftChild, x, mid, i, type);
        else
            update(rightChild, mid+1, y, i, type);
        
        // Sum of bit counts from children
        segTree[index] = segTree[leftChild] + segTree[rightChild];
    }

    public int query(int index,int x, int y, int left, int right){//asked range (left,right)
        if(y < left || x > right) return 0;
        if(x>=left && y <=right){
            return segTree[index];
        }

        int mid = getMiddle(x,y);
        int leftChild = getLeftChild(index);
        int righChild = getRightChild(index);

        return query(leftChild, x, mid, left, right)
            + query(righChild, mid + 1, y, left, right);
    }
    
    private int countOfSetBits(int value)
    {
        return System.Numerics.BitOperations.PopCount((uint)value);
    }
    private int getLeftChild(int index){
        return 2 * index + 1;
    }
    private int getRightChild(int index){
        return 2*index+2;
    }
    private int getMiddle(int left,int right){
        return left+(right-left)/2;
    }
}