using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class Dijkstra
    {
        public List<int> solve(int A, List<List<int>> B, int C)
        {
            var graph = new Node[A];
            for (int i = 0; i < A; i++)
            {
                graph[i] = new Node(i);
            }
            foreach (var edge in B)
            {
                graph[edge[0]].adj.AddLast(new NodeWeight(edge[1], edge[2]));
                graph[edge[1]].adj.AddLast(new NodeWeight(edge[0], edge[2]));
            }
            var dist = Enumerable.Repeat(int.MaxValue, A).ToList();
            var visited = new bool[A];
            //give u as source and v as destination => (d[u]+w,v)
            var minHeap = new PriorityQueue<NodeWeight,int>();
            dist[C] = 0;
            visited[C] = true;

            graph[C].adj.ToList().ForEach(x => {
                    dist[x.val] = x.weight;
                    minHeap.Enqueue(x, dist[C]+x.weight);
                });

            while (minHeap.Count > 0)
            {
                var node = minHeap.Dequeue();
                visited[node.val] = true;
                foreach (var adj in graph[node.val].adj){                
                    if (dist[adj.val] > dist[node.val]+adj.weight){
                        dist[adj.val] = dist[node.val]+adj.weight;
                    }
                    if (!visited[adj.val])
                    {
                        minHeap.Enqueue(adj, dist[node.val]+adj.weight);
                    }
                }
            }
            for(int i = 0;i<A; i++)
            {
                if (dist[i] == int.MaxValue)
                {
                    dist[i] = -1;
                }
            }   
            return dist;
        }
        public class Node
        {
            public int val { get; set; }
            public int weight { get; set; }
            public LinkedList<NodeWeight> adj { get; set;}
            public Node(int val)
            {
                this.adj = new LinkedList<NodeWeight>();
                this.val = val;
                this.weight = int.MaxValue;
            }
        }

        public class NodeWeight
        {
            public int val { get;set;}
            public int weight { get;set;}

            public NodeWeight(int val,int weight)
            {
                this.val = val;
                this.weight = weight;
            }
        }

    }
}
