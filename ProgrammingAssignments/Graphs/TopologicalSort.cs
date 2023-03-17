using ProgrammingAssignments.Heaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class TopologicalSort
    {
        public List<int> solve(int A, List<List<int>> B)
        {
            Graph graph = new Graph(A);
            var Indeg = new int[A + 1];
            var IndegZeroNodes = new MinHeaps(0);
            var visited = new bool[A + 1];
            var ans = new List<int>();

            foreach (var list in B)
            {
                //keep in mind that nodes are numbered from 1 to A.
                graph.AddEdge(list[0], list[1]);
            }
            for (int i = 1; i <= A; i++)
            {
                foreach (var node in graph.getNode(i).adjacents)
                {
                    Indeg[node.id]++;
                }
            }

            for (int i = 1; i <= A; i++)
            {
                if (Indeg[i] == 0)
                    IndegZeroNodes.Insert(i);
            }

            BFS(graph, ans, IndegZeroNodes, Indeg);
            return ans;
        }

        void BFS(Graph graph, List<int> ans, MinHeaps IndegZeroNodes, int[] Indeg)
        {
            while (IndegZeroNodes.size > 0)
            {
                var node = IndegZeroNodes.poll();

                foreach (var adjNode in graph.getNode(node).adjacents)
                {
                    if (Indeg[adjNode.id] > 0)
                    {
                        Indeg[adjNode.id]--;
                        if (Indeg[adjNode.id] == 0) IndegZeroNodes.Insert(adjNode.id);
                    }
                }
                ans.Add(node);
            }

        }
    }

}
