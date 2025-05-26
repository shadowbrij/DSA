using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.AnotherGraphs
{
    public class AnotherBFS
    {
        public int solve(int A, List<List<int>> B, int C, int D)
        {
            //10^5
            var graph = new Graph(A);
            foreach (List<int> edge in B)
            {
                if (edge[2] == 2)
                {
                    graph.nodeLookup.Add(A, new Graph.Node(A));
                    graph.addEdge(edge[0], A);// Aeed to add temp edge
                    graph.addEdge(A, edge[1]);
                    A++;
                }
                else
                {
                    graph.addEdge(edge[0], edge[1]);
                }
            }

            var visited = new bool[A];
            var queue = new LinkedList<int>();
            queue.AddLast(C);
            return graph.BFSPathSum(D, visited, queue);
        }
    }

    class Graph
    {
        int nodes;
        public Dictionary<int, Node> nodeLookup = new Dictionary<int, Node>();
        public Graph(int nodes)
        {
            this.nodes = nodes;
            for (int i = 0; i < nodes; i++)
            {
                nodeLookup.Add(i, new Node(i));
            }
        }
        public Node getNode(int id)
        {
            return nodeLookup[id];
        }

        public void addEdge(int s, int d)
        {
            Node source = getNode(s);
            Node dest = getNode(d);
            source.adjacents.AddFirst(dest);
            dest.adjacents.AddFirst(source);
        }

        public class Node
        {
            public int nodeid { get; set; }
            public int sum { get; set; }
            public LinkedList<Node> adjacents { get; set; }
            public Node(int nodeid)
            {
                this.nodeid = nodeid;
                this.adjacents = new LinkedList<Node>();
                this.sum = 1;
            }
        }

        public int BFSPathSum(int dest, bool[] visited, LinkedList<int> queue)
        {
            while (queue.Count > 0)
            {
                var processNode = queue.First();
                if (processNode == dest)
                {
                    return this.getNode(processNode).sum-1;
                }
                queue.RemoveFirst();
                visited[processNode] = true;
                var csum = this.getNode(processNode).sum;
                foreach (var node in this.getNode(processNode).adjacents)
                {
                    if (!visited[node.nodeid])
                    {
                        queue.AddLast(node.nodeid);
                        node.sum += csum;
                    }
                }
            }
            return -1;
        }
    }
}
