class SolveSegmentTree
{
    public List<int> solve(List<int> A, List<List<int>> B)
    {
        var segmentTree = new SegmentTree(A);
        var N = A.Count;
        segmentTree.buildSegmentTree(0, 0, N - 1);
        var ans = new List<int>();
        foreach (var query in B)
        {
            if (query[0] == 0)
            {
                //update
                segmentTree.update(0, 0, N - 1, query[1], query[2]);
            }
            else if (query[0] == 1)
            {
                ans.Add(segmentTree.query(0, 0, N - 1, query[1], query[2]));
            }
        }
        return ans;
    }
     public List<int> solveBob(int A, List<List<int>> B) {
        var ans = new List<int>();
        var segTree = new SegmentTreeForBob(A);
        foreach(var query in B){
            var type = query[0];
            var left = query[1];
            var right = query[2];

            if(type == 1){
                segTree.update(0,0,A-1,left,1);
            }
            else if(type == 2){
                segTree.update(0,0,A-1,left,2);
            }
            else if(type == 3){
                ans.Add(segTree.query(0,0,A-1,left,right));
            }
        }
        return ans;
    }
}