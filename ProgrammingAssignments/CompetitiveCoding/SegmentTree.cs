
class SegmentTree{
    private List<int> segTree;
    private List<int> A;
    public SegmentTree(List<int> A){
        this.A = A;
        this.segTree = Enumerable.Repeat(0,4*A.Count).ToList();
    }

    public void buildSegmentTree(int index, int left, int right){
        if(left == right){
            segTree[index] = A[left];
            return;
        }
       
        int mid = left + (right-left)/2;
        int leftChild = getLeftChild(index);
        int rightChild = getRightChild(index);
       
        buildSegmentTree(leftChild,left,mid);
        buildSegmentTree(rightChild,mid+1,right);

        //This is the key point 
        //your strategy of how you want to store so that queries can be made faster

        segTree[index] = Math.Min(segTree[leftChild],segTree[rightChild]);
    }
    
    //so everytime update will be called from root which is basically 0
    public void update(int root, int left, int right, int index, int value){
        if (left == right) //at leaft
        {
            //at leaf but update the required index. other calls to the adjustments(min) will handle
            //and bring the segTree in required shape
            segTree[root] = value;
            return;
        }

        int mid = left + (right -left)/2;
        int leftChild = getLeftChild(root);
        int rightChild = getRightChild(root);

        if(index <= mid) 
            update(leftChild,left,mid,index,value);
        else 
            update(rightChild,mid+1,right,index,value);

        segTree[root] = Math.Min(segTree[leftChild],segTree[rightChild]);

    }

    //start - start of range asked in query
    //end - end of range asked in query
    //begin (0,0,A.Count,<start>,<end>)
    public int query(int index, int left, int right,int start, int end){
        //only recurse further if the asked range(s,e) falls inside currently processing range(l,r)
        //if at a place totally outside of asked range
        if(right < start || left > end){
            return int.MaxValue;
        }
        
        //if range at current index falls completely inside the asked range just return current
        // index value because you don't need to asked from any of it's child 
        if(left >= start && right <= end)
            return segTree[index];

        //else recurse

        int mid = left + (right -left) /2;
        int leftChild = getLeftChild(index);
        int rightChild = getRightChild(index);

        int minLeftChild = query(leftChild,left,mid,start,end);
        int minRightChild = query(rightChild,mid+1,right,start,end);

        return Math.Min(minLeftChild,minRightChild);
        
    }

    private int getLeftChild(int index){
        return 2*index +1;
    }

    private int getRightChild(int index){
        return 2*index+2;
    }
}
