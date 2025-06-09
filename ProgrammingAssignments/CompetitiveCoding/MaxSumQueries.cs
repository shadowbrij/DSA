class MaxSumQueries {
    public List<int> solve(List<int> A, List<List<int>> B) {
        var N = A.Count;
        var segTree = new MaxSegmentTree(A);
        segTree.build(0,0,N-1);
        var ans = new List<int>();
        foreach(var query in B){
            int type = query[0];
            int p = query[1];
            int q = query[2];
            if(type == 1){
                segTree.update(0,0,N-1,p,q);
            }
            else if(type ==2){
                ans.Add(segTree.query(0,0,N-1,p,q));
            }
        }
        return ans;
    }
}
class MaxSegmentTree{
    List<int> A;
    List<int> segTree;
    public MaxSegmentTree(List<int> arr)
    {
        this.A = arr;
        this.segTree = Enumerable.Repeat(0, 4 * arr.Count).ToList();
    }

    public void build(int index,int x,int y){
        if(x == y){
            segTree[index] = A[x];
            return;
        }
        int mid = x+(y-x)/2;
        build(2*index+1,x,mid);
        build(2*index+2,mid+1,y);

        segTree[index] = findMaxSum(index);//Math.Max(segTree[2*index+1],segTree[2*index+2]);
    }
    public void update(int index,int x,int y,int i,int value){
        if(x > i || y < i) return;
        if(x == y){
            segTree[index] = value;
            A[i] = value;
            return;
        }
        int mid = x+(y-x)/2;
        if(i<=mid){
            update(2*index+1,x,mid,i,value);
        }
        else{
            update(2*index+2,mid+1,y,i,value);
        }
        segTree[index] = findMaxSum(index);//Math.Max(segTree[2*index+1],segTree[2*index+2]);
    }

    public int query(int index,int x,int y,int start, int end){
        if(y < start || x > end) return int.MinValue;

        if(x>=start && y<=end){
            return segTree[index];
        }
        int mid = x+(y-x)/2;

        int maxLeft = query(2*index+1,x,mid,start,end);
        int maxRight = query(2*index+2,mid+1,y,start,end);
        return Math.Max(maxLeft,maxRight);
    }
    private int findMaxSum(int index){
        return Math.Max(
            Math.Max(segTree[2*index+1],segTree[2*index+2])
            ,segTree[2*index+1] + segTree[2*index+2]
        );
    }
}