class BobSolution {
    int[] seg;
    public List < int > solve(int A, List < List < int >> B) {
        int n = A;
        seg = new int[4 * n + 4];
        int[] temp = new int[n];
        List < int > ans = new List < int > ();
        for (int i = 0; i < B.Count; i++) {
            int x = B[i][0];
            if (x == 1) {
                int ind = B[i][1] - 1;
                temp[ind]++;
                upda(1, 0, n - 1, ind, temp[ind]);
            } else if (x == 2) {
                int ind = B[i][1] - 1;
                if (temp[ind] == 0) {
                    continue;
                }
                temp[ind]--;
                upda(1, 0, n - 1, ind, temp[ind]);
            } else {
                ans.Add(query(1, 0, n - 1, B[i][1] - 1, B[i][2] - 1));
            }
        }
        return ans;
    }
    public void upda(int index, int low, int high, int id, int val) {
        if (low == high) {
            seg[index] = val;
            return;
        }
        int mid = (low + high) / 2;
        if (id <= mid && id >= low)
            upda(2 * index, low, mid, id, val);
        else
            upda(2 * index + 1, mid + 1, high, id, val);
        seg[index] = seg[2 * index] + seg[2 * index + 1];
    }
    public int query(int index, int low, int high, int l, int r) {
        if (low > high || low > r || high < l)
            return 0;
        if (low >= l && high <= r)
            return seg[index];
        int mid = (low + high) / 2;
        return query(2 * index, low, mid, l, r) + query(2 * index + 1, mid + 1, high, l, r);
    }
}