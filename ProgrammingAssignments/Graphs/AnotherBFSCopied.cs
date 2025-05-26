using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class AnotherBFSCopied
    {
        public int solve(int A, List<List<int>> B, int C, int D)
        {

            List<GraphNode>[] graph = new List<GraphNode>[A + 1];

            for (int i = 0; i < B.Count; i++)
            {
                if (graph[B[i][0]] == null)
                    graph[B[i][0]] = new List<GraphNode>();

                graph[B[i][0]].Add(new GraphNode(B[i][1], B[i][2]));

                if (graph[B[i][1]] == null)
                    graph[B[i][1]] = new List<GraphNode>();

                graph[B[i][1]].Add(new GraphNode(B[i][0], B[i][2]));
            }

            PriorityQueue<GraphNode, int> qu = new PriorityQueue<GraphNode, int>();

            qu.Enqueue(new GraphNode(C, 0), 0);

            int ans = -1;

            List<int> path = new List<int>();

            while (qu.Count > 0)
            {
                GraphNode el = qu.Dequeue();

                if (path.Contains(el.dest))
                    continue;

                path.Add(el.dest);

                if (el.dest == D)
                {
                    ans = el.weight;
                    break;
                }

                List<GraphNode> GraphNoderen = graph[el.dest];

                if (GraphNoderen != null)
                {
                    foreach (GraphNode ch in GraphNoderen)
                    {
                        if (!path.Contains(ch.dest))
                            qu.Enqueue(new GraphNode(ch.dest, ch.weight + el.weight), ch.weight + el.weight);
                    }
                }
            }

            return ans;
        }
    }

    class GraphNode
    {
        public int dest;

        public int weight;

        public GraphNode(int dest, int weight)
        {
            this.dest = dest;
            this.weight = weight;
        }
    }
}
