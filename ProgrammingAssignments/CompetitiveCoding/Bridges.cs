class Bridges {
    private int time = 0;
    List<List<int>> bridges = new List<List<int>>();
    public List<List<int>> solve(int A, List<List<int>> B) {
        var graph = new List<List<int>>(A + 1);

        for(int i = 0;i<=A;i++){
             graph.Add(new List<int>());
        }

        foreach(var edge in B){
            var f = edge[0];
            var t = edge[1];
            graph[f].Add(t);
            graph[t].Add(f);
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
        return bridges;
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
                
                if(low[adj] > dist[v]){
                    addBridge(v,adj);
                }
                low[v] = Math.Min(low[v], low[adj]);
            }
            else
            {
                low[v] = Math.Min(low[v], dist[adj]);
            }
        }
    }
    void addBridge(int a,int b){
        if(a<b){
            bridges.Add(new List<int>(){a,b});
        }
        else{
            bridges.Add(new List<int>(){b,a});
        }
    }
}
