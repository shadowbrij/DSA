using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignments.Graphs
{
    class CheckBipartiteGraph
    {
        public int solve(int A/*, List<List<int>> B*/)
        {
            //Intialize graph
            Graph graph = new Graph(A);
            //foreach (var list in B)
            //{
            //graph.AddEdge(list[0], list[1]);
            graph.AddEdge(8, 2);
            graph.AddEdge(2, 5);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 1);
            graph.AddEdge(8, 7);
            graph.AddEdge(2, 0);
            graph.AddEdge(0, 6);
            graph.AddEdge(1, 4);

            graph.AddEdge( 2,8);
            graph.AddEdge( 5,2);
            graph.AddEdge( 3,2);
            graph.AddEdge( 1,2);
            graph.AddEdge( 7,8);
            graph.AddEdge( 0,2);
            graph.AddEdge( 6,0);
            graph.AddEdge( 4,1);
            //}
            var colors = Enumerable.Repeat(-1, A).ToList();
            for (int i = 0; i < A; i++)
            {
                if (colors[i] == -1)
                {
                    colors[i] = oppositeColorFromAdjacents(i, graph, colors);
                    if (dfs(i, colors, graph) == 0)
                        return 0;
                }
            }
            return 1;
        }
        int oppositeColorFromAdjacents(int i, Graph graph, List<int> colors)
        {
            foreach (var adj in graph.getNode(i).adjacents)
            {
                if (colors[adj.id] != -1)
                    return colors[adj.id] ^ 1;
            }
            return 0;
        }

        int dfs(int node, List<int> colors, Graph graph)
        {
            var adjacents = graph.getNode(node).adjacents;
            foreach (var adjNode in adjacents)
            {
                if (colors[adjNode.id] == colors[node])
                    return 0;
                else if (colors[adjNode.id] == -1)
                {
                    colors[adjNode.id] = (1 ^ colors[node]);
                }
                if (dfs(adjNode.id, colors, graph) == 0)
                    return 0;
            }
            return 1;
        }
    }

}
