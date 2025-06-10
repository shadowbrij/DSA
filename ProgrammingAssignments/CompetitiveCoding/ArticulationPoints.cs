class ArticulationPoints {
    private int time = 0;
    public List<int> solve(int A, List<List<int>> B) {
        var ans = new List<int>();
        var graph = new List<List<int>>(A + 1);

        for (int i = 0; i <= A; i++)
            graph.Add(new List<int>());
            
        foreach (var edge in B)
        {
            var f = edge[0];
            var t = edge[1];
            graph[f].AddRange(t);
            graph[t].AddRange(f);
        }

        //various other arrays
        var visited = Enumerable.Repeat(false,A+1).ToList();
        var isAP = Enumerable.Repeat(false,A+1).ToList();
        var dist = Enumerable.Repeat(0,A+1).ToList();
        var low = Enumerable.Repeat(0,A+1).ToList();

        for(int i=1;i<=A;i++){
            if(!visited[i])
                dfs(i,-1,visited,dist,low,graph,isAP);
        }
        for(int i=1;i<=A;i++){
            if(isAP[i]) 
                ans.Add(i);
        }
        return ans;
    }

    void dfs(int v,int parent, List<bool> visited,List<int> dist,List<int> low,List<List<int>> graph,List<bool> isAP){
        time++;
        visited[v] = true;
        dist[v] = time;
        low[v] = time;

        foreach(int adj in graph[v]){
            if(adj == parent) continue;

            if(!visited[adj]){
                dfs(adj,v,visited,dist,low,graph,isAP);
                
                if(parent != -1 && low[adj] > dist[v]){
                    isAP[v] = true;
                }
            }

            low[v] = Math.Min(low[adj],low[v]);
        }

        //check if current node in root(in the component)
        if(parent == -1 && graph[v].Count > 1){
            isAP[v] = true;
        }
    }
}
