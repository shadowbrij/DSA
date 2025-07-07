/*
Problem Description:

Given A nodes and M edges connecting them. Each edge has some cost of construction. Builder wants to connect N cities in such way there is a path from one node to any other node.
For each edge E, Builder wants to find the minimum cost of connecting the nodes by including the edge E.
Edges are given by a 2D array B where nodes B[i][0] and B[i][1] are connected by an edge with cost of using this edge is B[i][2].

Problem Constraints:
1 <= A <= 105
1 <= B[i][0], B[i][1] <= A
1 <= B[i][2] <= 104

Input Format:
First argument is an integer A representing the total number of nodes.
Second argument is a 2D array B containing edges.


Output Format:
Return an integer array C where C[i] denotes the minimum cost of connecting the nodes by inluding ith edge
*/
class BuilderProblem
{
    class Edge
    {
        public int u, v, w, idx;
        public Edge(int u, int v, int w, int idx)
        {
            this.u = u;
            this.v = v;
            this.w = w;
            this.idx = idx;
        }
    }

    class DSU
    {
        int[] parent, rank;
        public DSU(int n)
        {
            parent = new int[n + 1];
            rank = new int[n + 1];
            for (int i = 0; i <= n; i++) parent[i] = i;
        }
        public int Find(int x)
        {
            if (parent[x] != x) parent[x] = Find(parent[x]);
            return parent[x];
        }
        public bool Union(int x, int y)
        {
            int px = Find(x), py = Find(y);
            if (px == py) return false;
            if (rank[px] < rank[py]) parent[px] = py;
            else if (rank[px] > rank[py]) parent[py] = px;
            else { parent[py] = px; rank[px]++; }
            return true;
        }
    }

    int LOG = 17; // For up to 1e5 nodes, log2(1e5) ≈ 17

    public List<int> solve(int numNodes, List<List<int>> edgesInput)
    {
        int numEdges = edgesInput.Count;
        var edges = new List<Edge>();
        for (int i = 0; i < numEdges; i++)
            edges.Add(new Edge(edgesInput[i][0], edgesInput[i][1], edgesInput[i][2], i));

        // Kruskal's MST
        edges.Sort((a, b) => a.w.CompareTo(b.w));
        var dsu = new DSU(numNodes);
        long mstTotalCost = 0;
        var isEdgeInMST = new bool[numEdges];

        // Build MST and adjacency list for MST
        var mstAdjList = new List<(int, int)>[numNodes + 1];
        for (int i = 0; i <= numNodes; i++) mstAdjList[i] = new List<(int, int)>();

        foreach (var edge in edges)
        {
            if (dsu.Union(edge.u, edge.v))
            {
                mstTotalCost += edge.w;
                isEdgeInMST[edge.idx] = true;
                mstAdjList[edge.u].Add((edge.v, edge.w));
                mstAdjList[edge.v].Add((edge.u, edge.w));
            }
        }

        // Binary lifting precomputation
        int[,] parent = new int[numNodes + 1, LOG];
        int[,] maxEdgeWeight = new int[numNodes + 1, LOG];
        int[] nodeDepth = new int[numNodes + 1];

        void Dfs(int current, int par)
        {
            foreach (var (neighbor, weight) in mstAdjList[current])
            {
                if (neighbor == par) continue;
                nodeDepth[neighbor] = nodeDepth[current] + 1;
                parent[neighbor, 0] = current;
                maxEdgeWeight[neighbor, 0] = weight;
                for (int j = 1; j < LOG; j++)
                {
                    parent[neighbor, j] = parent[parent[neighbor, j - 1], j - 1];
                    maxEdgeWeight[neighbor, j] = Math.Max(maxEdgeWeight[neighbor, j - 1], maxEdgeWeight[parent[neighbor, j - 1], j - 1]);
                }
                Dfs(neighbor, current);
            }
        }

        // Root at 1 (assuming nodes are 1-indexed)
        for (int i = 1; i <= numNodes; i++)
        {
            if (nodeDepth[i] == 0)
            {
                parent[i, 0] = i;
                maxEdgeWeight[i, 0] = 0;
                Dfs(i, 0);
            }
        }

        int FindLCA(int u, int v)
        {
            if (nodeDepth[u] < nodeDepth[v]) (u, v) = (v, u);
            for (int j = LOG - 1; j >= 0; j--)
                if (nodeDepth[u] - (1 << j) >= nodeDepth[v])
                    u = parent[u, j];
            if (u == v) return u;
            for (int j = LOG - 1; j >= 0; j--)
                if (parent[u, j] != parent[v, j])
                {
                    u = parent[u, j];
                    v = parent[v, j];
                }
            return parent[u, 0];
        }

        int MaxEdgeOnPath(int u, int ancestor)
        {
            int maxWeight = 0;
            for (int j = LOG - 1; j >= 0; j--)
            {
                if (nodeDepth[u] - (1 << j) >= nodeDepth[ancestor])
                {
                    maxWeight = Math.Max(maxWeight, maxEdgeWeight[u, j]);
                    u = parent[u, j];
                }
            }
            return maxWeight;
        }

        var answer = new int[numEdges];
        for (int i = 0; i < numEdges; i++)
        {
            if (isEdgeInMST[i])
            {
                answer[i] = (int)mstTotalCost;
            }
            else
            {
                int u = edgesInput[i][0], v = edgesInput[i][1], w = edgesInput[i][2];
                int lca = FindLCA(u, v);
                int maxEdge = Math.Max(MaxEdgeOnPath(u, lca), MaxEdgeOnPath(v, lca));
                answer[i] = (int)(mstTotalCost - maxEdge + w);
            }
        }
        return answer.ToList();
    }
}
